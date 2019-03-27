using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public interface IDrawManager
    {
        List<Coordinate> lastDrawnElements { get; set; }
        void Draw(string symbol, IEnumerable<Coordinate> coordinates);
        void UndoDraw();
    }
}
