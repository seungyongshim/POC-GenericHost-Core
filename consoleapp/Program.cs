using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace consoleapp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder hostBuilder = Host
                .CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ActorSystem>(sp => Akka.Actor.ActorSystem.Create("Sample"));
                    services.AddHostedService<AkkaService>();
                })
                .UseWindowsService();

            await hostBuilder.Build().RunAsync();

        }
    }
}
