using System;


public class Program
{
    public static void Main()
    {
        Spy spy = new Spy();

        string res = spy.RevealPrivateMethods("Hacker");
        Console.WriteLine(res);
    }
}

