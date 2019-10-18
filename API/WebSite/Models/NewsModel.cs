using WebSite.Domains;

namespace WebSite.Models
{
    public class NewsModel
    {
        public NewsDomain[] News { get; set; }

        public int TotalItemCount { get; set; }
    }
}
