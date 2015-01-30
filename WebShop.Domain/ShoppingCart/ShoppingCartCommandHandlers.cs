using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class ShoppingCartCommandHandlers
    {
        private readonly IAggregateRepository<ShoppingCart> _repository;

        public ShoppingCartCommandHandlers(IAggregateRepository<ShoppingCart> repository)
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

        public void Handle(CheckOutCart message)
        {
            var cart = _repository.GetById(message.CartId);
            cart.Checkout();
            _repository.Save(cart, message.OriginalVersion);
        }
    }
}