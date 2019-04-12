
using System;

namespace SoftUniRestaurant.Models.Foods
{
    using Contracts;

    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

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

        protected Food(string name, int servingSize, decimal price)
        {
            Name = name;
            ServingSize = servingSize;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}: {ServingSize}g - {Price:f2}";
        }
    }
}
