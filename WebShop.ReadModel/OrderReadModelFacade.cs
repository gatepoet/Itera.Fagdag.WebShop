using System;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public class OrderReadModelFacade : IOrderReadModelFacade
    {
        public OrderDto GetById(Guid id)
        {
            return OrderDatabase.Orders[id];
        }
    }
}