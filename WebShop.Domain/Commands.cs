using System;

namespace Itera.Fagdag.WebShop.Domain
{
    public class Command : Message
    {
    }

    public class CreateCart : Command
    {
        public readonly Guid CartId;

        public CreateCart(Guid cartId)
        {
            CartId = cartId;
        }
    }
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
    public class RemoveCartItem : Command
    {
        public readonly Guid CartId;
        public readonly int ProductId;
        public readonly int Count;
        public readonly int OriginalVersion;

        public RemoveCartItem(Guid cartId, int productId, int count, int originalVersion)
        {
            CartId = cartId;
            ProductId = productId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }


    public class DeactivateInventoryItem : Command {
        public readonly Guid InventoryItemId;
        public readonly int OriginalVersion;

        public DeactivateInventoryItem(Guid inventoryItemId, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            OriginalVersion = originalVersion;
        }
    }

    public class CreateInventoryItem : Command {
        public readonly Guid InventoryItemId;
        public readonly string Name;

        public CreateInventoryItem(Guid inventoryItemId, string name)
        {
            InventoryItemId = inventoryItemId;
            Name = name;
        }
    }

    public class RenameInventoryItem : Command {
        public readonly Guid InventoryItemId;
        public readonly string NewName;
        public readonly int OriginalVersion;

        public RenameInventoryItem(Guid inventoryItemId, string newName, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            NewName = newName;
            OriginalVersion = originalVersion;
        }
    }

    public class CheckInItemsToInventory : Command {
        public Guid InventoryItemId;
        public readonly int Count;
        public readonly int OriginalVersion;

        public CheckInItemsToInventory(Guid inventoryItemId, int count, int originalVersion) {
            InventoryItemId = inventoryItemId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }

    public class RemoveItemsFromInventory : Command {
        public Guid InventoryItemId;
        public readonly int Count;
        public readonly int OriginalVersion;

        public RemoveItemsFromInventory(Guid inventoryItemId, int count, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }
}
