using System;
using System.Collections.Generic;
using System.Text;

public interface IGuard
{
    string Name { get; set; }

    void HandleKingsAttack();
}
