using System;
using System.Collections.Generic;
using System.Text;


public class SimpleLayout : ILayout
{
    public string Format { get; set; }

    public SimpleLayout()
    {
        Format = "$date-time$ - $report-level$ - $message$";
    }

}
