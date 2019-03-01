using System;
using System.Collections.Generic;
using System.Text;
public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double GetSurface()
    {
        return 2 * length * width + 2 * length * height + 2 * width * height;
    }

    public double GetLateralSurface()
    {
        return 2 * length * height + 2 * width * height;
    }

    public double GetVolume()
    {
        return length * width * height;
    }
}

