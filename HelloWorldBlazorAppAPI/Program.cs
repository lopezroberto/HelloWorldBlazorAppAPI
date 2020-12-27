// https://www.learmoreseekmore.com/2020/10/blazor-webassembly-httpclient-approaches.html

using HelloWorldBlazorAppAPI.Clients;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldBlazorAppAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // 1. Register HttpClient Object Explicitly In DI(Dependency Injection Service)
            // By doing this last registered HttpClient will override all others(implemented with the same technique) previous line
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") });

            // 2. Named Client
            // Requires nuget package Microsoft.Extensions.Http
            builder.Services.AddHttpClient("JsonPlaceHolderOnTheFlyClient", client => {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            });

            // 3. Type Client
            builder.Services.AddHttpClient<JsonPlaceHolderTypeClient>(client =>
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            });

            // 4.HttpRequestMessage Object
            builder.Services.AddHttpClient();

            await builder.Build().RunAsync();
        }
    }
}
