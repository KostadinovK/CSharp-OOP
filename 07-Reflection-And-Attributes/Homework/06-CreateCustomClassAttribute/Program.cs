using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var type = typeof(Weapon);
        var attributes = type.GetCustomAttributes(false);

        foreach (var attr in attributes)
        {
            var authAttr = attr as AuthorAttribute;

            if (authAttr != null)
            {
                string command = Console.ReadLine();

                while (command != "END")
                {
                    switch (command)
                    {
                        case "Author":
                            Console.WriteLine($"Author: {authAttr.Author}");
                            break;
                        case "Revision":
                            Console.WriteLine($"Revision: {authAttr.Revision}");
                            break;
                        case "Description":
                            Console.WriteLine($"Class description: {authAttr.Description}");
                            break;
                        case "Reviewers":
                            Console.WriteLine($"Reviewers: {String.Join(", ", authAttr.Reviewers)}");
                            break;
                    }

                    command = Console.ReadLine();
                }
            }
        }
    }
}