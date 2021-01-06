using Grpc.Core;
using ScraperService.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScraperService.Grpc.Services
{
    public class ScrapeService : Scrape.ScrapeBase
    {
        public override Task<ScrapeReply> RunService(ScrapeRequest request, ServerCallContext context)
        {
            return base.RunService(request, context);
        }
    }
}
