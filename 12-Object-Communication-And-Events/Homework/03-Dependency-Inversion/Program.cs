using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        PrimitiveCalculator calculator = new PrimitiveCalculator();

        string line = Console.ReadLine();

        while (line != "End")
        {
            string[] commandArgs = line.Split().ToArray();
            if (commandArgs[0] == "mode")
            {
                char @operator = commandArgs[1].ToCharArray()[0];
                calculator.ChangeStrategy(@operator);
            }
            else
            {
                int firstOperand = int.Parse(commandArgs[0]);
                int secondOperand = int.Parse(commandArgs[1]);

                Console.WriteLine(calculator.PerformCalculation(firstOperand, secondOperand));
            }

            line = Console.ReadLine();
        }
    }
}
