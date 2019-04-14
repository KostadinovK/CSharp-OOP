using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Contracts
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;
        public bool DefenseMode { get; private set; }
        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            ToggleDefenseMode();
        }
        
        public void ToggleDefenseMode()
        {
            if (!DefenseMode)
            {
                DefenseMode = true;
                AttackPoints -= 40;
                DefensePoints += 30;
            }
            else
            {
                DefenseMode = false;
                AttackPoints += 40;
                DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string res = base.ToString();
            StringBuilder sb = new StringBuilder(res);

            if (DefenseMode)
            {
                sb.AppendLine(" *Defense: ON");
            }
            else
            {
                sb.AppendLine(" *Defense: OFF");
            }

            return sb.ToString().Trim();
        }
    }
}
