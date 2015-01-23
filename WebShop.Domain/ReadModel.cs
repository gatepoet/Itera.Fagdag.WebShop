using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Itera.Fagdag.WebShop.Domain
{

    #region Old

    public interface IReadModelFacade
    {
        IEnumerable<InventoryItemListDto> GetInventoryItems();
        InventoryItemDetailsDto GetInventoryItemDetails(Guid id);
    }

    public class InventoryItemDetailsDto
    {
        public Guid Id;
        public string Name;
        public int CurrentCount;
        public int Version;

        public InventoryItemDetailsDto(Guid id, string name, int currentCount, int version)
        {
            Id = id;
            Name = name;
            CurrentCount = currentCount;
            Version = version;
        }
    }

    public class InventoryItemListDto
    {
        public Guid Id;
        public string Name;

        public InventoryItemListDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class InventoryListView : Handles<InventoryItemCreated>, Handles<InventoryItemRenamed>,
        Handles<InventoryItemDeactivated>
    {
        public void Handle(InventoryItemCreated message)
        {
            BullShitDatabase.list.Add(new InventoryItemListDto(message.Id, message.Name));
        }

        public void Handle(InventoryItemRenamed message)
        {
            var item = BullShitDatabase.list.Find(x => x.Id == message.Id);
            item.Name = message.NewName;
        }

        public void Handle(InventoryItemDeactivated message)
        {
            BullShitDatabase.list.RemoveAll(x => x.Id == message.Id);
        }
    }

    public class InvenotryItemDetailView : Handles<InventoryItemCreated>, Handles<InventoryItemDeactivated>,
        Handles<InventoryItemRenamed>, Handles<ItemsRemovedFromInventory>, Handles<ItemsCheckedInToInventory>
    {
        public void Handle(InventoryItemCreated message)
        {
            BullShitDatabase.details.Add(message.Id, new InventoryItemDetailsDto(message.Id, message.Name, 0, 0));
        }

        public void Handle(InventoryItemRenamed message)
        {
            InventoryItemDetailsDto d = GetDetailsItem(message.Id);
            d.Name = message.NewName;
            d.Version = message.Version;
        }

        private InventoryItemDetailsDto GetDetailsItem(Guid id)
        {
            InventoryItemDetailsDto d;

            if (!BullShitDatabase.details.TryGetValue(id, out d))
            {
                throw new InvalidOperationException("did not find the original inventory this shouldnt happen");
            }

            return d;
        }

        public void Handle(ItemsRemovedFromInventory message)
        {
            InventoryItemDetailsDto d = GetDetailsItem(message.Id);
            d.CurrentCount -= message.Count;
            d.Version = message.Version;
        }

        public void Handle(ItemsCheckedInToInventory message)
        {
            InventoryItemDetailsDto d = GetDetailsItem(message.Id);
            d.CurrentCount += message.Count;
            d.Version = message.Version;
        }

        public void Handle(InventoryItemDeactivated message)
        {
            BullShitDatabase.details.Remove(message.Id);
        }
    }

    public class ReadModelFacade : IReadModelFacade
    {
        public IEnumerable<InventoryItemListDto> GetInventoryItems()
        {
            return BullShitDatabase.list;
        }

        public InventoryItemDetailsDto GetInventoryItemDetails(Guid id)
        {
            return BullShitDatabase.details[id];
        }
    }

    public static class BullShitDatabase
    {
        public static Dictionary<Guid, InventoryItemDetailsDto> details =
            new Dictionary<Guid, InventoryItemDetailsDto>();

        public static List<InventoryItemListDto> list = new List<InventoryItemListDto>();
    }

    #endregion


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


    #region 

    public interface IProductReadModelFacade
    {
        ProductDto[] GetAll();
        ProductDto GetById(int id);
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
                MaxSize = int.Parse(lines[6])
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

}
