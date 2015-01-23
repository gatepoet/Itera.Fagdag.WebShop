namespace Itera.Fagdag.WebShop.Domain
{
    public class UserFavoriteCommandHandlers
    {
        private readonly IRepository<UserFavorites> _repository;

        public UserFavoriteCommandHandlers(IRepository<UserFavorites> repository)
        {
            _repository = repository;
        }

        public void Handle(UserCreated message)
        {
            _repository.Save(new UserFavorites(message.UserId), -1);
        }

        public void Handle(AddToFavorites message)
        {
            var favorites = _repository.GetById(message.UserId);
            var version = favorites.Version;
            favorites.AddFavorite(message.UserId,message.ProductId);
            _repository.Save(favorites, version);
        }

        public void Handle(RemoveFromFavorites message)
        {
            var favorites = _repository.GetById(message.UserId);
            var version = favorites.Version;
            favorites.RemoveFavorite(message.UserId, message.ProductId);
            _repository.Save(favorites, version);
        }
    }

    public class SubscriptionNotificationCommandHandlers
    {
        
    }

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

}
