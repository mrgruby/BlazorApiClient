using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorApiClient.DataServices;

namespace BlazorApiClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //Make HttpClient available with dependency injection
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["base_api_url"])});

            //Register concrete implementation of RestSpaceXDataService, using HTTP for dependency injection. 
            //When we inject httpClient in the data service, this will also give us an implementation of RestSpaceXDataService
            builder.Services.AddHttpClient<ISpaceXDataService, GraphQLSpaceXDataService>( s => s.BaseAddress = new Uri(builder.Configuration["base_api_url"]));
            //builder.Services.AddHttpClient<ISpaceXDataService, RestSpaceXDataService>( s => s.BaseAddress = new Uri(builder.Configuration["base_api_url"]));

            await builder.Build().RunAsync();
        }
    }
}