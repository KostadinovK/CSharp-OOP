using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
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

            sb.AppendLine($"{Color} Seat {Model}");
            sb.AppendLine("Engine start");
            sb.Append("Breaaak!");

            return sb.ToString();
        }
    }
}
