using Itera.Fagdag.WebShop.Domain.Infrastructure;
using Itera.Fagdag.WebShop.Domain.Order;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public class OrderView :
        Handles<OrderCreated>,
        Handles<BringPickupPointSelected>,
        Handles<PayButtonPaymentConfirmed>
    {
        public void Handle(OrderCreated message)
        {
            OrderDatabase.Orders.Add(
                message.OrderId,
                new OrderDto
                {
                    Id = message.OrderId,
                    CartId = message.CartId
                });
        }

        public void Handle(BringPickupPointSelected message)
        {
            OrderDatabase.Orders[message.OrderId].PickupPoint = message.PickupPoint;
        }

        public void Handle(PayButtonPaymentConfirmed message)
        {
            var order = OrderDatabase.Orders[message.OrderId];
            order.Token = message.Token;
            order.PaymentComplete = true;
        }
    }
}