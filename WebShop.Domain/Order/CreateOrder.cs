using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class CreateOrder : Command
    {
        public readonly Guid OrderId;
        public readonly Guid CartId;

        public CreateOrder(Guid orderId, Guid cartId)
        {
            CartId = cartId;
            OrderId = orderId;
        }
    }
}