using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebSite.Domains;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        [HttpGet]
        [Route("GetNew")]
        public NewsDomain GetNew(int id)
            =>_dbContext.NewsDomain.FirstOrDefault(domain => domain.Id == id);

        [HttpGet]
        [Route("GetNews")]
        public NewsDomain[] GetNews()
            => _dbContext.NewsDomain.Local.ToArray();

        [HttpPost]
        [Route("AddNew")]
        public void AddNew(NewsDomain domain)
            => _dbContext.NewsDomain.Add(domain);
    }
}
