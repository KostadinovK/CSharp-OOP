 using System.Linq;
 using System.Reflection;

 namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string line = Console.ReadLine();

            while (line != "HARVEST")
            {
                PrintAllFieldsOfType(line);

                line = Console.ReadLine();
            }
        }

        private static void PrintAllFieldsOfType(string type)
        {
            Type classType = typeof(HarvestingFields);

            FieldInfo[] fields = null;

            if (type == "public")
            {
                fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            }
            else if (type == "protected")
            {
                fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
                    .Where(f => f.Attributes == FieldAttributes.Family).ToArray();
            }
            else if(type == "private")
            {
                fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.Attributes == FieldAttributes.Private).ToArray();
            }
            else if(type == "all")
            {
                fields = classType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic |
                                             BindingFlags.Public);
            }

            if (fields == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var field in fields)
            {
                if (field.Attributes == FieldAttributes.Family)
                {
                    Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                }
                else
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
