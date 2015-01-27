using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Itera.Fagdag.WebShop.Domain.Infrastructure;

namespace Itera.Fagdag.WebShop.Domain.ShoppingCart
{
    public class ShoppingCart : AggregateRoot
    {
        private Guid _id;
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();
        private bool _locked = false;

        public override Guid Id
        {
            get { return _id; }
        }

        private void Apply(CartCreated e)
        {
            _id = e.CartId;
        }

        private void Apply(CartItemAdded e)
        {
            var item = _items.SingleOrDefault(i => i.ProductId == e.ProductId);
            if (item == null)
            {
                item = new ShoppingCartItem(e.ProductId);
                _items.Add(item);
            }
            item.Add(e.Count);
        }

        private void Apply(CartItemRemoved e)
        {
            var item = _items.Single(i => i.ProductId == e.ProductId);
            item.Remove(e.Count);
            if (item.IsEmpty)
                _items.Remove(item);
        }

        private void Apply(CartCheckedOut e)
        {
            _locked = true;
        }

        public ShoppingCart() { }

        public ShoppingCart(Guid id)
        {
            ApplyChange(new CartCreated(id));
        }

        public void AddItem(int productId, int count)
        {
            Contract.Assert(!_locked, "Cart is locked.");
            ApplyChange(new CartItemAdded(_id, productId, count));
        }

        public void RemoveItem(int productId, int count)
        {
            Contract.Assert(!_locked, "Cart is locked.");
            ApplyChange(new CartItemRemoved(_id, productId, count));
        }

        public void Checkout()
        {
            ApplyChange(new CartCheckedOut(_id));
        }
    }
}