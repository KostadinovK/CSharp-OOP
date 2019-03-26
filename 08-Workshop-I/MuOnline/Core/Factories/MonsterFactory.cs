using System;
using System.Linq;
using System.Reflection;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Monsters.Contracts;

namespace MuOnline.Core.Factories
{
    public class MonsterFactory : IMonsterFactory
    {
        public IMonster Create(string monsterType)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == monsterType.ToLower());

            if (type == null)
            {
                throw new ArgumentNullException("Invalid monster type!");
            }

            var monster = (IMonster)Activator.CreateInstance(type);

            return monster;
        }
    }
}
