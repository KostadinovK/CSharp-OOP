using System;
using System.Collections.Generic;
using System.Text;

public class DivisionStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand / secondOperand;
    }
}
