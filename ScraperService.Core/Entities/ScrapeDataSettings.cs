using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperService.Core.Entities
{
    public class ScrapeDataSettings
    {
        public string Url { get; set; }
        public string TargetNode { get; set; }
        public string AttributeName { get; set; }
    }
}
