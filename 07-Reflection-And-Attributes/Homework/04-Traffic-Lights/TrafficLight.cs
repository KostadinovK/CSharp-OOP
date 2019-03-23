using System;
using System.Collections.Generic;
using System.Text;

public class TrafficLight
{
    public string Color { get; set; }

    public TrafficLight(string color)
    {
        Color = color;
    }

    public void LightNextColor()
    {
        if (Color == "Red")
        {
            Color = "Green";
        }else if (Color == "Green")
        {
            Color = "Yellow";
        }else if (Color == "Yellow")
        {
            Color = "Red";
        }
    }

    public override string ToString()
    {
        return Color;
    }
}
