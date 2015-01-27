using System;
using System.Web.Http;
using Itera.Fagdag.WebShop.Domain.Order;
using Itera.Fagdag.WebShop.ReadModel;

namespace Itera.Fagdag.WebShop.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderReadModelFacade _readModel;

        public OrderController() : this(new OrderReadModelFacade()) { }

        public OrderController(IOrderReadModelFacade readModel)
        {
            _readModel = readModel;
        }

        [Route("api/order/{id?}")]
        public OrderDto Get(Guid id)
        {
            return _readModel.GetById(id);
        }

        [HttpPost]
        [Route("api/order/{id}/{version}/selectBringPickupPoint/{pickupPoint}")]
        public IHttpActionResult SelectBringPickupPoint(
            Guid id,
            int version,
            string pickupPoint)
        {
            var command = new SelectBringPickupPoint(
                orderId: id,
                pickupPoint: pickupPoint,
                originalVersion: version);

            ServiceLocator.Bus.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("api/order/{id}/{version}/confirmPayButtonPayment/{token}")]
        public IHttpActionResult ConfirmPayButtonPayment(
            Guid id,
            int version,
            string token)
        {
            var command = new ConfirmPayButtonPayment(
                orderId: id,
                token: token,
                originalVersion: version);

            ServiceLocator.Bus.Send(command);

            return Ok();
        }
    }
}