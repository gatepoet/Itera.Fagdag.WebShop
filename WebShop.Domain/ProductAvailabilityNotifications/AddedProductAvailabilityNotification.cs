using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain
{
    public class AddedProductAvailabilityNotification : Event
    {
        public readonly Guid ProductId;
        public readonly string Email;

        public AddedProductAvailabilityNotification(Guid productId, string email)
        {
            ProductId = productId;
            Email = email;
        }
    }
}