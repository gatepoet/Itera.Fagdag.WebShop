using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain
{
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
}