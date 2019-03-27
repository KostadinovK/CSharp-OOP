using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.Core.Contracts
{
    public interface IEngine
    {
        Snake Snake { get; }
        Food Food { get; }
        IDrawManager DrawManager { get; }
        Coordinate BoardCoordinate { get; }
        int Score { get; }
        void Run();
    }
}
