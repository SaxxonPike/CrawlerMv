using System;

namespace CrawlerMv
{
    public class WebRequester : IRequester
    {
        private readonly IWebResourceClient _webClient;
        private readonly Uri _baseUri;

        public WebRequester(IWebResourceClient webClient, string baseUrl)
        {
            _webClient = webClient;
            _baseUri = new Uri(baseUrl);
        }

        public byte[] RequestBytes(string url) => 
            _webClient.DownloadData(new Uri(_baseUri, url));

        public string RequestString(string url) => 
            _webClient.DownloadString(new Uri(_baseUri, url));
    }
}
