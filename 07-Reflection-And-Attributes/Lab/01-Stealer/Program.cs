using System;

public class Program
{
    public static void Main()
    {
        Spy spy = new Spy();

        var res = spy.StealFieldInfo("Hacker", "username", "password");
        Console.WriteLine(res);
    }

}
