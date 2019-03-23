using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();

        string line = Console.ReadLine();

        while (line != "END")
        {
            string[] commandInfo = line.Split(";").ToArray();
            string command = commandInfo[0];

            var commandType = Type.GetType(command + "Command");

            var method = commandType.GetMethod("Execute");
            var arr = commandInfo.Skip(1).ToArray();
            var commandInstance = Activator.CreateInstance(commandType, new object[] {arr, weapons });
            method.Invoke(commandInstance, null);

            line = Console.ReadLine();
        }
    }
}
