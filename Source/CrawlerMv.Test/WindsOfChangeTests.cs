using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CrawlerMv.Models;
using NUnit.Framework;

namespace CrawlerMv.Test
{
    [TestFixture]
    public class WindsOfChangeTests
    {
        private void Prettify(IEnumerable<CrawledItem> items, TextWriter writer)
        {
            var decoder = new Decoder();
            foreach (var map in items)
            {
                if (map?.Map == null)
                    continue;

                writer.WriteLine($"[Map {map.MapInfo.Id}]");
                foreach (var e in map.Map.Events.Where(ev => ev != null))
                {
                    if (e.Pages == null)
                        continue;

                    writer.WriteLine($"    [Event {e.Id}]");
                    for (var pageIndex = 0; pageIndex < e.Pages.Count; pageIndex++)
                    {
                        if (e.Pages[pageIndex] == null)
                            continue;

                        writer.WriteLine($"        [Page {pageIndex}]");
                        foreach (var c in e.Pages[pageIndex].List)
                        {
                            writer.WriteLine($"{string.Concat(decoder.Decode(c).Split('\n').Select(d => $"            {d}"))}");
                        }
                    }
                }
            }
            writer.Flush();
        }

        [Test]
        public void Test1()
        {
            //var client = new WebResourceClient();
            //var requester = new WebResourceRequester(client, "http://windsofchangegame.com/");
            //var cachedRequester = new CachingRequester(requester);
            var steamRequester = new FileRequester(@"C:\Program Files (x86)\Steam\steamapps\common\MajorMinorDefinitive\www");
            var crawler = new Crawler(steamRequester);
            var output = crawler.Crawl();

            using (var mem = new MemoryStream())
            using (var textWriter = new StreamWriter(mem))
            {
                Prettify(output, textWriter);
                File.WriteAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.txt"), mem.ToArray());
            }
        }
    }
}
