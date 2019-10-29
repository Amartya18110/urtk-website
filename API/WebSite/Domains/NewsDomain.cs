using System;

namespace WebSite.Domains
{
    public class NewsDomain
    {
        public int Id { get; set; }

        public string NewsName { get; set; }

        public string NewsShortText { get; set; }

        public string NewsFullText { get; set; }

        public string NewsImage { get; set; }

        public DateTime NewsCreateTime { get; set; } = DateTime.Now;
    }
}