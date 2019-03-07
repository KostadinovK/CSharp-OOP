using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rand = new Random();

            int index = rand.Next(0, this.Count);

            string toRemove = this[index];
            this.Remove(toRemove);

            return toRemove;
        }
    }
}
