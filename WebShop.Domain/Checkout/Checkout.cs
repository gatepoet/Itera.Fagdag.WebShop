using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;
using Itera.Fagdag.WebShop.Domain.Order;
using Itera.Fagdag.WebShop.Domain.ShoppingCart;

namespace Itera.Fagdag.WebShop.Domain.Checkout
{
    public class Checkout : Saga
    {
        private Guid _id;

        public override Guid Id
        {
            get { return _id; }
        }

        private void Apply(CartCheckedOut message)
        {
            _id = Guid.NewGuid();
            Send(new CreateOrder(_id, message.CartId));
        }
    }
}
