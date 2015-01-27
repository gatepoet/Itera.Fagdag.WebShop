using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class CartCreated : Event
    {
        public readonly Guid CartId;

        public CartCreated(Guid cartId)
        {
            CartId = cartId;
        }
    }
}