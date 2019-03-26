using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomHelmet : Item
    {
        private const int strength = 20;
        private const int agility = 10;
        private const int stamina = 30;
        private const int energy = 20;

        public DoomHelmet() : base(strength, agility, stamina, energy)
        {
        }
    }
}
