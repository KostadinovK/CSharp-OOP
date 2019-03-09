using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public string Title {
        get => title;
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }

    public string Author
    {
        get => author;
        set
        {
            int index = value.IndexOf(' ');

            if (Char.IsDigit(value[index + 1]))
            {
                throw new ArgumentException("Author not valid!");
            }

            author = value;
        }
    }

    public decimal Price
    {
        get => price;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {GetType()}");
        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Author: {Author}");
        sb.Append($"Price: {Price:f2}");

        return sb.ToString();
    }

}

