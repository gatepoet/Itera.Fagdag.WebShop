using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class BringPickupPointSelected : Event
    {
        public readonly Guid OrderId;
        public readonly string PickupPoint;

        public BringPickupPointSelected(Guid orderId, string pickupPoint)
        {
            OrderId = orderId;
            PickupPoint = pickupPoint;
        }
    }
}