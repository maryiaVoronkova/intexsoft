using System.Text.Json.Serialization;

namespace CountriesTests.Models
{
    public class Country
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("capital")]
        public string? Capital { get; set; }
        [JsonPropertyName("region")]
        public string? Region { get; set; }
        [JsonPropertyName("borders")]
        public List<string>? Borders { get; set; }
        [JsonPropertyName("independent")]
        public bool Independent { get; set; }

        public static Country GetRusCountry()
        {
            return new Country
            {
                Name = "Russian Federation",
                Borders = new List<string> { "AZE", "BLR", "CHN", "EST", "FIN", "GEO", "KAZ", "PRK", "LVA", "LTU", "MNG", "NOR", "POL", "UKR" },
                Capital = "Moscow",
                Region = "Europe",
                Independent = true
            };
        }

        public override bool Equals(object? obj)
        {
            var country = obj as Country;

            return Name.Equals(country?.Name)
                && Borders.SequenceEqual(country?.Borders)
                && Capital.Equals(country?.Capital)
                && Region.Equals(country?.Region)
                && Independent == country?.Independent;
        }
    }
}
