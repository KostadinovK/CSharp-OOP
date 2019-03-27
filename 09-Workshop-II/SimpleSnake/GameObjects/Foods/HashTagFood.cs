using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    class HashTagFood : Food
    {
        private const string Symbol = "#";
        private const int Points = 3;

        public HashTagFood(Coordinate position) : base(Symbol, Points, position)
        {
        }
    }
}
