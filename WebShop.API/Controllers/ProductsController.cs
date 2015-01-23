using System.Web.Http;
using Itera.Fagdag.WebShop.Domain;

namespace Itera.Fagdag.WebShop.API.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductReadModelFacade _readModelFacade;

        public ProductsController() : this(new ProductReadModelFacade()) { }
        public ProductsController(IProductReadModelFacade readModelFacade)
        {
            _readModelFacade = readModelFacade;
        }

        [Route("api/products")]
        public ProductDto[] Get()
        {
            return _readModelFacade.GetAll();
        }

        [Route("api/products")]
        public ProductDto Get(int id)
        {
            return _readModelFacade.GetById(id);
        }


    }
}
