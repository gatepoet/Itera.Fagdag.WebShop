using System;

namespace Itera.Fagdag.WebShop.Domain
{
    public class Command : Message
    {
    }

    #region User

    public class CreateUser : Command
    {
        public readonly Guid UserId;
        public readonly string Email;

        public CreateUser(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }

    #endregion


    #region Shopping cart

    public class CreateCart : Command
    {
        public readonly Guid CartId;

        public CreateCart(Guid cartId)
        {
            CartId = cartId;
        }
    }

    public class AddCartItem : Command
    {
        public readonly Guid CartId;
        public readonly int ProductId;
        public readonly int Count;
        public readonly int OriginalVersion;

        public AddCartItem(Guid cartId, int productId, int count, int originalVersion)
        {
            CartId = cartId;
            ProductId = productId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }

    public class RemoveCartItem : Command
    {
        public readonly Guid CartId;
        public readonly int ProductId;
        public readonly int Count;
        public readonly int OriginalVersion;

        public RemoveCartItem(Guid cartId, int productId, int count, int originalVersion)
        {
            CartId = cartId;
            ProductId = productId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }

    #endregion


    #region Favorites

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

    public class AddProductAvailabilityNotification : Command
    {
        public readonly int ProductId;
        public readonly string Email;

        public AddProductAvailabilityNotification(int productId, string email)
        {
            ProductId = productId;
            Email = email;
        }
    }

    public class RemoveProductAvailabilityNotification : Command
    {
        public readonly int ProductId;
        public readonly string Email;

        public RemoveProductAvailabilityNotification(int productId, string email)
        {
            ProductId = productId;
            Email = email;
        }
    }

    #endregion
}
