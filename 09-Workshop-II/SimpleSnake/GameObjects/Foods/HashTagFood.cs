using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects.Foods
{
    class HashTagFood : Food
    {
        

        public HashTagFood(Coordinate position) : base(GameConstants.HashTagFood.Symbol, GameConstants.HashTagFood.Points, position)
        {
        }
    }
}
