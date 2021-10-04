using System;
using System.IO;
using Newtonsoft.Json;

namespace CrawlerMv
{
    public static class RequesterExtensions
    {
        public static TObject RequestJson<TObject>(this IRequester requester, string url)
        {
            var deserializer = new JsonSerializer();
            var data = requester.RequestBytes(url);

            using (var mem = new MemoryStream(data))
            using (var streamReader = new StreamReader(mem))
            using (var reader = new JsonTextReader(streamReader))
            {
                try
                {
                    var result = deserializer.Deserialize<TObject>(reader);
                    return result;
                }
                catch (Exception e)
                {
                    throw new Exception($"Failed deserializing at line {reader.LineNumber} column {reader.LinePosition}.", e);
                }
            }
        }
    }
}
