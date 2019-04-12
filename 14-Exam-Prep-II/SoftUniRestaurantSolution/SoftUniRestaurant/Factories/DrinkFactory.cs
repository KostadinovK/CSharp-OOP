using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Factories.Contracts
{
    public class DrinkFactory : IDrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            var drinkType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (drinkType == null)
            {
                throw new ArgumentException("Invalid drink type");
            }

            var drinkInstance = (IDrink)Activator.CreateInstance(drinkType, name, servingSize, brand);
            return drinkInstance;
        }
    }
}
