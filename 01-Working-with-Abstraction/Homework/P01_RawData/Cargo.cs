using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }

        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }
    }
}
