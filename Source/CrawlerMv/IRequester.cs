namespace CrawlerMv
{
    public interface IRequester
    {
        byte[] RequestBytes(string url);
        string RequestString(string url);
    }
}