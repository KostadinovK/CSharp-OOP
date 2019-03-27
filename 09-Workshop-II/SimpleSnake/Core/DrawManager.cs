using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleSnake.GameObjects;
using SimpleSnake.Utilities;

namespace SimpleSnake.Core
{
    public class DrawManager : IDrawManager
    {
        public List<Coordinate> lastDrawnElements { get; set; }
        public DrawManager()
        {
            lastDrawnElements = new List<Coordinate>();
        }

        public void Draw(string symbol, IEnumerable<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (symbol == GameConstants.Snake.Symbol)
                {
                    lastDrawnElements.Add(new Coordinate(coordinate.CoordinateX, coordinate.CoordinateY));
                }

                Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);
                Console.Write(symbol);
            }
        }

        public void UndoDraw()
        {
            if (lastDrawnElements.Any())
            {
                Console.SetCursorPosition(lastDrawnElements.First().CoordinateX, lastDrawnElements.First().CoordinateY);
                Console.Write(" ");
                lastDrawnElements.Clear();
            }
        }
    }
}
