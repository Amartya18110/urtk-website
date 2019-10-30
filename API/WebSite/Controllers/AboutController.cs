using System.Linq;
using WebSite.Domains;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    [Route("about")]
    public class AboutController
    {
        private readonly DatabaseContext _context;

        public AboutController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("get")]
        public AboutDomain Get()
        {
            return _context.AboutDomains.FirstOrDefault();
        }

        [HttpPost]
        [Route("update")]
        public AboutDomain Update([FromBody]AboutDomain domain)
        {
            if (_context.AboutDomains.Count() == 0)
            {
                _context.Add(domain);
            }
            else
            {
                domain.Id = 1;
                _context.Update(domain);
            }

            _context.SaveChanges();
            return domain;
        }
    }
}
