using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string kingName = Console.ReadLine();
        string[] royalGuardNames = Console.ReadLine().Split().ToArray();
        string[] footmenNames = Console.ReadLine().Split().ToArray();

        King king = new King(kingName);
        List<IGuard> guards = new List<IGuard>();

        for (int i = 0; i < royalGuardNames.Length; i++)
        {
            RoyalGuard royalGuard = new RoyalGuard(royalGuardNames[i]);
            king.Attack += royalGuard.HandleKingsAttack;
            guards.Add(royalGuard);
        }

        for (int i = 0; i < footmenNames.Length; i++)
        {
            Footman footman = new Footman(footmenNames[i]);
            king.Attack += footman.HandleKingsAttack;
            guards.Add(footman);
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

                IGuard toRemove = guards.FirstOrDefault(g => g.Name == name);
                king.Attack -= toRemove.HandleKingsAttack;

                guards.Remove(toRemove);
            }

            command = Console.ReadLine();
        }
    }
}
