using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Database
{
    public class Database
    {
        public const int Capacity = 16;
        private int[] data = new int[Capacity];
        public int Count { get; private set; }

        public Database()
        {
            Count = 0;
        }

        public Database(params int[] arr)
        {
            if (arr.Length != Capacity)
            {
                throw new InvalidOperationException();
            }

            data = arr;
            Count = data.Length;
        }

        public void Add(int number)
        {
            if (Count == Capacity)
            {
                throw new InvalidOperationException();
            }

            data[Count] = number;
            Count++;
        }

        public int Remove()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            int toRemove = data[Count - 1];
            data[Count - 1] = 0;
            Count--;

            return toRemove;
        }

        public int[] Fetch()
        {
            int[] res = new int[Capacity];
            res = data;
            return res;
        }
    }
}
