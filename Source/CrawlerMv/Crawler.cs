using System.Collections.Generic;
using System.Linq;
using CrawlerMv.Models;

namespace CrawlerMv
{
    public class Crawler
    {
        private readonly IRequester _requester;

        public Crawler(IRequester requester)
        {
            _requester = requester;
        }

        public List<CrawledItem> Crawl()
        {
            return _requester.RequestJson<List<MapInfosItem>>("data/MapInfos.json")
                .Select(mi => new CrawledItem
                {
                    MapInfo = mi,
                    Map = mi?.Id != null && mi.Id.Value > 0
                        ? _requester.RequestJson<MapItem>($"data/Map{mi.Id:D3}.json")
                        : null
                })
                .ToList();

        }
    }
}
