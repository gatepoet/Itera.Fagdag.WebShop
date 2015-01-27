using System;
using System.Linq;

namespace Itera.Fagdag.WebShop.ReadModel
{




    #region Shopping cart

    public class ShoppingCartReadModelFacade : IShoppingCartReadModelFacade
    {
        public ShoppingCartDto[] GetAll()
        {
            return ShoppingCartDatabase.ShoppingCarts.Values.ToArray();
        }

        public ShoppingCartDto GetById(Guid id)
        {
            return ShoppingCartDatabase.ShoppingCarts.ContainsKey(id)
                ? ShoppingCartDatabase.ShoppingCarts[id]
                : null;
        }
    }

    #endregion


    #region Product

    #endregion

    #region User

    #endregion
}
