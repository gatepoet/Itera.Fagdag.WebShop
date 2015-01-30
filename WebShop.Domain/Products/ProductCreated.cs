using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.Products
{
    public class ProductCreated : Event
    {
        public readonly int ProductId;

        public ProductCreated(int productId)
        {
            ProductId = productId;
        }
    }
}