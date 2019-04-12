using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core.Contracts
{
    public interface IRestaurantController
    {
        string AddFood(string type, string name, decimal price);


        string AddDrink(string type, string name, int servingSize, string brand);

        string AddTable(string type, int tableNumber, int capacity);

        string ReserveTable(int numberOfPeople);

        string OrderFood(int tableNumber, string foodName);

        string OrderDrink(int tableNumber, string drinkName, string drinkBrand);

        string LeaveTable(int tableNumber);

        string GetFreeTablesInfo();

        string GetOccupiedTablesInfo();

        string GetSummary();
    }
}
