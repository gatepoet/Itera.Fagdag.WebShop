using System;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.User
{
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
}