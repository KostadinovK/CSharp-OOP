using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.Utilities
{
    public static class GameConstants
    {
        public static class Engine
        {
            public const int ThreadSleepTimeHorizontalMovement = 80;
            public const int ThreadSleepTimeVerticalMovement = 120;
        }


        public static class Snake
        {
            public const string Symbol = "\u25CF";
            public const int DefaultLength = 6;
            public const int DefaultCoordinateX = 5;
            public const int DefaultCoordinateY = 6;
        }

        public static class AsterixFood
        {
            public const string Symbol = "*";
            public const int Points = 1;
        }
        public static class HashTagFood
        {
            public const string Symbol = "#";
            public const int Points = 3;
        }
        public static class DollarFood
        {
            public const string Symbol = "$";
            public const int Points = 5;
        }
    }
}
