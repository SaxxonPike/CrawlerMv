using System.Collections.Generic;
using System.Linq;
using CrawlerMv.Models;

namespace CrawlerMv
{
    public class Crawler
    {
        private readonly IWebResourceRequester _webResourceRequester;

        public Crawler(IWebResourceRequester webResourceRequester)
        {
            _webResourceRequester = webResourceRequester;
        }

        public List<CrawledItem> Crawl()
        {
            return _webResourceRequester.RequestJson<List<MapInfosItem>>("data/MapInfos.json")
                .Select(mi => new CrawledItem
                {
                    MapInfo = mi,
                    Map = mi?.Id != null && mi.Id.Value > 0
                        ? _webResourceRequester.RequestJson<MapItem>($"data/Map{mi.Id:D3}.json")
                        : null
                })
                .ToList();

        }
    }
}
