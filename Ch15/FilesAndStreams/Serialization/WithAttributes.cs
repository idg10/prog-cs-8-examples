using Newtonsoft.Json;

namespace Serialization
{
    public class WithAttributes
    {
        public class NestedData
        {
            [JsonProperty("locationName")]
            public string LocationName { get; set; }

            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            [JsonProperty("longitude")]
            public double Longitude { get; set; }
        }
    }
}
