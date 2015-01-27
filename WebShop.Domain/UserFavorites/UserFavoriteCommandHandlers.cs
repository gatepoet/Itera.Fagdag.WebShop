using Itera.Fagdag.WebShop.Domain.Infrastructure;
using Itera.Fagdag.WebShop.Domain.User;

namespace Itera.Fagdag.WebShop.Domain.UserFavorites
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
            _repository.Save(new Domain.UserFavorites.UserFavorites(message.UserId), -1);
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
}