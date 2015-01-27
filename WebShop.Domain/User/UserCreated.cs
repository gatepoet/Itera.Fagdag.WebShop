using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.User
{
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
}