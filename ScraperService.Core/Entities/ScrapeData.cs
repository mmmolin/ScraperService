using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperService.Core.Entities
{
    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElements]
    public record ScrapeData
    {
        public ScrapeData(string title, string url, DateTime regDate)
        {
            Title = title;
            Url = url;
            Registered = regDate;
        }
        public string Title { get; init; }
        public string Url { get; init; }
        public DateTime Registered { get; init; }
    }
}
