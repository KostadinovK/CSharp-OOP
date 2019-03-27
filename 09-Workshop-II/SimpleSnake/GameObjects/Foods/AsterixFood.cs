using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects.Foods
{
    public class AsterixFood : Food
    {

        public AsterixFood(Coordinate position) : base(GameConstants.AsterixFood.Symbol, GameConstants.AsterixFood.Points, position)
        {

        }
    }
}
