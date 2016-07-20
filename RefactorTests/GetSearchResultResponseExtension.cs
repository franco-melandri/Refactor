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

        public static GetSearchResultResponse FromJson(this string json)
        {
            var serialize = new JsonSerializer();
            using (var tw = new StringReader(json))
            {
                var response = serialize.Deserialize(tw, typeof(GetSearchResultResponse));
                return (GetSearchResultResponse)response;
            }
        }
    }
}