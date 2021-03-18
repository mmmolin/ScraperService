using HtmlAgilityPack;
using ScraperService.Core.Entities;
using ScraperService.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ScraperService.Infrastructure.Data
{
    public class ScrapeRepository : IScrapeRepository
    {
        private HtmlWeb web;
        public ScrapeRepository()
        {
            web = new HtmlWeb();
        }
        public List<ScrapeData> GetTheMorningDewData()
        {
            var url = @"https://www.alvinashcraft.com/";
            var htmlDoc = web.Load(url);
            var nodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='entry-content']/ul[1]/li/a[@href]");
            var scrapedData = new List<ScrapeData>();
            foreach (var node in nodes)
            {
                if (!String.IsNullOrEmpty(node.InnerText) && !String.IsNullOrEmpty(node.GetAttributeValue("href", String.Empty)))
                {
                    var data = new ScrapeData(node.InnerText, node.GetAttributeValue("href", String.Empty), DateTime.Now);
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
