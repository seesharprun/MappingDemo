using Microsoft.Spatial;

namespace Mapping.Web.Models
{
    public class Location
    {
        public string Id { get; set; }

        public GeographyPoint Point { get; set; }

        public string Address { get; set; }
    }
}