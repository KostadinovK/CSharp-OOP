using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3age, double tire4Pressure, int tire4age)
        {
            this.Model = model;
            this.Engine = new Engine(engineSpeed, enginePower);
            this.Cargo = new Cargo(cargoWeight, cargoType);
            this.Tires = new Tire[4];
            Tires[0] = new Tire(tire1Pressure, tire1Age);
            Tires[1] = new Tire(tire2Pressure, tire2Age);
            Tires[2] = new Tire(tire3Pressure, tire3age);
            Tires[3] = new Tire(tire4Pressure, tire4age);
        }
       
    }
}
