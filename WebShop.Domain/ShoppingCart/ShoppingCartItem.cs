namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class ShoppingCartItem
    {
        private readonly int _productId;
        private int _count;

        public int ProductId
        {
            get { return _productId; }
        }

        public bool IsEmpty { get { return _count == 0; } }

        public void Add(int count)
        {
            _count += count;
        }

        public void Remove(int count)
        {
            _count -= count;
            if (_count < 0) _count = 0;
        }

        public ShoppingCartItem(int productId)
        {
            _productId = productId;
        }
    }
}
