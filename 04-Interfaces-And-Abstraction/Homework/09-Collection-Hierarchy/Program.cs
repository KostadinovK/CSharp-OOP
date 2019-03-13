using System;
using System.Linq;


public class Program
{
    public static void Main()
    {
        string[] strings = Console.ReadLine().Split().ToArray();

        int removeOperations = int.Parse(Console.ReadLine());

        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        foreach (var @string in strings)
        {
            Console.Write(addCollection.Add(@string) + " ");
        }

        Console.WriteLine();

        foreach (var @string in strings)
        {
            addRemoveCollection.Add(@string);
            Console.Write("0 ");
        }

        Console.WriteLine();

        foreach (var @string in strings)
        {
            myList.Add(@string);
            Console.Write("0 ");
        }

        Console.WriteLine();

        for (int i = 0; i < removeOperations; i++)
        {
            Console.Write(myList.Remove() + " ");
        }

        Console.WriteLine();

        for (int i = 0; i < removeOperations; i++)
        {
            Console.Write(addRemoveCollection.Remove() + " ");
        }

        Console.WriteLine();

       
    }
}
