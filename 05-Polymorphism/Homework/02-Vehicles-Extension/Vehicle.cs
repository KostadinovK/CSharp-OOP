using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle : IVehicle
{
    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }
    public double TankCapacity { get; set; }

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;

        if (FuelQuantity >= tankCapacity)
        {
            FuelQuantity = 0;
        }

        TankCapacity = tankCapacity;
    }

    public virtual string Drive(double distance)
    {
        if (FuelConsumption * distance > FuelQuantity)
        {
            return $"{GetType().Name} needs refueling";
        }

        FuelQuantity -= FuelConsumption * distance;

        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual string Refuel(double liters)
    {
        if (liters <= 0)
        {
            return "Fuel must be a positive number";
        }

        if (FuelQuantity + liters > TankCapacity)
        {
            return $"Cannot fit {liters} fuel in the tank";
        }

        FuelQuantity += liters;

        return null;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
