namespace Itera.Fagdag.WebShop.Domain
{
    public class ProductDto
    {

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public string ImageSource { get; set; }
        public string Category { get; set; }
    }
}