using System;
using System.Collections.Generic;
using System.Text;

public class MultiplicationStrategy : IStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand * secondOperand;
    }
}
