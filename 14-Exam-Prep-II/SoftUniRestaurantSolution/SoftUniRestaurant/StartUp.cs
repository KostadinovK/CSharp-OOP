using SoftUniRestaurant.Core;
using SoftUniRestaurant.Core.Contracts;
using SoftUniRestaurant.Factories;
using SoftUniRestaurant.Factories.Contracts;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            IFoodFactory foodFactory = new FoodFactory();
            IDrinkFactory drinkFactory = new DrinkFactory();
            ITableFactory tableFactory = new TableFactory();

            IRestaurantController restaurantController = new RestaurantController(foodFactory, drinkFactory, tableFactory);
            IEngine engine = new Engine(restaurantController);

            engine.Run();
        }
    }
}
