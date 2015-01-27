using System.Linq;
using Itera.Fagdag.WebShop.Domain.Infrastructure;
using Itera.Fagdag.WebShop.Domain.ShoppingCart;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public class ShoppingCartView :
        Handles<CartCreated>,
        Handles<CartItemAdded>,
        Handles<CartItemRemoved>
    {
        public void Handle(CartCreated message)
        {
            ShoppingCartDatabase.ShoppingCarts.Add(
                message.CartId,
                new ShoppingCartDto
                {
                    Id = message.CartId,
                    Items = new ShoppingCartItemDto[0],
                    Version = message.Version
                });
        }

        public void Handle(CartItemAdded message)
        {
            var cart = ShoppingCartDatabase.ShoppingCarts[message.CartId];
            var item = GetCartItem(cart, message.ProductId);
            if (item != null)
            {
                item.Count += message.Count;
            }
            else
            {
                var items = cart.Items.ToList();
                items.Add(new ShoppingCartItemDto
                {
                    Count = message.Count,
                    Product = GetProduct(message.ProductId)
                });
                cart.Items = items.ToArray();
            }
            cart.Version = message.Version;
        }

        public void Handle(CartItemRemoved message)
        {
            var cart = ShoppingCartDatabase.ShoppingCarts[message.CartId];
            var item = GetCartItem(cart, message.ProductId);
            if (item == null) return;

            item.Count -= message.Count;
            cart.Version = message.Version;

            if (item.Count > 0) return;

            var items = cart.Items.ToList();
            items.Remove(item);
            cart.Items = items.ToArray();
        }

        private static ProductDto GetProduct(int id)
        {
            return ProductDatabase.Products.Find(p => p.Id == id);
        }

        private static ShoppingCartItemDto GetCartItem(ShoppingCartDto cart, int productId)
        {
            ShoppingCartItemDto item = cart.Items
                .SingleOrDefault(i => i.Product.Id == productId);
            return item;
        }
    }
}