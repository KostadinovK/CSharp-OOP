using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string classToInvestigate, params string[] fields)
    {
        var classType = Type.GetType(classToInvestigate);

        List<FieldInfo> classFields = new List<FieldInfo>();

        foreach (var field in fields)
        {
            var fieldInfo = classType.GetField(field, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            classFields.Add(fieldInfo);
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {classToInvestigate}");

        var classInstance = Activator.CreateInstance(classType, null);

        foreach (var field in classFields)
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}
