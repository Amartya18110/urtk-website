using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebSite.Domains;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public NewsController(DatabaseContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("id")]
        [Route("GetNews")]
        public NewsDomain GetNews(int id)
        {
            return _dbContext.NewsDomain.FirstOrDefault(domain => domain.Id == id);
        }

        [HttpGet]
        [Route("GetNews")]
        public NewsDomain[] GetNews(int? startIndex, int? pageSize)
        {
            return _dbContext.NewsDomain.Skip(startIndex.Value).Take(pageSize.Value).ToArray();
        }

        [HttpPost]
        [Route("AddNews")]
        public void AddNews(NewsDomain domain)
        {
            _dbContext.NewsDomain.Add(domain);

            _dbContext.SaveChanges();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("UploadImage")]
        public async Task<string> UploadImageAsync()
        {
            var file = HttpContext.Request.Form.Files.First();
            var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads\\img");
            if (file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return "uploads\\img\\" + fileName;
            }
            return null;
        }
    }
}