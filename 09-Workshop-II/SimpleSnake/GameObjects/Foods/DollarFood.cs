using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects.Foods
{
    public class DollarFood : Food
    {
        public DollarFood(Coordinate position) : base(GameConstants.DollarFood.Symbol, GameConstants.DollarFood.Points, position)
        {
        }
    }
}
