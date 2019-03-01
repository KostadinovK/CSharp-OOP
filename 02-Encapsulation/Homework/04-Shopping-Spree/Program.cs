using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, Person> persons = new Dictionary<string, Person>();
        Dictionary<string, Product> products = new Dictionary<string, Product>();

        string[] personsInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

        for (int i = 0; i < personsInfo.Length; i++)
        {
            string[] tokens = personsInfo[i].Split('=').ToArray();
            string name = tokens[0];
            double money = double.Parse(tokens[1]);
            try
            {
                persons.Add(name, new Person(name, money));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
           
        }

        string[] productsInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

        for (int i = 0; i < productsInfo.Length; i++)
        {
            string[] tokens = productsInfo[i].Split('=').ToArray();
            string name = tokens[0];
            double cost = double.Parse(tokens[1]);
            try
            {
                products.Add(name, new Product(name, cost));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            
        }

        string line = Console.ReadLine();

        while (line != "END")
        {
            string[] tokens = line.Split().ToArray();
            Person person = persons[tokens[0]];
            Product product = products[tokens[1]];

            Console.WriteLine(person.BuyProduct(product));

            line = Console.ReadLine();
        }

        foreach (var kvp in persons)
        {
            Console.WriteLine(kvp.Value);
        }
    }
}
