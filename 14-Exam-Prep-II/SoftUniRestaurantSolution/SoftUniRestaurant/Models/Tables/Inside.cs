using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public class Inside : Table
    {
        private const decimal InitialPricePerPerson = 2.50m;

        public Inside(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}
