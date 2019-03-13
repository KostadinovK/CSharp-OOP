using System;
using System.Collections.Generic;
using System.Text;

public interface ILieutenantGeneral : IPrivate
{
    List<Private> UnderCommand { get; set; }
}
