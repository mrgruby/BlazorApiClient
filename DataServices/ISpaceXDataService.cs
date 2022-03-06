using BlazorApiClient.Dtos;
using System.Threading.Tasks;

namespace BlazorApiClient.DataServices
{
    public interface ISpaceXDataService
    {
        Task<LaunchDto[]> GetAllLaunches();
    }
}
