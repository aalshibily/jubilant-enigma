using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectFresh;
using ProjectFresh.Domain.Clients;
using ProjectFresh.Domain.Models.Joke;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddHttpClient<IJokeService, JokeService>(client =>
        {
            client.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
        });

        await builder.Build().RunAsync();
    }
}