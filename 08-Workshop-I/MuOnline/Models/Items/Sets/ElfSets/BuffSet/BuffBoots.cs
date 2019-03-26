using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffBoots : Item
    {
        private const int strength = 10;
        private const int agility = 30;
        private const int stamina = 40;
        private const int energy = 10;

        public BuffBoots() : base(strength, agility, stamina, energy)
        {

        }
    }
}
