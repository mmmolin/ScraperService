using ScraperService.Infrastructure.Data;
using System;

namespace ScrapeService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //var service = new ScrapeRepository();
            //var data = service.GetTheMorningDewData();

            var storage = new DataStorageRepository(new MongoDB.Driver.MongoClient());
            //storage.AddData(data);
            var entities = storage.GetDailyData();


            System.Console.ReadKey();
        }
    }
}
