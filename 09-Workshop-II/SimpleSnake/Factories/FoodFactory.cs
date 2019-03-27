using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.Factories
{
    public static class FoodFactory
    {
        private static Random random;

        static FoodFactory() {
            random = new Random();
        }

        public static Food Create()
        {
            var foodCoordinateX = random.Next(1, Console.LargestWindowWidth / 2);
            var foodCoordinateY = random.Next(1, Console.LargestWindowHeight / 2);

            Coordinate foodCoordinate = new Coordinate(foodCoordinateX, foodCoordinateY);

            var foodTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(Food))
                .ToList();

            int foodTypeIndex = random.Next(0, foodTypes.Count);

            var food = (Food)Activator.CreateInstance(foodTypes[foodTypeIndex], new object[]{foodCoordinate});

            return food;
        }
    }
}
