using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class CheckOutCart : Command
    {
        public readonly Guid CartId;
        public readonly int OriginalVersion;

        public CheckOutCart(Guid cartId, int originalVersion)
        {
            CartId = cartId;
            OriginalVersion = originalVersion;
        }
    }
}