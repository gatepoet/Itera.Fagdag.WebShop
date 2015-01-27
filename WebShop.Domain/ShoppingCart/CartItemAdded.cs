using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class CartItemAdded : Event
    {
        public readonly Guid CartId;
        public readonly int ProductId;
        public readonly int Count;

        public CartItemAdded(Guid cartId, int productId, int count)
        {
            CartId = cartId;
            ProductId = productId;
            Count = count;
        }
    }
}