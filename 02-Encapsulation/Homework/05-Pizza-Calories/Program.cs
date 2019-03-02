using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string pizzaName = Console.ReadLine().Split().ToArray()[1];
       

        try
        {
            string[] doughInfo = Console.ReadLine().Split().ToArray();

            string doughFlourType = doughInfo[1];
            string doughBakingTechnique = doughInfo[2];
            double doughWeight = double.Parse(doughInfo[3]);
            Dough dough = new Dough(doughFlourType, doughBakingTechnique, doughWeight);

            Pizza pizza = new Pizza(pizzaName, dough);

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] toppingInfo = line.Split().ToArray();

                string type = toppingInfo[1];
                double weight = double.Parse(toppingInfo[2]);

                Topping topping = new Topping(type, weight);

                pizza.AddTopping(topping);

                line = Console.ReadLine();
            }

            Console.WriteLine(pizza);

        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}
