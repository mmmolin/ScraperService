using ScraperService.Core.Entities;
using ScraperService.Infrastructure.Data;
using System;
using System.Collections.Generic;

namespace ScrapeService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ScrapeRepository();
            var data = service.GetTheMorningDewData();

            //var testData = new List<ScrapeData>()
            //{
            //    new ScrapeData("Test", "http://www.test.se", DateTime.Now)
            //};

            var storage = new DataStorageRepository(new MongoDB.Driver.MongoClient());
            storage.AddData(data);
            //var entities = storage.GetDailyData();
        }
    }
}
