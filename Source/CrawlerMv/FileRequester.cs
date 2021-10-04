using System.IO;

namespace CrawlerMv
{
    public class FileRequester : IRequester
    {
        private readonly string _folder;

        public FileRequester(string folder)
        {
            _folder = folder;
        }

        public byte[] RequestBytes(string url) => 
            File.ReadAllBytes(Path.Combine(_folder, url));

        public string RequestString(string url) => 
            File.ReadAllText(Path.Combine(_folder, url));
    }
}
