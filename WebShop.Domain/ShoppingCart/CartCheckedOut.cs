using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class CartCheckedOut : Event
    {
        public readonly Guid CartId;

        public CartCheckedOut(Guid cartId)
        {
            CartId = cartId;
        }
    }
}