using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebSite.Domains;
using WebSite.Models;

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

        [HttpGet]
        [Route("GetNews/{id}")]
        public NewsDomain GetNews(int id)
        {
            return _dbContext.NewsDomain.FirstOrDefault(domain => domain.Id == id);
        }

        [HttpGet]
        [Route("GetNews")]
        public NewsModel GetNews(int? page, int? pageSize)
        {
            var news = _dbContext.NewsDomain.OrderByDescending(domain => domain.Id).ToArray();
            return new NewsModel
            {
                News = news.Skip((page - 1) * pageSize ?? 0).Take(pageSize ?? news.Count()).ToArray(),
                TotalItemCount = news.Count()
            };
        }

        [HttpPost]
        [Route("AddNews")]
        public NewsDomain AddNews([FromBody]NewsDomain domain)
        {
            _dbContext.NewsDomain.Add(domain);

            _dbContext.SaveChanges();

            return domain;
        }

        [HttpPost]
        [Route("EditNews")]
        public NewsDomain EditNews([FromBody] NewsDomain domain)
        {
            _dbContext.Update(domain);
            _dbContext.SaveChanges();

            return domain;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Route("UploadImage")]
        public async Task<string> UploadImageAsync()
        {
            var file = HttpContext.Request.Form.Files.First();
            var uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads/img");
            if (file.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return "uploads/img/" + fileName;
            }
            return null;
        }
    }
}