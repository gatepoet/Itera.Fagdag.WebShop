using System;
using System.Collections.Generic;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public static class ShoppingCartDatabase
    {
        public static Dictionary<Guid, ShoppingCartDto> ShoppingCarts = new Dictionary<Guid, ShoppingCartDto>();
    }
}