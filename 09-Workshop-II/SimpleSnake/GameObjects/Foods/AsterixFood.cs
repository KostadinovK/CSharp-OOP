using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class AsterixFood : Food
    {
        private const string Symbol = "*";
        private const int Points = 1;

        public AsterixFood(Coordinate position) : base(Symbol, Points, position)
        {

        }
    }
}
