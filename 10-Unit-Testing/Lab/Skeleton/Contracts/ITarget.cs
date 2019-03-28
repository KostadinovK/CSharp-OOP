using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface ITarget
    {
        int Health { get; }
        int Experience { get; }
        bool IsDead { get; }
        void TakeAttack(int attackPoints);
        int GiveExperience();
    }
}
