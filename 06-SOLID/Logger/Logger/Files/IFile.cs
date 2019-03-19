using System;
using System.Collections.Generic;
using System.Text;


public interface IFile
{
    long Size { get; }
    void Write(string message);
}
