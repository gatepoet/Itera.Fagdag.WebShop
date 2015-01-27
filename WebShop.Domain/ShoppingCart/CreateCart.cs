using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class CreateCart : Command
    {
        public readonly Guid CartId;

        public CreateCart(Guid cartId)
        {
            CartId = cartId;
        }
    }
}