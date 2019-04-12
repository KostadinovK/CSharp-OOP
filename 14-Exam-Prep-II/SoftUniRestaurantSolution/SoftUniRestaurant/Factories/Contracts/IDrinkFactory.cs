using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Factories.Contracts
{
    public interface IDrinkFactory
    {
        IDrink CreateDrink(string type, string name, int servingSize, string brand);
    }
}
