using System;

namespace Itera.Fagdag.WebShop.Domain
{
    public class Command : Message
    {
    }

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

    public class AddToFavorites : Command
    {
        public readonly Guid UserId;
        public readonly Guid ProductId;

        public AddToFavorites(Guid productId, Guid userId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }

    public class RemoveFromFavorites : Command
    {
        public readonly Guid UserId;
        public readonly Guid ProductId;

        public RemoveFromFavorites(Guid productId, Guid userId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }

    public class NotifyWhenProductAvailable : Command
    {
        public readonly Guid ProductId;
        public readonly string Email;

        public NotifyWhenProductAvailable(Guid productId, string email)
        {
            ProductId = productId;
            Email = email;
        }
    }
}
