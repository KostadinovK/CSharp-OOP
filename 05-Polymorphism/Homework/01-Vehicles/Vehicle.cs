using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle : IVehicle
{
    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }

    protected Vehicle(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public virtual string Drive(double distance)
    {
        if (FuelConsumption * distance > FuelQuantity)
        {
            return $"{GetType()} needs refueling";
        }

        FuelQuantity -= FuelConsumption * distance;

        return $"{GetType()} travelled {distance} km";
    }

    public virtual void Refuel(double liters)
    {
        FuelQuantity += liters;

    }

    public override string ToString()
    {
        return $"{GetType()}: {FuelQuantity:f2}";
    }
}
