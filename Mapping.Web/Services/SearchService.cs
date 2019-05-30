using Mapping.Web.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mapping.Web.Services
{
    public class SearchService : ISearchService
    {
        private readonly AzureSearchConfiguration _configuration;

        public SearchService(IOptions<Configuration> optionsConfiguration)
        {
            _configuration = optionsConfiguration?.Value?.Azure?.Search;
        }

        public async Task<IEnumerable<Location>> GetLocationsForShapeAsync(Shape shape, int searchCount = 10)
        {
            var credentials = new SearchCredentials(_configuration?.Key);

            using (var indexClient = new SearchIndexClient(_configuration?.Account, _configuration?.Index, credentials))
            {
                var parameters = new SearchParameters
                {
                    Filter = $"geo.intersects({nameof(Location.Point)}, geography'{shape}')",
                    Top = searchCount
                };
                var results = await indexClient.Documents.SearchAsync<Location>("*", parameters);
                return results.Results.Select(r => r.Document); //Purposefully returning first page
            }
        }
    }
}