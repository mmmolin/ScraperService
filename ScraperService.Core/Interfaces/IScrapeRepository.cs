using ScraperService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperService.Core.Interfaces
{
    public interface IScrapeRepository
    {
        public List<ScrapeData> GetTheMorningDewData();
    }
}
