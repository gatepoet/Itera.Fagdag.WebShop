namespace Itera.Fagdag.WebShop.ReadModel
{
    public interface IProductReadModelFacade
    {
        ProductDto[] GetAll();
        ProductDto GetById(int id);
        ProductDto[] GetByCategory(string category);
        ProductDto[] GetByBrand(string brand);
    }
}