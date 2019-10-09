using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebSite.Domains;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public NewsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("id")]
        [Route("GetNews")]
        public NewsDomain GetNews(int id)
        {
            var test = _dbContext.NewsDomain.FirstOrDefault(domain => domain.Id == id);
            return _dbContext.NewsDomain.FirstOrDefault(domain => domain.Id == id);
        }

        [HttpGet]
        [Route("GetNews")]
        public NewsDomain[] GetNews()
        {
            return _dbContext.NewsDomain.ToArray();
        }

        [HttpPost]
        [Route("AddNews")]
        public void AddNews(NewsDomain domain)
        {
            _dbContext.NewsDomain.Add(domain);

            _dbContext.SaveChanges();
        }
    }
}