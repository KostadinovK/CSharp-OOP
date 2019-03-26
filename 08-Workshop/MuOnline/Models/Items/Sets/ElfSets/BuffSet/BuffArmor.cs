using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffArmor : Item
    {
        private const int strength = 20;
        private const int agility = 20;
        private const int stamina = 40;
        private const int energy = 0;

        public BuffArmor() : base(strength, agility, stamina, energy)
        {
        }
    }
}
