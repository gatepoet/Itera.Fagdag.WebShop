using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class Order : AggregateRoot
    {
        private Guid _id;
        private Guid _cartId;
        private string _paymillToken;
        private string _pickupPoint;

        public override Guid Id
        {
            get { return _id; }
        }

        private void Apply(OrderCreated e)
        {
            _id = e.OrderId;
            _cartId = e.CartId;
        }

        private void Apply(BringPickupPointSelected e)
        {
            _pickupPoint = e.PickupPoint;
        }

        private void Apply(PayButtonPaymentConfirmed e)
        {
            _paymillToken = e.Token;
        }

        public void SelectBringPickupPoint(string pickupPoint)
        {
            ApplyChange(new BringPickupPointSelected(_id, pickupPoint));
        }

        public void ConfirmPayButtonPayment(string token, IVerifyPayButtonPayment validator)
        {
            validator.VerifyToken(token);
            ApplyChange(new PayButtonPaymentConfirmed(_id, token));
        }

        public Order() { }
        public Order(Guid id, Guid cartId)
        {
            ApplyChange(new OrderCreated(cartId, id));
        }
    }
}