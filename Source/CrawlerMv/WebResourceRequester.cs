using System;

namespace CrawlerMv
{
    public class WebResourceRequester : IWebResourceRequester
    {
        private readonly IWebResourceClient _webClient;
        private readonly Uri _baseUri;

        public WebResourceRequester(IWebResourceClient webClient, string baseUrl)
        {
            _webClient = webClient;
            _baseUri = new Uri(baseUrl);
        }

        public byte[] RequestBytes(string url)
        {
            return _webClient.DownloadData(new Uri(_baseUri, url));
        }

        public string RequestString(string url)
        {
            return _webClient.DownloadString(new Uri(_baseUri, url));
        }
    }
}
