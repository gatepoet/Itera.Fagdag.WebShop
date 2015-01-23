using System;

namespace Itera.Fagdag.WebShop.Domain
{
    public class Event : Message
    {
        public int Version;
    }

    public class UserCreated : Event
    {
        public readonly Guid UserId;

        public UserCreated(Guid userId)
        {
            UserId = userId;
        }
    }

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
}

