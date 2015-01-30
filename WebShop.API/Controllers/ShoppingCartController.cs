using System;
using System.Web.Http;
using Itera.Fagdag.WebShop.Domain.ShoppingCart;
using Itera.Fagdag.WebShop.ReadModel;

namespace Itera.Fagdag.WebShop.API.Controllers
{
    public class ShoppingCartController : ApiController
    {
        private readonly IShoppingCartReadModelFacade _shoppingReadModel;

        public ShoppingCartController() : this(new ShoppingCartReadModelFacade()) { }

        public ShoppingCartController(IShoppingCartReadModelFacade shoppingReadModel)
        {
            _shoppingReadModel = shoppingReadModel;
        }

        [Route("api/shoppingCart/{id?}")]
        public ShoppingCartDto Get(Guid? id = null)
        {
            id = id ?? Guid.NewGuid();
            return _shoppingReadModel.GetById(id.Value)?? CreateCart(id.Value);
        }

        private ShoppingCartDto CreateCart(Guid id)
        {
            var command = new CreateCart(
                cartId: id);

            ServiceLocator.Bus.Send(command);
            return new ShoppingCartDto
            {
                Id = id,
                Items = new ShoppingCartItemDto[0]
            };
        }

        [HttpPost]
        [Route("api/shoppingCart/{id}/{version}/add/{productId}")]
        public IHttpActionResult AddToCart(
            Guid id,
            int version,
            int productId,
            int count = 1)
        {
            var command = new AddCartItem(
                cartId: id,
                productId: productId,
                count: count,
                originalVersion: version);

            ServiceLocator.Bus.Send(command);

            return Ok();
        }
        [HttpDelete]
        [Route("api/shoppingCart/{id}/{version}/remove/{productId}")]
        public IHttpActionResult RemoveFromCart(
            Guid id,
            int version,
            int productId,
            int? count = null)
        {
            count = count ?? 1;
            var command = new RemoveCartItem(
                cartId: id,
                productId: productId,
                count: count.Value,
                originalVersion: version);

            ServiceLocator.Bus.Send(command);

            return Ok();
        }
        [HttpPost]
        [Route("api/shoppingCart/{id}/{version}/checkout")]
        public IHttpActionResult Checkout(
            Guid id,
            int version)
        {
            var command = new CheckOutCart(
                cartId: id,
                originalVersion: version);

            ServiceLocator.Bus.Send(command);

            return Ok();
        }
    }
}