using System;
using System.Web.Http;
using Itera.Fagdag.WebShop.Domain.User;
using Itera.Fagdag.WebShop.Domain.UserFavorites;

namespace Itera.Fagdag.WebShop.API.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/user/login/{email}")]
        public Guid Login(string email)
        {
            return Guid.NewGuid();
        }

        [Route("api/user/create/{email}")]
        public IHttpActionResult Create(string email)
        {
            ServiceLocator.Bus.Send(new CreateUser(Guid.NewGuid(), email));

            return Ok();
        }

        [Route("api/user/{id}/favorites/add/{productId}")]
        public IHttpActionResult AddToFavorites(Guid id, int productId)
        {
            ServiceLocator.Bus.Send(new AddToFavorites(id, productId));
            
            return Ok();
        }

        [Route("api/user/{id}/favorites/remove/{productId}")]
        public IHttpActionResult RemoveFromFavorites(Guid id, int productId)
        {
            ServiceLocator.Bus.Send(new AddToFavorites(id, productId));
            
            return Ok();
        }
    }
}