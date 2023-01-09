using System.Text.Json.Serialization;

namespace GetCountriesFromApi.Models
{
    public class Country
    {
        [JsonPropertyName("name")]
        public CountryName Name { get; set; }

         [JsonPropertyName("tld")]
         public string[] Tld { get; set; }

        [JsonPropertyName("cca2")]
        public string Cca2 { get; set; }

        [JsonPropertyName("ccn3")]
        public string Ccn3 { get; set; }

        [JsonPropertyName("cca3")]
        public string Cca3 { get; set; }

        [JsonPropertyName("cioc")]
        public string Cioc { get; set; }

        [JsonPropertyName("independent")]
        public bool? Independent { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("unMember")]
        public bool? UnMember { get; set; }

        [JsonPropertyName("curriences")]
        public Dictionary<string, Currency>? Currencies { get; set; }

        [JsonPropertyName("idd")]
        public Idd Idd { get; set; }

        [JsonPropertyName("altSpellings")]
        public string[] Capital { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("subregion")]
        public string Subregion { get; set; }

        [JsonPropertyName("translations")]
        public Dictionary<string, Translation> Translations { get; set; }

        [JsonPropertyName("latLng")]
        public double[] Latlng { get; set; }

        [JsonPropertyName("land-locked")]
        public bool Landlocked { get; set; }

        [JsonPropertyName("area")]
        public double? Area { get; set; }

        [JsonPropertyName("demonyms")]
        public Demonyms? Demonyms { get; set; }

        [JsonPropertyName("borders")]
        public string[] Borders { get; set; }

        [JsonPropertyName("flag")]
        public string UnicodeFlag { get; set; }

        [JsonPropertyName("maps")]
        public Maps Maps { get; set; }

        [JsonPropertyName("fifa")]
         public string? Fifa { get; set; }

        [JsonPropertyName("car")]

        public Car? Car { get; set; }

        [JsonPropertyName("continents")]
        public string[] Continents { get; set; }


        [JsonPropertyName("flags")]
        public Flag flag { get; set; }


        [JsonPropertyName("startOfWeek")]
        public string StartOfWeek { get; set; }



        [JsonPropertyName("capitalInfo")]
        public CapitalInfo CapitalInfo { get; set; }



        [JsonPropertyName("postalCode")]
        public PostalCode? PostalCode { get; set; }


        [JsonPropertyName("population")]
        public long Population { get; set; }

    }
}
