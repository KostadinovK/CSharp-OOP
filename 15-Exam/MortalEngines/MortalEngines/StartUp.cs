using System;
using Microsoft.Extensions.DependencyInjection;
using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using MortalEngines.Factories;
using MortalEngines.Factories.Contracts;
using MortalEngines.IO;
using MortalEngines.IO.Contracts;
using MortalEngines.Repositories;
using MortalEngines.Repositories.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider provider = ConfigureServices();

            var engine = new Engine(provider);

            engine.Run();
        }

        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection collection = new ServiceCollection();
            collection.AddTransient<IPilotFactory, PilotFactory>();
            collection.AddTransient<IMachineFactory, MachineFactory>();
            collection.AddSingleton<IPilotRepository, PilotRepository>();
            collection.AddSingleton<IMachineRepository, MachineRepository>();
            collection.AddTransient<IWriter, ConsoleWriter>();
            collection.AddTransient<IMachinesManager, MachinesManager>();

            return collection.BuildServiceProvider();
        }
    }
}