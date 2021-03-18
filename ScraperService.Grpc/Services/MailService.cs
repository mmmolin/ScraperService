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
    public class MailService : Mail.MailBase
    {
        private readonly IStorageRepository storageRepository;
        public MailService(IStorageRepository storageRepository)
        {
            this.storageRepository = storageRepository;
        }
        public override Task<MailReply> GetMail(MailRequest request, ServerCallContext context)
        {
            var mailReply = new MailReply();

            try
            {
                List<Core.Entities.ScrapeData> links = storageRepository.GetDailyData();
                if(CollectionHasData(links))
                {
                    var linkReply = links.Select(x => new ScrapeDataReply { Title = x.Title, Url = x.Url });
                    mailReply.Links.Add(linkReply);
                }
            }
            catch
            {
                //Log exception
            }

            return Task.FromResult(mailReply);
        }

        private bool CollectionHasData<T>(IEnumerable<T> collection)
        {
            return collection != null && collection.Any();
        }
    }
}
