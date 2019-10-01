using Microsoft.AspNetCore.Mvc;
using WebSite.Domains;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        public NewsController()
        {
        }

        [HttpGet]
        [Route("test")]
        public NewsDomain Test()
        {
            var test = new NewsDomain
            {
                NewsFullText = "sdfgjklsdfhg kujdfhg jkdfslhg jkdfsgh kjdfsg hjkdfsgh ",
                NewsName = "News 1",
                NewsShortText = "gsdfjkghdfskgj"
            };

            _dbContext.NewsDomain.Add(test);

            return test;
        }
    }
}
