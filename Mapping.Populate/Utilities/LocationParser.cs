using Mapping.Populate.Models;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mapping.Populate.Utilities
{
    internal static class LocationParser
    {
        public static IList<SearchLocation> ParseLocationsFromFlatFile() =>
            Json.Deserialize<IEnumerable<JsonLocation>>(
                File.ReadAllText(
                    Path.Combine(
                        Directory.GetCurrentDirectory(), 
                        "city_of_richmond.json"
                    )
                )
            ).Select<JsonLocation, SearchLocation>(l => l).ToList();
    }
}