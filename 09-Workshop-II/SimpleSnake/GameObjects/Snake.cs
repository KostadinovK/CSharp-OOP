using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects.Foods;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private List<Coordinate> body;
        public Coordinate Head => body.Last();
        public IReadOnlyCollection<Coordinate> Body => this.body.AsReadOnly();

        public Direction Direction { get; set; }
        public string Symbol => GameConstants.Snake.Symbol;
        public int Length { get; private set; }

        public Snake()
        {
            body = new List<Coordinate>();
            Length = GameConstants.Snake.DefaultLength;
            InitializeBody();
            Direction = Direction.Right;
        }

        private void InitializeBody()
        {
            var coordinateX = GameConstants.Snake.DefaultCoordinateX;
            var coordinateY = GameConstants.Snake.DefaultCoordinateY;

            for (int i = 0; i <= Length; i++)
            {
                body.Add(new Coordinate(coordinateX, coordinateY));
                coordinateX++;
            }
        }

        public void Move()
        {
            var newHeadCoords = CalculateCoords(new Coordinate(Head.CoordinateX, Head.CoordinateY));
            body.Add(newHeadCoords);
            body.RemoveAt(0);
        }

        private Coordinate CalculateCoords(Coordinate head)
        {
            switch (Direction)
            {
                case Direction.Up:
                    head.CoordinateY--;
                    break;
                case Direction.Down:
                    head.CoordinateY++;
                    break;
                case Direction.Left:
                    head.CoordinateX--;
                    break;
                case Direction.Right:
                    head.CoordinateX++;
                    break;
            }

            return head;
        }

        public void Eat(Food food)
        {
            for (int i = 0;i < food.Points;i++)
            {
                var coordinates = new Coordinate(Head.CoordinateX, Head.CoordinateY);
                body.Add(CalculateCoords(coordinates));
                Length++;
            }
        }
    }
}
