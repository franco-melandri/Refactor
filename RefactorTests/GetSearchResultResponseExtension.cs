using System.IO;
using fake;
using Newtonsoft.Json;

namespace RefactorTests
{
    public static class GetSearchResultResponseExtension
    {
        public static string ToJson(this GetSearchResultResponse response)
        {
            var serialize = new JsonSerializer();
            using (var tw = new StringWriter())
            {
                serialize.Serialize(tw, response);
                return tw.ToString();
            }
        }
    }
}