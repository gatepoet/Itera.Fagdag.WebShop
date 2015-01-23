using System;
using System.Web.Http;
using Itera.Fagdag.WebShop.Domain;

namespace Itera.Fagdag.WebShop.API.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/users/create/{email}")]
        public IHttpActionResult Create(string email)
        {
            ServiceLocator.Bus.Send(new CreateUser(Guid.NewGuid(), email));

            return Ok();
        }

        [Route("api/users/{id}/favorites/add/{productId}")]
        public IHttpActionResult AddToFavorites(Guid id, int productId)
        {
            ServiceLocator.Bus.Send(new AddToFavorites(id, productId));
            
            return Ok();
        }

        [Route("api/users/{id}/favorites/remove/{productId}")]
        public IHttpActionResult RemoveFromFavorites(Guid id, int productId)
        {
            ServiceLocator.Bus.Send(new AddToFavorites(id, productId));
            
            return Ok();
        }
    }
}