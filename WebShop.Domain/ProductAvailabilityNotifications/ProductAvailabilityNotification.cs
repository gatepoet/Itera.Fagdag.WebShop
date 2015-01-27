using System;
using System.Collections.Generic;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain
{
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
}