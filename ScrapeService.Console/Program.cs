using ScraperService.Infrastructure.Data;
using System;

namespace ScrapeService.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ScrapeRepository();
            var test = service.GetTheMorningDewData();
            System.Console.ReadKey();
        }
    }
}
