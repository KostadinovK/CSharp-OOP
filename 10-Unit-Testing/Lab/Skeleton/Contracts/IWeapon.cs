using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Skeleton.Contracts
{
    public interface IWeapon
    {
        int AttackPoints { get; }
        int DurabilityPoints { get; }
        void Attack(ITarget target);
    }
}
