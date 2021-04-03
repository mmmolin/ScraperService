using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using ScraperService.Core.Entities;
using ScraperService.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ScraperService.Infrastructure.Data
{
    public class ScrapeRepository : IScrapeRepository
    {
        private readonly ScrapeDataSettings theMorningDewSettings;
        private HtmlWeb web;
        public ScrapeRepository(IOptionsSnapshot<ScrapeDataSettings> options)
        {
            theMorningDewSettings = options.Get("TheMorningDew");
            web = new HtmlWeb();
        }
        public List<ScrapeData> GetTheMorningDewData()
        {
            var url = theMorningDewSettings.Url;
            var htmlDoc = web.Load(url);
            var nodes = htmlDoc.DocumentNode.SelectNodes(theMorningDewSettings.TargetNode);
            var scrapedData = new List<ScrapeData>();
            foreach (var node in nodes)
            {
                if (!String.IsNullOrEmpty(node.InnerText) && !String.IsNullOrEmpty(node.GetAttributeValue(theMorningDewSettings.AttributeName, String.Empty)))
                {
                    var data = new ScrapeData(node.InnerText, node.GetAttributeValue(theMorningDewSettings.AttributeName, String.Empty), DateTime.Now);
                    scrapedData.Add(data);
                }
                else
                {
                    //log
                }
            }

            return scrapedData;
        }
    }
}
