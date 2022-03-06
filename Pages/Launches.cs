using BlazorApiClient.DataServices;
using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApiClient.Pages
{
    public partial class Launches
    {
        [Inject]
        ISpaceXDataService dataService { get; set; }

        private LaunchDto[] launches;

        //Runs when the page loads
        protected override async Task OnInitializedAsync()
        {
            launches = await dataService.GetAllLaunches();
        }
    }
}
