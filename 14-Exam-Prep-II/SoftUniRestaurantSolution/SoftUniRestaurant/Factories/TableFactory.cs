using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SoftUniRestaurant.Factories.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Factories
{
    public class TableFactory : ITableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            var tableType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (tableType == null)
            {
               throw new ArgumentException("Invalid table type");
            }

            var tableInstance = (ITable)Activator.CreateInstance(tableType, tableNumber, capacity);

            return tableInstance;
        }
    }
}
