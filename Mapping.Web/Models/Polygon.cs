using System;

namespace Mapping.Web.Models
{
    public class Polygon
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public PolygonGeometry Geometry { get; set; }
    }
}