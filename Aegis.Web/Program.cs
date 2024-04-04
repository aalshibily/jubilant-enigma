using Aegis.Core.Interfaces.Services;
using Aegis.Core.Services;
using Blazor.GoogleTagManager;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Aegis.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddGoogleTagManager("GTM-NPG996PR");

            builder.Services.AddSingleton<ToastNotificationService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient<IJokeService, JokeService>(client =>
            {
                client.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
            });


            await builder.Build().RunAsync();
        }
    }
}
