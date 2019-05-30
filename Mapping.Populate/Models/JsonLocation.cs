using Microsoft.Spatial;

namespace Mapping.Populate.Models
{
    internal class JsonLocation
    {
        public string Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }

        public static implicit operator SearchLocation(JsonLocation json)
        {
            return new SearchLocation
            {
                Id = json.Id,
                Point = GeographyPoint.Create(json.Latitude, json.Longitude),
                Address = json.Address
            };
        }
    }
}