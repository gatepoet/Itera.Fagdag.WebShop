using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.UserFavorites
{
    public class AddedToFavorites : Event
    {
        public readonly Guid UserId;
        public readonly int ProductId;

        public AddedToFavorites(Guid userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }
}