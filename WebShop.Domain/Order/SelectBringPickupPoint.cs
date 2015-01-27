using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Order
{
    public class SelectBringPickupPoint : Command
    {
        public readonly Guid OrderId;
        public readonly string PickupPoint;
        public readonly int OriginalVersion;

        public SelectBringPickupPoint(Guid orderId, string pickupPoint, int originalVersion)
        {
            OrderId = orderId;
            PickupPoint = pickupPoint;
            OriginalVersion = originalVersion;
        }
    }
}