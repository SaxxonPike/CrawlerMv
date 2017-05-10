using System;

namespace CrawlerMv
{
    public interface IWebResourceClient
    {
        byte[] DownloadData(Uri uri);
        string DownloadString(Uri uri);
    }
}