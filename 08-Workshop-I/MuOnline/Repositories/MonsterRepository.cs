using System;
using System.Collections.Generic;
using System.Linq;
using MuOnline.Models.Monsters;
using MuOnline.Models.Monsters.Contracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Repositories
{
    public class MonsterRepository : IRepository<IMonster>
    {
        private readonly List<IMonster> monsterRepository;

        public MonsterRepository()
        {
            monsterRepository = new List<IMonster>();
        }

        public IReadOnlyCollection<IMonster> Repository => monsterRepository.AsReadOnly();
        public void Add(IMonster monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            monsterRepository.Add(monster);
        }

        public bool Remove(IMonster monster)
        {
            if (monster == null)
            {
                throw new ArgumentNullException("Monster cannot be null!");
            }

            bool isRemoved = this.monsterRepository.Remove(monster);

            return isRemoved;
        }

        public IMonster Get(string monster)
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
