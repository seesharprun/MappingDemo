using Mapping.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mapping.Web.Services
{
    interface ISearchService
    {
        Task<IEnumerable<Location>> GetLocationsForShapeAsync(Shape shape, int searchCount);
    }
}
