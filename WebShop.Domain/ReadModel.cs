using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Itera.Fagdag.WebShop.Domain
{




    #region Shopping cart

    public interface IShoppingCartReadModelFacade
    {
        ShoppingCartDto[] GetAll();
        ShoppingCartDto GetById(Guid id);
    }

    public class ShoppingCartReadModelFacade : IShoppingCartReadModelFacade
    {
        public ShoppingCartDto[] GetAll()
        {
            return ShoppingCartDatabase.ShoppingCarts.Values.ToArray();
        }

        public ShoppingCartDto GetById(Guid id)
        {
            return ShoppingCartDatabase.ShoppingCarts.ContainsKey(id)
                ? ShoppingCartDatabase.ShoppingCarts[id]
                : null;
        }
    }

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


    public static class ShoppingCartDatabase
    {
        public static Dictionary<Guid, ShoppingCartDto> ShoppingCarts = new Dictionary<Guid, ShoppingCartDto>();
    }

    public class ShoppingCartDto
    {
        public Guid Id { get; set; }
        public ShoppingCartItemDto[] Items { get; set; }
        public int Version { get; set; }
    }

    public class ShoppingCartItemDto
    {
        public ProductDto Product { get; set; }
        public int Count { get; set; }
    }

    #endregion


    #region Product

    public interface IProductReadModelFacade
    {
        ProductDto[] GetAll();
        ProductDto GetById(int id);
        ProductDto[] GetByCategory(string category);
        ProductDto[] GetByBrand(string brand);
    }

    public class ProductReadModelFacade : IProductReadModelFacade
    {
        public ProductDto[] GetAll()
        {
            return ProductDatabase.Products.ToArray();
        }

        public ProductDto GetById(int id)
        {
            return ProductDatabase.Products.Single(p => p.Id == id);
        }

        public ProductDto[] GetByCategory(string category)
        {
            return ProductDatabase.Products.Where(x => x.Category == category).ToArray();
        }
        public ProductDto[] GetByBrand(string brand)
        {
            return ProductDatabase.Products.Where(x => x.Brand == brand).ToArray();
        }
    }

    public static class ProductDatabase
    {
        public static void LoadFromDisk(string folder)
        {
            Products.Clear();
            Products.AddRange(Directory.GetFiles(folder, "*.txt")
                .Select(ReadProduct)
                .ToList());
        }

        private static ProductDto ReadProduct(string path)
        {
            var lines = File.ReadAllLines(path);
            var id = ParseId(path);
            return ParseProduct(id, lines);
        }

        private static ProductDto ParseProduct(int id, IList<string> lines)
        {
            return new ProductDto
            {
                Id = id,
                Price = decimal.Parse(lines[0]),
                Title = lines[1],
                Description = lines[2],
                ImageSource = string.Format("/produkter/{0}.jpg", id),
                Brand = lines[3],
                Color = lines[4],
                MinSize = int.Parse(lines[5]),
                MaxSize = int.Parse(lines[6]),
                Category = lines[7]
            };
        }

        private static int ParseId(string path)
        {
            var filename = Path.GetFileName(path);
            return int.Parse(filename.Substring(0, filename.LastIndexOf('.')));
        }

        public static List<ProductDto> Products = new List<ProductDto>();
    }

    #endregion

    #region User

    public interface IUserReadModelFacade
    {
        
    }

    #endregion
}
