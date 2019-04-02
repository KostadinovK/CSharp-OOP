using System;
using System.Collections.Generic;
using System.Text;
using INStock.Contracts;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public string Label {
            get { return label; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Label cannot be null or empty!");
                }

                label = value;
            }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be zero or negative!");
                }

                price = value;
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity cannot be zero or negative!");
                }

                quantity = value;
            }
        }

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public int CompareTo(IProduct other)
        {
            return Label.CompareTo(other.Label);
        }
    }
}
