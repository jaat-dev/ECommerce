using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        public DefaultController()
        {
        }

        [HttpGet]
        public string Index()
        {
            return "Running ..";
        }
    }
}