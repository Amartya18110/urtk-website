using System;

namespace WebSite.Domains
{
    public class DocumentDomain
    {
        public int Id { get; set; }

        public string DocumentName { get; set; }

        public string DocumentCaption { get; set; }

        public DateTime DocumentCreateTime { get; set; } = DateTime.Now;

        public string DocumentLink { get; set; }
    }
}
