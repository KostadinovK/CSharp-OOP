using System;
using SimpleSnake.Core;
using SimpleSnake.Core.Contracts;
using SimpleSnake.GameObjects;

namespace SimpleSnake
{
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Snake snake = new Snake();
            IDrawManager drawManager = new DrawManager();
            IEngine engine = new Engine(snake, drawManager, new Coordinate(Console.LargestWindowWidth / 2, Console.LargestWindowHeight / 2));

            engine.Run();
        }
    }
}
