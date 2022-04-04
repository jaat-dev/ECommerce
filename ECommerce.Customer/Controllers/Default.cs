using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Customer.Controllers
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