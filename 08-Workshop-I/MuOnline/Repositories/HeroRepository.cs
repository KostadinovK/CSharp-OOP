using System;
using System.Collections.Generic;
using System.Linq;
using MuOnline.Models.Heroes;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroesRepository;

        public HeroRepository()
        {
            heroesRepository = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Repository => heroesRepository.AsReadOnly();

        public void Add(IHero hero)
        {
            Hero h = (Hero) hero;
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            heroesRepository.Add(hero);
            
        }

        public IHero Get(string hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            var result = heroesRepository.FirstOrDefault(h => ((IIdentifiable)h).Username.ToLower() == hero.ToLower());

            if (result == null)
            {
                throw new ArgumentException($"No such hero {hero}!");
            }

            return result;
        }

        public bool Remove(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            return heroesRepository.Remove(hero);
        }
    }
}
