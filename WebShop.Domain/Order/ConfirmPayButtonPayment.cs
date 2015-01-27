using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class ConfirmPayButtonPayment : Command
    {
        public readonly Guid OrderId;
        public readonly string Token;
        public readonly int OriginalVersion;

        public ConfirmPayButtonPayment(Guid orderId, string token, int originalVersion)
        {
            OrderId = orderId;
            Token = token;
            OriginalVersion = originalVersion;
        }
    }
}