using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class PaymentCompleted : Event
    {
        public readonly Guid OrderId;

        public PaymentCompleted(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}