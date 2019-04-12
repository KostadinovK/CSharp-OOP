using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUniRestaurant.Core.Contracts;
using SoftUniRestaurant.Factories.Contracts;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Core
{
    using System;

    public class RestaurantController : IRestaurantController
    {
        private IFoodFactory foodFactory;
        private IDrinkFactory drinkFactory;
        private ITableFactory tableFactory;

        private readonly List<IFood> menu;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private decimal totalIncome;

        public RestaurantController(IFoodFactory foodFactory, IDrinkFactory drinkFactory, ITableFactory tableFactory)
        {
            menu = new List<IFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            this.foodFactory = foodFactory;
            this.drinkFactory = drinkFactory;
            this.tableFactory = tableFactory;
            totalIncome = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = foodFactory.CreateFood(type, name, price);
            menu.Add(food);

            return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = drinkFactory.CreateDrink(type, name, servingSize, brand);
            drinks.Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = tableFactory.CreateTable(type, tableNumber, capacity);
            tables.Add(table);

            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);
            totalIncome += numberOfPeople * table.PricePerPerson;
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var food = menu.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                throw new ArgumentException($"Could not find table with {tableNumber}");
            }

            if (food == null)
            {
                throw new ArgumentException($"No {foodName} in the menu");
            }

            table.OrderFood(food);
            totalIncome += food.Price;
            return $"Table {table.TableNumber} ordered {food.Name}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                throw new ArgumentException($"Could not find table with {tableNumber}");
            }

            if (drink == null)
            {
                throw new ArgumentException($"There is no {drinkName} {drinkBrand} available");
            }
            totalIncome += drink.Price;
            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            decimal bill = table.GetBill();
            table.Clear();

            return $"Table: {table.TableNumber}\n" +
                   $"Bill: {bill:f2}";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(t => t.IsReserved == false);

            StringBuilder sb = new StringBuilder();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTables = tables.Where(t => t.IsReserved);

            StringBuilder sb = new StringBuilder();
            foreach (var table in occupiedTables)
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            return $"Total income: {totalIncome:f2}lv";
        }
    }
}
