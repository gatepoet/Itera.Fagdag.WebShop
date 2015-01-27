using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.UserFavorites
{
    public class RemovedFromFavorites : Event
    {
        public readonly Guid UserId;
        public readonly int ProductId;

        public RemovedFromFavorites(Guid userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }
}