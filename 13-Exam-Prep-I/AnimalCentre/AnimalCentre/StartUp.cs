using System;
using AnimalCentre.Core;
using AnimalCentre.Core.Contracts;
using AnimalCentre.Factories;
using AnimalCentre.Factories.Contracts;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            
            IEngine engine = new Engine(serviceProvider);

            engine.Run();
        }

        public static IServiceProvider ConfigureServices()
        {
            ServiceCollection collection = new ServiceCollection();

            collection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            collection.AddTransient<IAnimalFactory, AnimalFactory>();
            collection.AddSingleton<IAnimalCentre, Models.AnimalCentre>();
            collection.AddSingleton<Hotel>();

            return collection.BuildServiceProvider();
        }
    }
}
