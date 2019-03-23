using System;
using System.Collections.Generic;
using System.Text;


public static class GemFactory
{
    public static Gem GetGem(string clarity, string type)
    {
        var clarityType = Type.GetType(clarity);
        Clarity clarityInstance = (Clarity)Activator.CreateInstance(clarityType);

        var typeOfGem = Type.GetType(type);
        Gem gem = (Gem) Activator.CreateInstance(typeOfGem, new object[] { clarityInstance });
        return gem;
    }
}
