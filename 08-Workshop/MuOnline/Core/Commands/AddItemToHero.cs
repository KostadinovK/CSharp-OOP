using MuOnline.Core.Commands.Contracts;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Models.Items.Contracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Core.Commands
{
    public class AddItemToHero : ICommand
    {
        private readonly IRepository<IItem> itemRepository;
        private readonly IRepository<IHero> heroRepository;
        public AddItemToHero(IRepository<IItem> itemRepository, IRepository<IHero> heroRepository)
        {
            this.itemRepository = itemRepository;
            this.heroRepository = heroRepository;
        }

        public string Execute(string[] inputArgs)
        {
            string itemType = inputArgs[0];
            string username = inputArgs[1];

            var item = itemRepository.Get(itemType);
            var hero = heroRepository.Get(username);

            hero.Inventory.AddItem(item);

            return $"Successfully added {item.GetType().Name} on {hero.GetType().Name} {username}!";
        }
    }
}
