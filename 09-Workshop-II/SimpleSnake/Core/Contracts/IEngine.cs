using System;
using System.Collections.Generic;
using System.Text;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core.Contracts
{
    public interface IEngine
    {
        Snake Snake { get; }
        IDrawManager DrawManager { get; }

        void Run();
    }
}
