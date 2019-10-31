using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Serialization
{
    public class JsonDotNet
    {
        public static void Use()
        {
            var model = new SimpleData
            {
                Id = 42,
                Names = new[] { "Bell", "Stacey", "her", "Jane" },
                Location = new NestedData
                {
                    LocationName = "London",
                    Latitude = 51.503209,
                    Longitude = -0.119145
                },
                Map = new Dictionary<string, int>
                {
                    { "Answer", 42 },
                    { "FirstPrime", 2 }
                }
            };

            string json = JsonConvert.SerializeObject(model, Formatting.Indented);
            Console.WriteLine(json);

            var deserialized = JsonConvert.DeserializeObject<SimpleData>(json);

            var jo = (JObject)JToken.Parse(json);
            Console.WriteLine(jo["Id"]);
            foreach (JToken name in jo["Names"])
            {
                Console.WriteLine(name);
            }
            foreach (JToken loc in jo["Location"])
            {
                Console.WriteLine(loc);
            }

            int id = jo["Id"].Value<int>();
            var names = (JArray)jo["Names"];
            string firstName = names[0].Value<string>();

            IEnumerable<JProperty> propsStartingWithLowerCase = jo.Descendants()
              .OfType<JProperty>()
              .Where(p => char.IsLower(p.Name[0]));
            foreach (JProperty p in propsStartingWithLowerCase)
            {
                Console.WriteLine(p);
            }
        }

            public class SimpleData
            {
                public int Id { get; set; }
                public IList<string> Names { get; set; }
                public NestedData Location { get; set; }
                public IDictionary<string, int> Map { get; set; }
            }

            public class NestedData
            {
                public string LocationName { get; set; }
                public double Latitude { get; set; }
                public double Longitude { get; set; }
        }
    }
}