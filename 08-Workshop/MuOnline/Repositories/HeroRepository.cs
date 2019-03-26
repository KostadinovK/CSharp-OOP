using System;
using System.Collections.Generic;
using System.Linq;
using MuOnline.Models.Heroes;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Repositories
{
    public class HeroRepository : IRepository<Hero>
    {
        private readonly List<Hero> heroesRepository;

        public HeroRepository()
        {
            heroesRepository = new List<Hero>();
        }

        public IReadOnlyCollection<Hero> Repository => heroesRepository.AsReadOnly();

        public void Add(Hero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            heroesRepository.Add(hero);
            Console.WriteLine($"Successfully added hero {hero.Username}");
        }

        public Hero Get(string hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            var result = heroesRepository.FirstOrDefault(h => h.GetType().Name.ToLower() == hero.ToLower());

            if (result == null)
            {
                throw new ArgumentException($"No such hero {hero}!");
            }

            return result;
        }

        public Hero GetByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null!");
            }

            var result = heroesRepository.FirstOrDefault(h => h.Username == username);

            if (result == null)
            {
                throw new ArgumentNullException($"No hero with username {username} exist!");
            }

            return result;
        }

        public bool Remove(Hero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            return heroesRepository.Remove(hero);
        }
    }
}
