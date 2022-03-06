using BlazorApiClient.Dtos;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApiClient.DataServices
{
    public class GraphQLSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpClient;

        public GraphQLSpaceXDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LaunchDto[]> GetAllLaunches()
        {
            var queryObject = new
            {
                query = @"{launches{id is_tentative mission_name launch_date_local}}",
                variables = new { }
            };

            var launchQuery = new StringContent(JsonSerializer.Serialize(queryObject), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("graphql", launchQuery);

            if (response.IsSuccessStatusCode)
            {
                var graphQlData = await JsonSerializer.DeserializeAsync<GqlData>(await response.Content.ReadAsStreamAsync());

                return graphQlData.Data.Launches;
            }
            return null;
        }
    }
}
