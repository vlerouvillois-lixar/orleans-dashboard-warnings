using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;
using System.Threading.Tasks;
using OrleansTest2.Grains;

namespace OrleansTest2
{
    class Program
    {        
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseOrleans((ctx, builder) =>
                {
                    builder
                    .UseLocalhostClustering()
                    .UseDashboard(options =>
                    {
                        options.Port = 8888;
                    })
                    .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(FlightGrain).Assembly));
                })
                .RunConsoleAsync();
        }
    }
}
