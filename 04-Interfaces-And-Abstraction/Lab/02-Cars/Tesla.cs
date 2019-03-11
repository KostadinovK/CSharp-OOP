using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Tesla : ICar, IElectricCar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public int Battery { get; set; }

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Start()
        {
            throw new NotImplementedException();
        }

        public string Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine("Engine start");
            sb.Append("Breaaak!");

            return sb.ToString();
        }
    }
}
