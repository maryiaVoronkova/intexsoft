using NUnit.Framework;
using RestSharp;

namespace CountriesTests.Tests
{
    public class BaseCountryBordersTest
    {
        protected RestClient? Client { get; set; }
        protected static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\TestData\borders.txt");

        [SetUp]
        public void InitializeConnection()
        {
            Client = new RestClient(TestData.EntriApiPoint);
        }
    }
}
