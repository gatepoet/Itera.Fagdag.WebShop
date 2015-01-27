using System;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public interface IOrderReadModelFacade
    {
        OrderDto GetById(Guid id);
    }
}