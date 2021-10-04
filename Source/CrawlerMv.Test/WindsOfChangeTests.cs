using System;
using System.IO;
using NUnit.Framework;

namespace CrawlerMv.Test
{
    [TestFixture]
    public class WindsOfChangeTests
    {
        [Test]
        [TestCase("http://windsofchangegame.com/", "winds-of-change.txt")]
        [Explicit("This makes web requests. Use at your own discretion.")]
        public void Export_WindsOfChange_Web(string url, string filename)
        {
            /*
             * Something you should know about this particular testcase: it was designed to crawl the Winds of Change
             * demo located at http://windsofchangegame.com. The site hasn't existed for a couple years since the game
             * came out, and the whole thing runs on RenPy now which makes this test worthless. Nonetheless, this test
             * is preserved. The demo no longer exists.
             *
             * If you find an offline version of the Winds of Change demo, delete the first three lines and replace
             * them with this one, replacing "path" with the local path your copy is located:
             *
             * var requester = new FileRequester(path);
             */
            var client = new WebResourceClient();
            var requester = new WebRequester(client, url);
            var cachedRequester = new CachingRequester(requester);
            var crawler = new Crawler(cachedRequester);
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
