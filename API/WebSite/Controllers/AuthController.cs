using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebSite.Domains;

namespace WebSite.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public AuthController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Auth(string login, string pass)
        {
            return _dbContext.UserDomain.Any(domain => domain.UserLogin == login && domain.UserPass == pass);
        }

        public UserDomain Registration(UserDomain user)
        {
            _dbContext.UserDomain.Add(user);
            _dbContext.SaveChanges();

            return user;
        }
    }
}
