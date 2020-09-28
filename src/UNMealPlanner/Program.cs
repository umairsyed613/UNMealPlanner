using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using Blazored.Modal;
using UNMealPlanner.Services;
using Blazored.Toast;

namespace UNMealPlanner
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var builder = WebAssemblyHostBuilder.CreateDefault(args);
                builder.RootComponents.Add<App>("app");
                builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
                builder.Services.AddBlazoredToast();
                builder.Services.AddBlazoredModal();
                builder.Services.AddBlazoredLocalStorage();
                builder.Services.AddScoped<IMealService, MealService>();
                await builder.Build().RunAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }
    }
}
