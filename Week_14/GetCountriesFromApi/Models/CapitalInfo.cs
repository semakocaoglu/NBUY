using System.Text.Json.Serialization;

namespace GetCountriesFromApi.Models
{
    public class CapitalInfo
    {

        [JsonPropertyName("latLng")]
        public double[] Latlng { get; set; }
    }
}