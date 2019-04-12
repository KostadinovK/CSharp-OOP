using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Factories.Contracts
{
    public interface ITableFactory
    {
        ITable CreateTable(string type, int tableNumber, int capacity);
    }
}
