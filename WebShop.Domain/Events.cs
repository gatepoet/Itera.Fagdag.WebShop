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
        public readonly string Email;

        public UserCreated(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
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
        public readonly int ProductId;

        public AddedToFavorites(Guid userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }

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

    public class AddedProductAvailabilityNotification : Event
    {
        public readonly Guid ProductId;
        public readonly string Email;

        public AddedProductAvailabilityNotification(Guid productId, string email)
        {
            ProductId = productId;
            Email = email;
        }
    }

    public class RemovedProductAvailabilityNotification : Event
    {
        public readonly Guid ProductId;
        public readonly string Email;

        public RemovedProductAvailabilityNotification(Guid productId, string email)
        {
            ProductId = productId;
            Email = email;
        }
    }

    public class ProductCreated : Event
    {
        public readonly int ProductId;

        public ProductCreated(int productId)
        {
            ProductId = productId;
        }
    }

    #endregion
}

