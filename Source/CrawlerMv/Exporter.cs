using System.Collections.Generic;
using System.IO;
using System.Linq;
using CrawlerMv.Models;

namespace CrawlerMv
{
    public class Exporter
    {
        public void Export(IEnumerable<CrawledItem> items, TextWriter writer)
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
    }
}