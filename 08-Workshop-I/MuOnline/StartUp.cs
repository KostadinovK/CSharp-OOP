using Microsoft.Extensions.DependencyInjection;
using MuOnline.Models.Heroes;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Models.Items;
using MuOnline.Models.Items.Contracts;
using MuOnline.Models.Monsters;
using MuOnline.Models.Monsters.Contracts;
using MuOnline.Repositories;
using MuOnline.Repositories.Contracts;

namespace MuOnline
{
    using System;
    using MuOnline.Core;
    using MuOnline.Core.Contracts;
    using System.ComponentModel.Design;
   
    using MuOnline.Core.Factories;
    using MuOnline.Core.Factories.Contracts;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();
            IEngine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IHeroFactory, HeroFactory>();
            serviceCollection.AddTransient<IItemFactory, ItemFactory>();
            serviceCollection.AddTransient<IMonsterFactory, MonsterFactory>();

            serviceCollection.AddSingleton<IRepository<IHero>, HeroRepository>();
            serviceCollection.AddSingleton<IRepository<IItem>, ItemRepository>();
            serviceCollection.AddSingleton<IRepository<IMonster>, MonsterRepository>();

            serviceCollection.AddSingleton<ICommandInterpreter, CommandInterpreter>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
