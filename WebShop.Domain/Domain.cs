using System;
using System.Collections.Generic;
using System.Linq;

namespace Itera.Fagdag.WebShop.Domain
{
     public class ShoppingCartItem
    {
        private int _productId;
        private int _count;

        public int ProductId
        {
            get { return _productId; }
        }

        public bool IsEmpty { get { return _count == 0; } }

        public void Add(int count)
        {
            _count += count;
        }

        public void Remove(int count)
        {
            _count -= count;
            if (_count < 0) _count = 0;
        }

        internal ShoppingCartItem()
        {
            // used to create in repository ... many ways to avoid this, eg making private constructor
        }

        public ShoppingCartItem(int productId)
        {
            _productId = productId;
        }
    }

    public class UserFavorites : AggregateRoot
    {
        private readonly Guid _id;
        private readonly List<int> _items = new List<int>();

        public UserFavorites()
        {
        }

        public UserFavorites(Guid id)
        {
            _id = id;
        }

        private void Apply(AddedToFavorites @event)
        {
            if(!_items.Contains(@event.ProductId))
                _items.Add(@event.ProductId);
        }

        private void Apply(RemovedFromFavorites @event)
        {
            if (_items.Contains(@event.ProductId))
                _items.Remove(@event.ProductId);
        }

        public void AddFavorite(Guid userId, int productId)
        {
            ApplyChange(new AddedToFavorites(userId, productId));
        }

        public void RemoveFavorite(Guid userId, int productId)
        {
            ApplyChange(new RemovedFromFavorites(userId,productId));
        }

        public override Guid Id
        {
            get { return _id; }
        }
    }

    public class ProductAvailabilityNotification : AggregateRoot {
        private readonly Guid _id;
        private readonly List<string> _items = new List<string>();

        public ProductAvailabilityNotification()
        {
            
        }
        public ProductAvailabilityNotification(Guid id)
        {
            _id = id;
        }

        private void Apply(RemovedProductAvailabilityNotification @event)
        {
            if (!_items.Contains(@event.Email))
                _items.Add(@event.Email);
        }

        private void Apply(RemoveProductAvailabilityNotification @event)
        {
            if (_items.Contains(@event.Email))
                _items.Remove(@event.Email);
        }

        public override Guid Id
        {
            get { return _id; }
        }

        public void AddNotification(Guid productId, string email)
        {
            ApplyChange(new AddedProductAvailabilityNotification(productId,email));
        }

        public void RemoveNotification(Guid productId, string email)
        {
            ApplyChange(new RemovedProductAvailabilityNotification(productId,email));
        }
    }

    public class ShoppingCart : AggregateRoot
    {
        private Guid _id;
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();

        public override Guid Id
        {
            get { return _id; }
        }

        private void Apply(CartCreated e)
        {
            _id = e.CartId;
        }

        private void Apply(CartItemAdded e)
        {
            var item = _items.SingleOrDefault(i => i.ProductId == e.ProductId);
            if (item == null)
            {
                item = new ShoppingCartItem(e.ProductId);
                _items.Add(item);
            }
            item.Add(e.Count);
        }

        private void Apply(CartItemRemoved e)
        {
            var item = _items.Single(i => i.ProductId == e.ProductId);
            item.Remove(e.Count);
            if (item.IsEmpty)
                _items.Remove(item);
        }

        public ShoppingCart() { }

        public ShoppingCart(Guid id)
        {
            ApplyChange(new CartCreated(id));
        }

        public void AddItem(int productId, int count)
        {
            ApplyChange(new CartItemAdded(_id, productId, count));
        }

        public void RemoveItem(int productId, int count)
        {
            ApplyChange(new CartItemRemoved(_id, productId, count));
        }
    }

    public abstract class AggregateRoot
    {
        private readonly List<Event> _changes = new List<Event>();

        public abstract Guid Id { get; }
        public int Version { get; internal set; }

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history) ApplyChange(e, false);
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event, true);
        }

        // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
        private void ApplyChange(Event @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);
            if(isNew) _changes.Add(@event);
        }
    }

    public interface IRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }

    public class Repository<T> : IRepository<T> where T: AggregateRoot, new() //shortcut you can do as you see fit with new()
    {
        private readonly IEventStore _storage;

        public Repository(IEventStore storage)
        {
            _storage = storage;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.GetUncommittedChanges(), expectedVersion);
        }

        public T GetById(Guid id)
        {
            var obj = new T();//lots of ways to do this
            var e = _storage.GetEventsForAggregate(id);
            obj.LoadsFromHistory(e);
            return obj;
        }
    }

}
