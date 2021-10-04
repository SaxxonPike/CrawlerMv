using System;
using System.IO;

namespace CrawlerMv.Test
{
    public class ExportBaseTest
    {
        protected void ExportLocal(string path, string filename)
        {
            var requester = new FileRequester(path);
            var crawler = new Crawler(requester);
            var output = crawler.Crawl();
            var exporter = new Exporter();

            using (var mem = new MemoryStream())
            using (var textWriter = new StreamWriter(mem))
            {
                exporter.Export(output, textWriter);
                File.WriteAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename),
                    mem.ToArray());
            }
        }

        protected void ExportWeb(string url, string filename)
        {
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
                File.WriteAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename),
                    mem.ToArray());
            }
        }
    }
}