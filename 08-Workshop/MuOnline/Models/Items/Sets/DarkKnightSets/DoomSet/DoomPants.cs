using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomPants : Item
    {
        private const int strength = 30;
        private const int agility = 10;
        private const int stamina = 20;
        private const int energy = 10;

        public DoomPants() : base(strength, agility, stamina, energy)
        {
        }
    }
}
