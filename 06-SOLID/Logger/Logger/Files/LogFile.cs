using System;
using System.Collections.Generic;
using System.Text;


public class LogFile : IFile
{
    public StringBuilder StringBuilder { get; set; }
    public long Size => GetSize();

    private long GetSize()
    {
        long size = 0;

        for (int i = 0; i < StringBuilder.Length; i++)
        {
            if (Char.IsLetter(StringBuilder[i]))
            {
                size += StringBuilder[i];
            }
        }

        return size;
    }

    public LogFile()
    {
        StringBuilder = new StringBuilder();
    }

    public void Write(string message)
    {
        StringBuilder.AppendLine(message);
    }

    public void Write(string message, long size)
    {
        StringBuilder.AppendLine(message);
    }
}
