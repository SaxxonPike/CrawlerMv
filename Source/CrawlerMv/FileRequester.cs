using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerMv
{
    public class FileRequester : IWebResourceRequester
    {
        private readonly string _folder;

        public FileRequester(string folder)
        {
            _folder = folder;
        }

        public byte[] RequestBytes(string url)
        {
            return File.ReadAllBytes(Path.Combine(_folder, url));
        }

        public string RequestString(string url)
        {
            return File.ReadAllText(Path.Combine(_folder, url));
        }
    }
}
