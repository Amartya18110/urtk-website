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
        public AboutDomain[] Get()
        {
            return _context.AboutDomains.ToArray();
        }

        [HttpPost]
        [Route("insert")]
        public AboutDomain Insert([FromBody]AboutDomain domain)
        {
            _context.Add(domain);
            _context.SaveChanges();

            return domain;
        }

        [HttpPost]
        [Route("update")]
        public AboutDomain Update([FromBody]AboutDomain domain)
        {
            _context.Update(domain);
            _context.SaveChanges();

            return domain;
        }
    }
}
