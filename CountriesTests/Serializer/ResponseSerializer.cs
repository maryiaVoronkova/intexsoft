using RestSharp;
using System.Text.Json;

namespace CountriesTests.Serializer
{
    public static class ResponseSerializer
    {
        public static T? Deserialize<T>(this RestResponse response)
            where T : class
        {
            return response != null ? 
                JsonSerializer.Deserialize<T>(response?.Content) : default(T);
        }
    }
}
