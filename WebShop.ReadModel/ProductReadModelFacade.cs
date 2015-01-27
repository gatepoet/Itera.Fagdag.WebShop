using System.Linq;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public class ProductReadModelFacade : IProductReadModelFacade
    {
        public ProductDto[] GetAll()
        {
            return ProductDatabase.Products.ToArray();
        }

        public ProductDto GetById(int id)
        {
            return ProductDatabase.Products.Single(p => p.Id == id);
        }

        public ProductDto[] GetByCategory(string category)
        {
            return ProductDatabase.Products.Where(x => x.Category == category).ToArray();
        }
        public ProductDto[] GetByBrand(string brand)
        {
            return ProductDatabase.Products.Where(x => x.Brand == brand).ToArray();
        }
    }
}