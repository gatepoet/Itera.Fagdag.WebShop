using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class OrderCreated : Event
    {
        public readonly Guid OrderId;
        public readonly Guid CartId;

        public OrderCreated(Guid orderId, Guid cartId)
        {
            CartId = cartId;
            OrderId = orderId;
        }
    }
}