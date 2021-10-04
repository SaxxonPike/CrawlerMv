using System;
using System.IO;

namespace CrawlerMv
{
    public class CachingRequester : IRequester
    {
        private readonly IRequester _requester;
        private readonly Lazy<string> _path;

        public CachingRequester(IRequester requester)
        {
            _requester = requester;
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

            var data = _requester.RequestBytes(url);
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

            var data = _requester.RequestString(url);
            File.WriteAllText(actualPath, data);
            return data;
        }
    }
}
