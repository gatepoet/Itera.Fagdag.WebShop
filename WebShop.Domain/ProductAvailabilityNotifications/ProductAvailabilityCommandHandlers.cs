using Itera.Fagdag.WebShop.Domain.Infrastructure;
using Itera.Fagdag.WebShop.Domain.Products;

namespace Itera.Fagdag.WebShop.Domain.ProductAvailabilityNotifications
{
    public class ProductAvailabilityCommandHandlers
    {
        private readonly IAggregateRepository<ProductAvailabilityNotification> _repository;

        public ProductAvailabilityCommandHandlers(IAggregateRepository<ProductAvailabilityNotification> repository)
        {
            _repository = repository;
        }

        public void Handle(ProductCreated message)
        {
            _repository.Save(new ProductAvailabilityNotification(message.ProductId.ToGuid()), -1);
        }

        public void Handle(AddProductAvailabilityNotification message)
        {
            var availability = _repository.GetById(message.ProductId.ToGuid());
            var version = availability.Version;
            availability.AddNotification(message.ProductId.ToGuid(), message.Email);
            _repository.Save(availability, version);
        }

        public void Handle(RemoveProductAvailabilityNotification message)
        {
            var favorites = _repository.GetById(message.ProductId.ToGuid());
            var version = favorites.Version;
            favorites.RemoveNotification(message.ProductId.ToGuid(), message.Email);
            _repository.Save(favorites, version);
        }
    }
}