using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperService.Core.Entities
{
    public record ScrapeData
    {
        public ScrapeData(string title, string url)
        {
            Title = title;
            Url = url;
            Registered = DateTime.Now;
        }
        public string Title { get; init; }
        public string Url { get; init; }
        public DateTime Registered { get; init; }
    }
}
