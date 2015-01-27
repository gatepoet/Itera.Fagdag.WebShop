using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class PayButtonPaymentConfirmed : Event
    {
        public readonly Guid OrderId;
        public readonly string Token;

        public PayButtonPaymentConfirmed(Guid orderId, string token)
        {
            OrderId = orderId;
            Token = token;
        }
    }
}