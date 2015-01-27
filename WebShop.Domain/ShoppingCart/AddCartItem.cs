using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class AddCartItem : Command
    {
        public readonly Guid CartId;
        public readonly int ProductId;
        public readonly int Count;
        public readonly int OriginalVersion;

        public AddCartItem(Guid cartId, int productId, int count, int originalVersion)
        {
            CartId = cartId;
            ProductId = productId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }
}