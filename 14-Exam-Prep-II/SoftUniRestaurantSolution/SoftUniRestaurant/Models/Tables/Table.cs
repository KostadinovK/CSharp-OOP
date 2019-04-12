using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;
   
        public int TableNumber { get; private set; }
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }

        public int NumberOfPeople { get; private set; }
        public decimal PricePerPerson { get; private set; }
        public bool IsReserved { get; private set; }
        public decimal Price => CalculatePrice();

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            foodOrders = new List<IFood>();
            drinkOrders = new List<IDrink>();
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            IsReserved = false;
            NumberOfPeople = 0;
        }

        public void Reserve(int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException("Cannot place zero or less people!");
            }

            if (!IsReserved)
            {
                IsReserved = true;
                NumberOfPeople = numberOfPeople;
            }
        }

        public void OrderFood(IFood food)
        {
            foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return foodOrders.Select(f => f.Price).Sum() + drinkOrders.Select(d => d.Price).Sum() + NumberOfPeople * PricePerPerson;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            IsReserved = false;
            NumberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}Table");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.Append($"Price per Person: {PricePerPerson}");

            return sb.ToString();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}Table");
            sb.AppendLine($"Number of people: {NumberOfPeople}");
            if (!foodOrders.Any())
            {
                sb.AppendLine("Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {foodOrders.Count}");
                foreach (var foodOrder in foodOrders)
                {
                    sb.AppendLine(foodOrder.ToString());
                }
            }

            if (!drinkOrders.Any())
            {
                sb.AppendLine("Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {drinkOrders.Count}");
                foreach (var drinkOrder in drinkOrders)
                {
                    sb.AppendLine(drinkOrder.ToString());
                }
            }
            return sb.ToString().Trim();
        }
        private decimal CalculatePrice()
        {
            decimal res = GetBill();
            return res + NumberOfPeople * PricePerPerson;
        }
    }
}
