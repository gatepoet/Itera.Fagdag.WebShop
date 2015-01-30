using Itera.Fagdag.WebShop.Domain.Infrastructure;
using Itera.Fagdag.WebShop.Domain.ShoppingCart;

namespace Itera.Fagdag.WebShop.Domain.Checkout
{
    public class CheckoutHandlers :
        Handles<CartCheckedOut>
    {
        private readonly SagaRepository<Checkout> _repository;

        public CheckoutHandlers(SagaRepository<Checkout> repository)
        {
            _repository = repository;
        }

        public void Handle(CartCheckedOut message)
        {
            var saga = new Checkout();
            saga.Transition(message);
            _repository.Save(saga, -1);
        }
    }
}