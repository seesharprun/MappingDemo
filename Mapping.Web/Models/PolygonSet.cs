using System.Collections.Generic;

namespace Mapping.Web.Models
{
    public class PolygonSet
    {
        public string Type { get; set; }

        public List<Polygon> Features { get; set; }
    }
}