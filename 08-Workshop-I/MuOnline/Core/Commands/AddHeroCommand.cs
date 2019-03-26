using MuOnline.Core.Commands.Contracts;
using MuOnline.Core.Factories;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Heroes;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Repositories;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Core.Commands
{
    public class AddHeroCommand : ICommand
    {
        private readonly IRepository<IHero> heroRepository;
        private readonly IHeroFactory heroFactory;

        public AddHeroCommand(IRepository<IHero> heroRepository, IHeroFactory heroFactory)
        {
            this.heroRepository = heroRepository;
            this.heroFactory = heroFactory;
        }

        public string Execute(string[] inputArgs)
        {
            string type = inputArgs[0];
            string username = inputArgs[1];

            var hero = heroFactory.Create(type, username);
            heroRepository.Add(hero);

            return $"Successfully created new {hero.GetType().Name}!";
        }
    }
}
