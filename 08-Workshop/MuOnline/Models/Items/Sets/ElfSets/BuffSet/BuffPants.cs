﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffPants : Item
    {
        private const int strength = 20;
        private const int agility = 10;
        private const int stamina = 30;
        private const int energy = 20;

        public BuffPants() : base(strength, agility, stamina, energy)
        {
        }
    }
}
