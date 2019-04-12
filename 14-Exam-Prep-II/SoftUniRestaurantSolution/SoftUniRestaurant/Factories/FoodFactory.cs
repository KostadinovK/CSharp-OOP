using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SoftUniRestaurant.Factories.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            var foodType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if(foodType == null)
            {
                throw new ArgumentException("Invalid food type");
            }

            var foodInstance = (IFood)Activator.CreateInstance(foodType, name, price);

            return foodInstance;
        }
    }
}
