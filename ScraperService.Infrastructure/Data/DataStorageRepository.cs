using MongoDB.Driver;
using ScraperService.Core.Entities;
using ScraperService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperService.Infrastructure.Data
{
    public class DataStorageRepository : IStorageRepository
    {
        private IMongoClient client;
        public DataStorageRepository(IMongoClient client)
        {
            this.client = client;
        }
        public void AddData(List<ScrapeData> entities)
        {
            throw new NotImplementedException();
        }

        public List<ScrapeData> GetDailyData()
        {
            throw new NotImplementedException();
        }
    }
}
