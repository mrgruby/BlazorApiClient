using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApiClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient Http { get; set; }

        private LaunchDto[] launches;

        //Runs when the page loads
        protected override async Task OnInitializedAsync()
        {
            launches = await Http.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}
