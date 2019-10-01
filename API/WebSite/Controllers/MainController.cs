using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("main")]
    public class MainController : ControllerBase
    {
        public MainController()
        {

        }

        [Route("test")]
        [HttpGet]
        public string HelloWorld()
        {
            return "HelloWorld";
        }
    }
}
