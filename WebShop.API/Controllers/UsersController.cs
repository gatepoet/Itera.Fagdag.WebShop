using System;
using System.Web.Http;
using Itera.Fagdag.WebShop.Domain;

namespace Itera.Fagdag.WebShop.API.Controllers
{
    public class UsersController : ApiController
    {
        [Route("/api/users/{id}/favorites/add/{productId}")]
        public IHttpActionResult AddToFavorites(Guid id, int productId)
        {
            ServiceLocator.Bus.Send(new AddToFavorites(id, productId));
            
            return Ok();
        }
    }
}