using System;
using System.Linq;
using System.Reflection;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Heroes.HeroContracts;

namespace MuOnline.Core.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string heroType, string username)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == heroType.ToLower());

            if (type == null)
            {
                throw new ArgumentNullException("Invalid hero type!");
            }

            var hero = (IHero)Activator.CreateInstance(type, new object[] {username});

            return hero;
        }
    }
}
