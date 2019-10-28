using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebSite.Domains;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public AuthController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("")]
        public UserDomain Auth([FromBody]UserDomain user)
        {
            return _dbContext.UserDomain.FirstOrDefault(domain => domain.UserLogin == user.UserLogin && domain.UserPass == user.UserPass);
        }

        [HttpPost]
        [Route("reg")]
        public UserDomain Registration([FromBody]UserDomain user)
        {
            _dbContext.UserDomain.Add(user);
            _dbContext.SaveChanges();

            return user;
        }
    }
}
