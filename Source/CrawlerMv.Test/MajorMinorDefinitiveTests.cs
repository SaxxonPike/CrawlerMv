using System;
using System.IO;
using NUnit.Framework;

namespace CrawlerMv.Test
{
    [TestFixture]
    public class MajorMinorDefinitiveTests
    {
        [Test]
        [TestCase(@"C:\Program Files (x86)\Steam\steamapps\common\MajorMinorDefinitive\www", "major-minor-definitive.txt")]
        [Explicit("Assumes you have the game installed via Steam. Use at your own discretion.")]
        public void Export_MajorMinorDefinitive_Steam(string path, string filename)
        {
            /*
             * This operates on the "definitive edition" but should also work on the original release of the game.
             */
            var requester = new FileRequester(path);
            var crawler = new Crawler(requester);
            var output = crawler.Crawl();
            var exporter = new Exporter();

            using (var mem = new MemoryStream())
            using (var textWriter = new StreamWriter(mem))
            {
                exporter.Export(output, textWriter);
                File.WriteAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename), mem.ToArray());
            }
        }
    }
}