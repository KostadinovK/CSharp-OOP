using System;
using System.Collections.Generic;
using System.Text;

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override string Drive(double distance)
    {
        base.FuelConsumption += 1.4;
        return base.Drive(distance);
    }

    public string DriveEmpty(double distance)
    {
        return base.Drive(distance);
    }
}
