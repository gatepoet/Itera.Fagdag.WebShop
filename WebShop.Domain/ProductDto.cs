namespace Itera.Fagdag.WebShop.Domain
{
    public class ProductDto
    {

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
    }
}