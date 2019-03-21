using System;
using System.Collections.Generic;
using System.Linq;
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

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        var classType = Type.GetType(className);

        var fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        var nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        var publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var field in fields)
        {
            if (!field.IsPrivate)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
        }

        foreach (var method in nonPublicMethods.Where(m => m.Name.StartsWith("get_")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set_")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: " + className);

        Type classType = Type.GetType(className);

        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        MethodInfo[] methods =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var method in methods)
        {

            sb.AppendLine(method.Name);

        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(className);

        MethodInfo[] methods = classType.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public |
                                                    BindingFlags.NonPublic);

        var getters = methods.Where(m => m.Name.StartsWith("get")).ToList();
        var setters = methods.Where(m => m.Name.StartsWith("set")).ToList();

        foreach (var getter in getters)
        {
            sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (var setter in setters)
        {
            sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}
