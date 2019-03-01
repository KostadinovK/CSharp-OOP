using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] pizzaName = Console.ReadLine().Split().ToArray();
        string[] doughInfo = Console.ReadLine().Split().ToArray();

        Pizza pizza = new Pizza(pizzaName[1]);

        try
        {
            Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
            pizza.Dough = dough;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(0);
        }

        string topping = Console.ReadLine();

        while (topping != "END")
        {
            string[] toppingInfo = topping.Split().ToArray();
            try
            {
                Topping t = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));

                pizza.AddTopping(t);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
           
            topping = Console.ReadLine();
        }

        Console.WriteLine(pizza);
    }
}
