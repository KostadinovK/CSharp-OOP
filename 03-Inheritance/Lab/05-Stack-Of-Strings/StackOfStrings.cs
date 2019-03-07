using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Any();
        }

        public void AddRange(Stack<string> stack)
        {
            foreach (var str in stack)
            {
                this.Push(str);
            }
        }
    }
}
