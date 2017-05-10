namespace CrawlerMv
{
    public interface IWebResourceRequester
    {
        byte[] RequestBytes(string url);
        string RequestString(string url);
    }
}