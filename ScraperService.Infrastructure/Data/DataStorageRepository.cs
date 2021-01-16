using MongoDB.Driver;
using ScraperService.Core.Entities;
using ScraperService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<ScrapeData> newEntities = RemoveExistingData(entities);
            if(newEntities.Count() > 0)
            {
                collection.InsertMany(newEntities);
            }
        }

        private List<ScrapeData> RemoveExistingData(List<ScrapeData> entities)
        {
            var filteredEntities = new List<ScrapeData>();
            foreach (var entity in entities)
            {
                if(IsNewData(entity) && IsValidURL(entity))
                {
                    filteredEntities.Add(entity);
                }
            }

            return filteredEntities;
        }

        private bool IsNewData(ScrapeData entity)
        {
            var filter = Builders<ScrapeData>.Filter.Eq("Url", entity.Url);
            bool isNewData = collection.Find<ScrapeData>(filter).Limit(1).CountDocuments() == 0;
            return isNewData;
        }

        private bool IsValidURL(ScrapeData entity)
        {
            Uri uriResult;
            return Uri.TryCreate(entity.Url, UriKind.Absolute, out uriResult) &&
                uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
        }

        public List<ScrapeData> GetDailyData()
        {
            var filter = Builders<ScrapeData>.Filter.Gte("Registered", DateTime.Now.Date) &
                Builders<ScrapeData>.Filter.Lt("Registered", DateTime.Now.AddDays(1).Date);

            List<ScrapeData> entities = collection.Find(filter).ToList();

            return entities;
        }
    }
}
