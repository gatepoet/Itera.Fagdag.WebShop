using System;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public string PickupPoint { get; set; }
        public string Token { get; set; }
        public bool PaymentComplete { get; set; }
    }
}