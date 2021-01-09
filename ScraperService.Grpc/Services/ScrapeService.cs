using Grpc.Core;
using ScraperService.Core.Entities;
using ScraperService.Core.Interfaces;
using ScraperService.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScraperService.Grpc.Services
{
    public class ScrapeService : Scrape.ScrapeBase
    {
        private readonly IScrapeRepository scrapeRepository;
        private readonly IStorageRepository storageRepository;
        public ScrapeService(IScrapeRepository scrapeRepository, IStorageRepository storageRepository)
        {
            this.scrapeRepository = scrapeRepository;
            this.storageRepository = storageRepository;
        }
        public override Task<ScrapeReply> RunService(ScrapeRequest request, ServerCallContext context)
        {
            try
            {
                List<ScrapeData> scrapedData = scrapeRepository.GetTheMorningDewData();
                // Guard clause, don't run if list is empty
                storageRepository.AddData(scrapedData);
            }
            catch
            {
                // Log
            }
            
            return base.RunService(request, context);
        }
    }
}
