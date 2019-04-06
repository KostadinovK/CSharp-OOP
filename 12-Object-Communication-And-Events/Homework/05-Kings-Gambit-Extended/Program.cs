using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        GuardCollection guards = new GuardCollection();
        string kingName = Console.ReadLine();
        string[] royalGuards = Console.ReadLine().Split().ToArray();
        string[] footmen = Console.ReadLine().Split().ToArray();

        King king = new King(kingName);
        king.Attack += guards.HandleKingsAttack;

        for (int i = 0; i < royalGuards.Length; i++)
        {
            guards.AddGuard(new RoyalGuard(royalGuards[i]));
        }

        for (int i = 0; i < footmen.Length; i++)
        {
           guards.AddGuard(new Footman(footmen[i])); 
        }

        string command = Console.ReadLine();

        while (command != "End")
        {
            if (command == "Attack King")
            {
                king.IsAttacked();
            }
            else
            {
                string[] commandArgs = command.Split().ToArray();
                string name = commandArgs[1];

                guards.Kill(name);
            }

            command = Console.ReadLine();
        }
    }
}
