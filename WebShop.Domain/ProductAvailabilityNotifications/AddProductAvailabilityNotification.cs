using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ProductAvailabilityNotifications
{
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
}