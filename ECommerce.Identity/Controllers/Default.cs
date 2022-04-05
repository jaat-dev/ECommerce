using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Identity.Controllers
{
    [ApiController]
    [Route("/")]
    public class Default : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Running ..";
        }
    }
}