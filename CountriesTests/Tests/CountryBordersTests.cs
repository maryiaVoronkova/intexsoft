using CountriesTests.Enums;
using CountriesTests.Models;
using CountriesTests.Serializer;
using NUnit.Framework;
using System.Net;

namespace CountriesTests.Tests
{
    [TestFixture]
    public class RusCountryBordersTests : BaseCountryBordersTest
    {
        private string RusCode => CountryCode.RUS.ToString();

        [Test]
        [Description("Verify that all counties from RUS borders contain RUS in their borders")]
        public void VerifyAllRusNeightboursContainRusTest()
        {
            var rusBorders = Client?.GetByCode(RusCode)?.Deserialize<Country>()?.Borders;

            foreach(var border in rusBorders)
            {
                var countryBorders = Client?.GetByCode(border)?.Deserialize<Country>()?.Borders;
                Assert.Multiple(() =>
                {
                    Assert.Contains(CountryCode.RUS.ToString(), countryBorders, 
                        $"Country {border} doesn't contain a border with {CountryCode.RUS}");   
                });
            }
        }

        [Test]
        [Description("Verify that RUS country data is valid")]
        public void VerifyRusCountryDataIsValidTest()
        {
            var response = Client?.GetByCode(RusCode);
            var actualStatusCode = response?.StatusCode;
            var country = response?.Deserialize<Country>();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, actualStatusCode,
                    $"Incorrect status code {actualStatusCode}, should be {HttpStatusCode.OK}");
                Assert.IsTrue(Country.GetRusCountry().Equals(country), $"Response country name is incorrect");
            });
        }

        [Test]
        [Description("Verify that request with lower and upper cases return valid data")]
        public void VerifySearchByLowerAndUpperCasesTest()
        {
            var incorrectCountry = "rus";

            var countryByLowerCase = Client?.GetByCode(incorrectCountry)?.Deserialize<Country>();
            var countryByUpperCase = Client?.GetByCode(RusCode)?.Deserialize<Country>();

            Assert.IsTrue(countryByLowerCase?.Equals(countryByUpperCase),
                "Requests by upper and lower case return unequal data");    
        }

        [Test]
        [Description("Verify response by incorrect country name parameter")]
        public void VerifyBadRequestIncorrectCountryTest()
        {
            var incorrectCountry = "abc";

            var statusCode = Client?.GetByCode(incorrectCountry)?.StatusCode;

            Assert.AreEqual(HttpStatusCode.NotFound, statusCode,
                $"Status code is incorrect {statusCode}, should be {HttpStatusCode.NotFound}");
        }
    }
}
