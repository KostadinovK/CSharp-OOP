
using System;
using System.Linq;
using System.Reflection;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        string line = Console.ReadLine();

        var type = typeof(BlackBoxInteger);
        var instance = (BlackBoxInteger)Activator.CreateInstance(type, true);
        var result = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
        while (line != "END")
        {
            string[] commandInfo = line.Split("_").ToArray();
            string command = commandInfo[0];
            int param = int.Parse(commandInfo[1]);

            var method = type.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(instance, new object[]{param});
            Console.WriteLine(result.GetValue(instance));

            line = Console.ReadLine();
        }
    }
}

