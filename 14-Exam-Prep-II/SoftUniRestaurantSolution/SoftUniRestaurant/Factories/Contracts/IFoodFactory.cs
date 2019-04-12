using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Factories.Contracts
{
    public interface IFoodFactory
    {
        IFood CreateFood(string type, string name, decimal price);
    }
}
