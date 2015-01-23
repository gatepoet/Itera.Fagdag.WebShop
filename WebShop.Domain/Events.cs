using System;

namespace Itera.Fagdag.WebShop.Domain
{
    public class Event : Message
    {
        public int Version;
    }

    #region User

    public class UserCreated : Event
    {
        public readonly Guid UserId;

        public UserCreated(Guid userId)
        {
            UserId = userId;
        }
    }

    #endregion

    #region Shopping cart

    public class CartCreated : Event
    {
        public readonly Guid CartId;

        public CartCreated(Guid cartId)
        {
            CartId = cartId;
        }
    }

    public class CartItemAdded : Event
    {
        public readonly Guid CartId;
        public readonly int ProductId;
        public readonly int Count;

        public CartItemAdded(Guid cartId, int productId, int count)
        {
            CartId = cartId;
            ProductId = productId;
            Count = count;
        }
    }

    public class CartItemRemoved : Event
    {
        public readonly Guid CartId;
        public readonly int ProductId;
        public readonly int Count;

        public CartItemRemoved(Guid cartId, int productId, int count)
        {
            CartId = cartId;
            ProductId = productId;
            Count = count;
        }
    }

    #endregion

    #region Favorites

    public class AddedToFavorites : Event
    {
        public readonly Guid UserId;
        public readonly Guid ProductId;

        public AddedToFavorites(Guid productId, Guid userId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }

    public class RemovedFromFavorites : Event
    {
        public readonly Guid UserId;
        public readonly Guid ProductId;

        public RemovedFromFavorites(Guid productId, Guid userId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }

    public class ProductAvailabilityNotificationAdded : Event
    {
        public readonly Guid ProductId;
        public readonly string Email;

        public ProductAvailabilityNotificationAdded(Guid productId, string email)
        {
            ProductId = productId;
            Email = email;
        }
    }

    #endregion
}

