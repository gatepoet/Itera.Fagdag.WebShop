using System;
using System.Collections.Generic;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.UserFavorites
{
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
}