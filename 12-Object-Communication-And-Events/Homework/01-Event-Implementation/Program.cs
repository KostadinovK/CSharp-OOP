using System;

public class Program
{
    public static void Main()
    {
        Dispatcher dispatcher = new Dispatcher();
        Handler handler = new Handler();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        string line = Console.ReadLine();

        while (line != "End")
        {
            dispatcher.Name = line;
            line = Console.ReadLine();
        }
    }
}
