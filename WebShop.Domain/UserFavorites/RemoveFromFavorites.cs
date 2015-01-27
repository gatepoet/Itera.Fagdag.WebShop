using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.UserFavorites
{
    public class RemoveFromFavorites : Command
    {
        public readonly Guid UserId;
        public readonly int ProductId;

        public RemoveFromFavorites(Guid userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }
}