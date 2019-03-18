using System;
using System.Collections.Generic;
using System.Text;


public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
    {
    }

    public override string Refuel(double liters)
    {
        base.Refuel(liters);

        return base.Refuel(liters);
    }
}
