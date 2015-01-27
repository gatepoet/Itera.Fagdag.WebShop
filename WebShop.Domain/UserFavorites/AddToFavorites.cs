using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.UserFavorites
{
    public class AddToFavorites : Command
    {
        public readonly Guid UserId;
        public readonly int ProductId;

        public AddToFavorites(Guid userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }
}