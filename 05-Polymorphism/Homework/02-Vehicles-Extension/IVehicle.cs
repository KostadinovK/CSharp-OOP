using System;
using System.Collections.Generic;
using System.Text;

public interface IVehicle
{
    double FuelQuantity { get; set; }
    double FuelConsumption { get; set; }
    double TankCapacity { get; set; }

    string Drive(double distance);
    string Refuel(double liters);
}
