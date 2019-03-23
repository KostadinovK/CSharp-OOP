using System;
using System.Collections.Generic;
using System.Text;


public interface IGem
{
    int Strength { get; set; }
    int Vitality { get; set; }
    int Agility { get; set; }

    Clarity Clarity { get; set; }
}
