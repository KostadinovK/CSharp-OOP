using System;
using System.Collections.Generic;
using System.Text;


public class XmlLayout : ILayout
{
    public string Format { get; set; }

    public XmlLayout()
    {
        Format = "<log>\n";
        Format += "  <date>$date-time$</date>\n" +
                  "  <level>$report-level$</level>\n" +
                  "  <message>$message$</message>\n" +
                  "</log>";
    }
}

