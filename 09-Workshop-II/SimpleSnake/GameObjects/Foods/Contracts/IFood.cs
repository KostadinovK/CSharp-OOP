using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public interface IFood
    {
        Coordinate Position { get; set; }
        string Symbol { get; }
        int Points { get; }
    }
}
