using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;
        public bool AggressiveMode { get; private set; }

        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            ToggleAggressiveMode();
        }

        public void ToggleAggressiveMode()
        {
            if (!AggressiveMode)
            {
                AggressiveMode = true;
                AttackPoints += 50;
                DefensePoints -= 25;
            }
            else
            {
                AggressiveMode = false;
                AttackPoints -= 50;
                DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string res = base.ToString();
            StringBuilder sb = new StringBuilder(res);

            if (AggressiveMode)
            {
                sb.AppendLine(" *Aggressive: ON");
            }
            else
            {
                sb.AppendLine(" *Aggressive: OFF");
            }

            return sb.ToString().Trim();
        }
    }
}
