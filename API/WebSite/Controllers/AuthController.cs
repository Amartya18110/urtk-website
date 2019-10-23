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
        public bool Auth(UserDomain user)
        {
            return _dbContext.UserDomain.Any(domain => domain.UserLogin == user.UserLogin && domain.UserPass == user.UserPass);
        }

        [HttpPost]
        [Route("reg")]
        public UserDomain Registration(UserDomain user)
        {
            _dbContext.UserDomain.Add(user);
            _dbContext.SaveChanges();

            return user;
        }
    }
}
