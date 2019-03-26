using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomGloves : Item
    {
        private const int strength = 10;
        private const int agility = 20;
        private const int stamina = 10;
        private const int energy = 50;

        public DoomGloves() : base(strength, agility, stamina, energy)
        {
        }
    }
}
