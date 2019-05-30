using Mapping.Populate.Models;
using Mapping.Populate.Utilities;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using MoreLinq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Index = Microsoft.Azure.Search.Models.Index;

namespace Mapping.Populate
{
    public class Program
    {
        private static readonly Configuration _configuration;

        static Program() => _configuration = ConfigurationManager.GetConfiguration();

        public static async Task Main(string[] args)
        {
            Console.WriteLine($"Account:   \t{_configuration?.Azure?.Search?.Account}");
            Console.WriteLine($"Index:     \t{_configuration?.Azure?.Search?.Index}");
            Console.WriteLine($"Key:       \t{_configuration?.Azure?.Search?.Key}");

            await Run(_configuration?.Azure?.Search);
        }

        private static async Task Run(AzureSearchConfiguration config)
        {
            var credentials = new SearchCredentials(config?.Key);

            using var serviceClient = new SearchServiceClient(config?.Account, credentials);

            Index index = new Index()
            {
                Name = config?.Index,
                Fields = FieldBuilder.BuildForType<SearchLocation>()
            };
            await serviceClient.Indexes.CreateOrUpdateAsync(index);
            Console.WriteLine($"Got Index {config?.Index}");

            using var indexClient = new SearchIndexClient(config?.Account, config?.Index, credentials);

            var locations = LocationParser.ParseLocationsFromFlatFile();

            int batchSize = 1000;
            foreach (var batch in locations.Batch(batchSize))
            {
                int start = locations.IndexOf(batch.First());
                Console.WriteLine($"Uploading documents {start + 1} to {start + batchSize}");
                var upload = IndexBatch.Upload(batch);
                await indexClient.Documents.IndexAsync(upload);
            }
        }
    }
}