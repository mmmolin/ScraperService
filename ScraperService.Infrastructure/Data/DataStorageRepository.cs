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
        private IMongoDatabase database;
        private IMongoCollection<ScrapeData> collection;
        public DataStorageRepository(IMongoClient client)
        {
            this.client = client;
            database = this.client.GetDatabase("storage");
            collection = database.GetCollection<ScrapeData>("scrapedata");
        }
        public void AddData(List<ScrapeData> entities)
        {
            collection.InsertMany(entities);
        }

        public List<ScrapeData> GetDailyData()
        {
            //var filter = Builders<ScrapeData>.Filter.Eq("Registered", DateTime.Now.Date.ToString());
            var filter = Builders<ScrapeData>.Filter.Gte("Registered", DateTime.Now.Date) & 
                Builders<ScrapeData>.Filter.Lt("Registered", DateTime.Now.AddDays(1).Date);

            var entities = collection.Find(filter).ToList();

            return entities;
        }
    }
}
