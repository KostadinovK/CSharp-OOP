using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Weapons.Scepters
{
    public class MagicScepter : Item
    {
        private const int strengthPoints = 5;
        private const int agilityPoints = 20;
        private const int energyPoints = 30;
        private const int staminaPoints = 20;

        public MagicScepter() : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
