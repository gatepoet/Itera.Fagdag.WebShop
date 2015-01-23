using System;
using System.Net.Sockets;
using System.Web.Http;
using System.Web.Http.Results;
using Itera.Fagdag.WebShop.Domain;

namespace Itera.Fagdag.WebShop.API.Controllers
{
    public class CartController : ApiController
    {
        private readonly IShoppingCartReadModelFacade _shoppingReadModel;

        public CartController() : this(new ShoppingCartReadModelFacade()) { }

        public CartController(IShoppingCartReadModelFacade shoppingReadModel)
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
    }
}