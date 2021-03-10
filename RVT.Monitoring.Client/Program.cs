using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RVT.Monitoring.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RVT.Monitoring.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = Config.IDENTITY_HOST;
                options.ProviderOptions.ClientId = Config.CLIENT_ID_BLAZOR;
                options.ProviderOptions.ResponseType = "code";
               // options.ProviderOptions.DefaultScopes.Add("username");
                options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:5001/";

                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
               // builder.Configuration.Bind("Local", options.ProviderOptions);
            });

            await builder.Build().RunAsync();
        }
    }
}
