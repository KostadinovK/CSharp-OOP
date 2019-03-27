using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;
using SimpleSnake.Factories;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Foods;
using SimpleSnake.Utilities;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
       
        public Snake Snake { get; }

        public Food Food { get; private set; }
        public IDrawManager DrawManager { get; }
        public Coordinate BoardCoordinate { get; private set; }
        public int Score { get; private set; }

        public Engine(Snake snake, IDrawManager drawManager, Coordinate boardCoordinate)
        {
            Snake = snake;
            DrawManager = drawManager;
            BoardCoordinate = boardCoordinate;
            InitializeBoard();
            Food = FoodFactory.Create();
            Score = 0;
        }

        public void Run()
        {
            
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ChangeSnakeDirection(Console.ReadKey());
                }

                DrawManager.Draw(Food.Symbol, new List<Coordinate>(){Food.Position});

                DrawManager.Draw(Snake.Symbol, Snake.Body);

                PlayerInfo();

                Snake.Move();
                DrawManager.UndoDraw();

                if (SnakeHasCollisionWithFood())
                {
                    Snake.Eat(Food);
                    Score += Food.Points;
                    Food = FoodFactory.Create();
                }

                if (SnakeHasCollisionWithBorder() || SnakeHasCollisionWithHerself())
                {
                    AskPlayerForRestart();
                }

                if (Snake.Direction == Direction.Left || Snake.Direction == Direction.Right)
                {
                    Thread.Sleep(GameConstants.Engine.ThreadSleepTimeHorizontalMovement);
                }
                else
                {
                    Thread.Sleep(GameConstants.Engine.ThreadSleepTimeVerticalMovement);
                }
            }
        }

        private bool SnakeHasCollisionWithHerself()
        {
            var body = Snake.Body.Reverse().Skip(1).ToList();

            foreach (var coordinate in body)
            {
                if (coordinate.Equals(Snake.Head))
                {
                    return true;
                }
            }

            return false;
        }

        private void PlayerInfo()
        {
            Console.SetCursorPosition(10, BoardCoordinate.CoordinateY);
            Console.Write("Game Score: " + Score);
        }

        private void AskPlayerForRestart()
        {
            int x = 45;
            int y = 20;

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Would you like to continue: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y/N");

            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private bool SnakeHasCollisionWithBorder()
        {
            bool hasLeftBorderCollision =
                Snake.Head.CoordinateY <= 0 || Snake.Head.CoordinateY >= BoardCoordinate.CoordinateY - 1;

            bool hasTopBorderCollision =
                Snake.Head.CoordinateX <= 0 || Snake.Head.CoordinateX >= BoardCoordinate.CoordinateX - 1;

            return hasTopBorderCollision || hasLeftBorderCollision;
        }

        private bool SnakeHasCollisionWithFood()
        {
            return Snake.Head.Equals(Food.Position);
        }

        private void ChangeSnakeDirection(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
               case ConsoleKey.DownArrow:
                   if (Snake.Direction != Direction.Up)
                   {
                       Snake.Direction = Direction.Down;
                   }
                   break;

                case ConsoleKey.UpArrow:
                    if (Snake.Direction != Direction.Down)
                    {
                        Snake.Direction = Direction.Up;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (Snake.Direction != Direction.Left)
                    {
                        Snake.Direction = Direction.Right;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (Snake.Direction != Direction.Right)
                    {
                        Snake.Direction = Direction.Left;
                    }
                    break;
            }
        }

        private void InitializeBoard()
        {
            InitializeHorizontalBorder(0);
            InitializeHorizontalBorder(BoardCoordinate.CoordinateY - 1);
            InitializeVerticalBorder(0);
            InitializeVerticalBorder(BoardCoordinate.CoordinateX - 1);

        }

        private void InitializeHorizontalBorder(int coordinateY)
        {
            for (int i = 0; i < BoardCoordinate.CoordinateX; i++)
            {
                DrawManager.Draw("\u25A0", new List<Coordinate>() { new Coordinate(i, coordinateY) });
            }
        }

        private void InitializeVerticalBorder(int coordinateX)
        {
            for (int i = 0; i < BoardCoordinate.CoordinateY; i++)
            {
                DrawManager.Draw("\u2588", new List<Coordinate>(){new Coordinate(coordinateX, i)});
            }
        }
    }
}
