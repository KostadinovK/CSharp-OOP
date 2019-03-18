using System;
using System.Collections.Generic;
using System.Text;


public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
    {
        FuelConsumption += 1.6;
    }

    public override void Refuel(double liters)
    {
        liters = liters * 95 / 100;
        base.Refuel(liters);
    }
}
