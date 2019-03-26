using MuOnline.Core.Commands.Contracts;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Monsters.Contracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Core.Commands
{
    public class AddMonsterCommand : ICommand
    {
        private readonly IRepository<IMonster> monsterRepository;
        private readonly IMonsterFactory monsterFactory;

        public AddMonsterCommand(IRepository<IMonster> monsterRepository, IMonsterFactory monsterFactory)
        {
            this.monsterRepository = monsterRepository;
            this.monsterFactory = monsterFactory;
        }

        public string Execute(string[] inputArgs)
        {
            var type = inputArgs[0];

            var monster = monsterFactory.Create(type);
            monsterRepository.Add(monster);

            return $"Successfully created new {monster.GetType().Name}!";
        }
    }
}
