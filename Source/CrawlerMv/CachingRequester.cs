using System;
using System.IO;

namespace CrawlerMv
{
    public class CachingRequester : IWebResourceRequester
    {
        private readonly IWebResourceRequester _webResourceRequester;
        private readonly Lazy<string> _path;

        public CachingRequester(IWebResourceRequester webResourceRequester)
        {
            _webResourceRequester = webResourceRequester;
            _path = new Lazy<string>(() =>
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "crawler"));
        }

        public byte[] RequestBytes(string url)
        {
            var actualPath = Path.Combine(_path.Value, url);
            if (File.Exists(actualPath))
                return File.ReadAllBytes(actualPath);

            var actualDirectory = Path.GetDirectoryName(actualPath);
            if (!Directory.Exists(actualDirectory))
                Directory.CreateDirectory(actualDirectory);

            var data = _webResourceRequester.RequestBytes(url);
            File.WriteAllBytes(actualPath, data);
            return data;
        }

        public string RequestString(string url)
        {
            var actualPath = Path.Combine(_path.Value, url);
            if (File.Exists(actualPath))
                return File.ReadAllText(actualPath);

            var actualDirectory = Path.GetDirectoryName(actualPath);
            if (!Directory.Exists(actualDirectory))
                Directory.CreateDirectory(actualDirectory);

            var data = _webResourceRequester.RequestString(url);
            File.WriteAllText(actualPath, data);
            return data;
        }
    }
}
