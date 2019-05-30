using Microsoft.Azure.Search;
using Microsoft.Spatial;
using System.ComponentModel.DataAnnotations;

namespace Mapping.Populate.Models
{
    internal class SearchLocation
    {
        [Key]
        [IsFilterable, IsSearchable, IsSortable]
        public string Id { get; set; }

        [IsFilterable, IsSortable]
        public GeographyPoint Point { get; set; }

        [IsFilterable, IsSearchable, IsSortable]
        public string Address { get; set; }
    }
}