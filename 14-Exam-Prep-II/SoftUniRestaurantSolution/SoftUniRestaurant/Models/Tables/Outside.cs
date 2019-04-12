using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    class Outside : Table
    {
        private const decimal InitialPricePerPerson = 3.50m;

        public Outside(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}
