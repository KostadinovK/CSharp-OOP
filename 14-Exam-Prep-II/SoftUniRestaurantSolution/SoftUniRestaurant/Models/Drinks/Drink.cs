using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    using Contracts;
    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }

                name = value;
            }
        }
        public int ServingSize
        {
            get => servingSize;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero");
                }

                servingSize = value;
            }
        }
        public decimal Price
        {
            get => price;
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero");
                }

                price = value;
            }
        }
        public string Brand
        {
            get => brand;
            private set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }

                brand = value;
            }
        }

        protected Drink(string name, int servingSize, decimal price, string brand)
        {
            Name = name;
            ServingSize = servingSize;
            Price = price;
            Brand = brand;
        }

        public override string ToString()
        {
            return $"{Name} {Brand} - {ServingSize}ml - {Price:f2}lv";
        }
    }
}
