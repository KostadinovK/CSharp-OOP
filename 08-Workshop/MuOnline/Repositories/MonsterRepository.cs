using System;
using System.Collections.Generic;
using System.Linq;
using MuOnline.Models.Monsters;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Repositories
{
    public class MonsterRepository : IRepository<Monster>
    {
        private readonly List<Monster> monsterRepository;

        public MonsterRepository()
        {
            monsterRepository = new List<Monster>();
        }

        public IReadOnlyCollection<Monster> Repository => monsterRepository.AsReadOnly();
        public void Add(Monster monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            monsterRepository.Add(monster);
            Console.WriteLine($"Successfully added monster {monster}");
        }

        public bool Remove(Monster monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            bool isRemoved = this.monsterRepository.Remove(monster);

            return isRemoved;
        }

        public Monster Get(string monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            var targetItem = this.monsterRepository.FirstOrDefault(x => x.GetType().Name.ToLower() == monster.ToLower());

            if (targetItem == null)
            {
                throw new ArgumentException($"Item {monster} doesn't exist!");
            }

            return targetItem;
        }
    }
}
