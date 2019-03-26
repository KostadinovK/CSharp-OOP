using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.SoulMasterSets.PosionSet
{
    public class PoisonGloves : Item
    {
        private const int strength = 20;
        private const int agility = 20;
        private const int stamina = 40;
        private const int energy = 0;

        public PoisonGloves() : base(strength, agility, stamina, energy)
        {
        }
    }
}
