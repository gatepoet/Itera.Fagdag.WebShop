using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class OrderCommandHandlers
    {
        private readonly AggregateRepository<Order> _repository;

        public OrderCommandHandlers(AggregateRepository<Order> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateOrder message)
        {
            var order = new Order(message.OrderId, message.CartId);

            _repository.Save(order, -1);
        }

        public void Handle(SelectBringPickupPoint message)
        {
            var order = _repository.GetById(message.OrderId);
            order.SelectBringPickupPoint(message.PickupPoint);

            _repository.Save(order, -1);
        }

        public void Handle(ConfirmPayButtonPayment message)
        {
            var order = _repository.GetById(message.OrderId);
            order.ConfirmPayButtonPayment(message.Token, new VerifyPayButtonPayment());

            _repository.Save(order, -1);
        }
    }
}