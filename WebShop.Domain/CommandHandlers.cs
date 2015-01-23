namespace Itera.Fagdag.WebShop.Domain
{
    public class ShoppingCartCommandHandlers
    {
        private readonly IRepository<ShoppingCart> _repository;

        public ShoppingCartCommandHandlers(IRepository<ShoppingCart> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateCart message)
        {
            var cart = new ShoppingCart(message.CartId);
            _repository.Save(cart, -1);
        }

        public void Handle(AddCartItem message)
        {
            var cart = _repository.GetById(message.CartId);
            cart.AddItem(message.ProductId, message.Count);
            _repository.Save(cart, message.OriginalVersion);
        }

        public void Handle(RemoveCartItem message)
        {
            var cart = _repository.GetById(message.CartId);
            cart.RemoveItem(message.ProductId, message.Count);
            _repository.Save(cart, message.OriginalVersion);
        }
    }

    public class InventoryCommandHandlers
    {
        private readonly IRepository<InventoryItem> _repository;

        public InventoryCommandHandlers(IRepository<InventoryItem> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateInventoryItem message)
        {
            var item = new InventoryItem(message.InventoryItemId, message.Name);
            _repository.Save(item, -1);
        }

        public void Handle(DeactivateInventoryItem message)
        {
            var item = _repository.GetById(message.InventoryItemId);
            item.Deactivate();
            _repository.Save(item, message.OriginalVersion);
        }

        public void Handle(RemoveItemsFromInventory message)
        {
            var item = _repository.GetById(message.InventoryItemId);
            item.Remove(message.Count);
            _repository.Save(item, message.OriginalVersion);
        }

        public void Handle(CheckInItemsToInventory message)
        {
            var item = _repository.GetById(message.InventoryItemId);
            item.CheckIn(message.Count);
            _repository.Save(item, message.OriginalVersion);
        }

        public void Handle(RenameInventoryItem message)
        {
            var item = _repository.GetById(message.InventoryItemId);
            item.ChangeName(message.NewName);
            _repository.Save(item, message.OriginalVersion);
        }
    }
}
