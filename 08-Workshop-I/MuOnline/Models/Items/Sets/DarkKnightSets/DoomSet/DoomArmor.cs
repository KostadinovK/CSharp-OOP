using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomArmor : Item
    {
        private const int strength = 20;
        private const int agility = 20;
        private const int stamina = 40;
        private const int energy = 0;

        public DoomArmor() : base(strength, agility, stamina, energy)
        {
        }
    }
}
