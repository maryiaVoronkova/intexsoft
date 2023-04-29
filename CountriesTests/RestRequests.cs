using RestSharp;

namespace CountriesTests
{
    public static class RestRequests
    {
        public static RestResponse? GetByCode(this RestClient client, string code)
        {
            return GetByCodes(client, code);
        }

        public static RestResponse? GetByCodes(this RestClient client, string parameters)
        {
            var request = new RestRequest($"codes={parameters}");
            return client.ExecuteGet(request);
        }

        public static RestResponse? GetByCodes(this RestClient client, List<string> parameters)
        {
            return GetByCodes(client, string.Join(',', parameters));
        }
    }
}
