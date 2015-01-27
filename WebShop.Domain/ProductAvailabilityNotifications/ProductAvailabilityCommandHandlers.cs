using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain
{
    public class ProductAvailabilityCommandHandlers
    {
        private readonly IRepository<ProductAvailabilityNotification> _repository;

        public ProductAvailabilityCommandHandlers(IRepository<ProductAvailabilityNotification> repository)
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