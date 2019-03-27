using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class DollarFood : Food
    {
        private const string Symbol = "$";
        private const int Points = 5;
        public DollarFood(Coordinate position) : base(Symbol, Points, position)
        {
        }
    }
}
