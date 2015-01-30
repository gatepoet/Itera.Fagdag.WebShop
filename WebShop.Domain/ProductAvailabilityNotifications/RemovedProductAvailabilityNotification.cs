using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ProductAvailabilityNotifications
{
    public class RemovedProductAvailabilityNotification : Event
    {
        public readonly Guid ProductId;
        public readonly string Email;

        public RemovedProductAvailabilityNotification(Guid productId, string email)
        {
            ProductId = productId;
            Email = email;
        }
    }
}