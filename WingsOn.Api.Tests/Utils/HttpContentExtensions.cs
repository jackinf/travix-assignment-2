using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WingsOn.Api.Tests.Utils
{
    public static class HttpContentExtensions
    {
        public static async Task<T> DeserializeFromJson<T>(this HttpContent content)
        {
            using (var streamReader = new StreamReader(await content.ReadAsStreamAsync()))
            using (var reader = new JsonTextReader(streamReader))
                return new JsonSerializer().Deserialize<T>(reader);
        }
    }
}