using System;
using System.Collections.Generic;
using System.Text;
using MuOnline.Core.Commands.Contracts;
using MuOnline.Models.Heroes;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Models.Monsters.Contracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Core.Commands
{
    public class AttackMonsterCommand : ICommand
    {
        private readonly IRepository<IHero> heroRepository;
        private readonly IRepository<IMonster> monsterRepository;

        public AttackMonsterCommand(IRepository<IHero> heroRepository, IRepository<IMonster> monsterRepository)
        {
            this.heroRepository = heroRepository;
            this.monsterRepository = monsterRepository;
        }

        public string Execute(string[] inputArgs)
        {
            string username = inputArgs[0];
            string monsterString = inputArgs[1];

            var hero = heroRepository.Get(username);
            var monster = monsterRepository.Get(monsterString);

            while (hero.IsAlive && monster.IsAlive)
            {
                var exp = monster.TakeDamage(hero.TotalAttackPoints);
                ((IProgress)hero).AddExperience(exp);

                hero.TakeDamage(monster.AttackPoints);
            }

            if (hero.IsAlive)
            {
                return $"{monster.GetType().Name} died!";
            }

            return $"{username} died!";
        }
    }
}
