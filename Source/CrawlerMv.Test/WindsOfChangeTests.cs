using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace CrawlerMv.Test
{
    [TestFixture]
    public class WindsOfChangeTests
    {
        [Test]
        public void Test1()
        {
            var client = new WebResourceClient();
            var requester = new WebResourceRequester(client, "http://windsofchangegame.com/");
            var cachedRequester = new CachingRequester(requester);
            var crawler = new Crawler(cachedRequester);
            var output = crawler.Crawl();

            var decoder = new Decoder();
            foreach (var map in output)
            {
                if (map?.Map == null)
                    continue;

                Console.WriteLine($"[Map {map.MapInfo.Id}]");
                foreach (var e in map.Map.Events.Where(ev => ev != null))
                {
                    if (e.Pages == null)
                        continue;

                    Console.WriteLine($"    [Event {e.Id}]");
                    for (var pageIndex = 0; pageIndex < e.Pages.Count; pageIndex++)
                    {
                        if (e.Pages[pageIndex] == null)
                            continue;

                        Console.WriteLine($"        [Page {pageIndex}]");
                        foreach (var c in e.Pages[pageIndex].List)
                        {
                            Console.WriteLine($"{string.Concat(decoder.Decode(c).Split('\n').Select(d => $"            {d}"))}");
                        }
                    }
                }
            }
        }
    }
}
