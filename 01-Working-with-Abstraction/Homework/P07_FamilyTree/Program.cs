using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Person> byNames = new Dictionary<string, Person>();
            Dictionary<string, Person> byBirthdates = new Dictionary<string, Person>();

            string personInfo = Console.ReadLine();


            string line = Console.ReadLine();

            while (line != "End")
            {
                if (!line.Contains(" - "))
                {
                    string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (byNames.ContainsKey(tokens[0] + " " + tokens[1]) && byBirthdates.ContainsKey(tokens[2]))
                    {
                        byNames[tokens[0] + " " + tokens[1]].Concatenate(byBirthdates[tokens[2]]);
                        byBirthdates[tokens[2]].Concatenate(byNames[tokens[0] + " " + tokens[1]]);
                    }
                    else if (!byNames.ContainsKey(tokens[0] + " " + tokens[1]) && byBirthdates.ContainsKey(tokens[2]))
                    {
                        byBirthdates[tokens[2]].Name = tokens[0] + " " + tokens[1];
                        byNames.Add(tokens[0] + " " + tokens[1], byBirthdates[tokens[2]]);
                    }
                    else if (byNames.ContainsKey(tokens[0] + " " + tokens[1]) && !byBirthdates.ContainsKey(tokens[2]))
                    {
                        byNames[tokens[0] + " " + tokens[1]].Birthdate = tokens[2];
                        byBirthdates.Add(tokens[2], byNames[tokens[0] + " " + tokens[1]]);
                    }
                    else if (!byNames.ContainsKey(tokens[0] + " " + tokens[1]) && !byBirthdates.ContainsKey(tokens[2]))
                    {
                        byNames.Add(tokens[0] + " " + tokens[1], new Person(tokens[0] + " " + tokens[1], tokens[2]));
                    }

                }
                else
                {
                    string[] relation = line.Split(" - ").ToArray();
                    Person person1 = GetPerson(relation[0], byNames, byBirthdates);
                    Person person2 = GetPerson(relation[1], byNames, byBirthdates);

                    if (person1 == null)
                    {
                        person1 = new Person(relation[0]);
                        if (Char.IsDigit(relation[0][0]))
                        {
                            byBirthdates.Add(relation[0], person1);
                        }
                        else
                        {
                            byNames.Add(relation[0], person1);
                        }
                    }

                    if (person2 == null)
                    {
                        person2 = new Person(relation[1]);
                        if (Char.IsDigit(relation[1][0]))
                        {
                            byBirthdates.Add(relation[1], person2);
                        }
                        else
                        {
                            byNames.Add(relation[1], person2);
                        }
                    }

                    person1.AddChildren(person2);
                    person2.AddParent(person1);
                }

                line = Console.ReadLine();
            }

            if (Char.IsDigit(personInfo[0]))
            {
                Console.WriteLine(byNames.Values.Where(x => x.Birthdate == personInfo).ToArray()[0].ToString());
            }
            else
            {
                Console.WriteLine(byNames[personInfo]);
            }
        }

        private static Person GetPerson(string str, Dictionary<string, Person> byNames, Dictionary<string, Person> byBirthdates)
        {

            Person p = null;

            if (Char.IsDigit(str[0]))
            {
                foreach (var kvp in byBirthdates)
                {
                    if (kvp.Value.Birthdate == str)
                    {
                        p = kvp.Value;
                        break;
                    }
                }
            }
            else
            {
                foreach (var kvp in byNames)
                {
                    if (kvp.Value.Name == str)
                    {
                        p = kvp.Value;
                        break;
                    }
                }
            }

            return p;
        }
    }
}
