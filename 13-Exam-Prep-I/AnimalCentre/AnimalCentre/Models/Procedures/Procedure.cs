using System;
using AnimalCentre.Models.Contracts;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> ProcedureHistory { get; set; }

        protected Procedure()
        {
            ProcedureHistory = new List<IAnimal>();
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder($"{GetType().Name}\n");
            foreach (var animal in ProcedureHistory)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
