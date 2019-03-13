using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Smartphone : ICallable, IBrowsable
{
    public string Call(string phone)
    {
        if (!phone.Any(Char.IsDigit))
        {
            return "Invalid number!";
        }

        return $"Calling... {phone}";
    }

    public string Browse(string website)
    {
        if (website.Any(Char.IsDigit))
        {
            return "Invalid URL!";
        }

        return $"Browsing: {website}!";
    }
}
