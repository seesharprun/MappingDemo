using System.Collections.Generic;

namespace Mapping.Web.Models
{
    public class PolygonGeometry
    {
        public string Type { get; set; }

        public List<List<List<decimal>>> Coordinates { get; set; }
    }
}