using System;
using System.Collections.Generic;
using System.Linq;

namespace Mapping.Web.Models
{
    public class Shape
    {
        public string Title { get; set; }

        public List<Point> Points { get; private set; }

        public static implicit operator Shape(Polygon polygon)
        {
            return new Shape
            {
                Title = polygon?.Geometry?.Type,
                Points = polygon?.Geometry?.Coordinates.SingleOrDefault()?.Select(sp => new Point { Longitude = sp.FirstOrDefault(), Latitude = sp.LastOrDefault() }).ToList()
            };
        }

        public override string ToString() =>
            $"POLYGON(({String.Join(", ", Points.Select(p => $"{p.Longitude} {p.Latitude}"))}))";
    }
}