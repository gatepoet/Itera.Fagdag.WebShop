using System;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public class ShoppingCartDto
    {
        public Guid Id { get; set; }
        public ShoppingCartItemDto[] Items { get; set; }
        public int Version { get; set; }
    }
}