using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SimpleSnake.Core.Contracts;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private const int ThreadSleepTimeHorizontalMovement = 80;
        private const int ThreadSleepTimeVerticalMovement = 120;
        public Snake Snake { get; }
        public IDrawManager DrawManager { get; }

        public Engine(Snake snake, IDrawManager drawManager)
        {
            Snake = snake;
            DrawManager = drawManager;
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ChangeSnakeDirection(Console.ReadKey());
                }

                DrawManager.Draw(Snake.Symbol, Snake.Body);
                Snake.Move();
                DrawManager.UndoDraw();

                if (Snake.Direction == Direction.Left || Snake.Direction == Direction.Right)
                {
                    Thread.Sleep(ThreadSleepTimeHorizontalMovement);
                }
                else
                {
                    Thread.Sleep(ThreadSleepTimeVerticalMovement);
                }
            }
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
    }
}
