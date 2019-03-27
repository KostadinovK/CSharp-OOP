using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : IFood
    {
        public Coordinate Position { get; set; }
        public string Symbol { get; }
        public int Points { get; }

        protected Food(string symbol, int points, Coordinate position)
        {
            Symbol = symbol;
            Position = position;
            Points = points;
        }
    }
}
