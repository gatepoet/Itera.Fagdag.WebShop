using System;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public interface IShoppingCartReadModelFacade
    {
        ShoppingCartDto[] GetAll();
        ShoppingCartDto GetById(Guid id);
    }
}