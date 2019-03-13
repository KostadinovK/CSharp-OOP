using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Soldier> soldiers = new List<Soldier>();

        string line = Console.ReadLine();

        while (line != "End")
        {
            string[] args = line.Split().ToArray();

            string soldierType = args[0];
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];

            if (soldierType == "Private")
            {
                decimal salary = decimal.Parse(args[4]);
                Private @private = new Private(id, firstName, lastName, salary);

                soldiers.Add(@private);
            }
            else if (soldierType == "Spy")
            {
                int codeNumber = int.Parse(args[4]);
                Spy spy = new Spy(id, firstName, lastName, codeNumber);

                soldiers.Add(spy);
            }
            else if (soldierType == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(args[4]);

                List<int> ids = args.Skip(5).Select(int.Parse).ToList();
                List<Private> privates = GetPrivates(soldiers, ids);

                LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                soldiers.Add(general);
            }
            else if (soldierType == "Engineer")
            {
                decimal salary = decimal.Parse(args[4]);
                string corps = args[5];

                if (corps == "Marines" || corps == "Airforces")
                {
                    List<string> repairsInfo = args.Skip(6).ToList();
                    List<Repair> repairs = GetRepairs(repairsInfo);

                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    soldiers.Add(engineer);
                }
            }
            else if (soldierType == "Commando")
            {
                decimal salary = decimal.Parse(args[4]);
                string corps = args[5];

                if (corps == "Marines" || corps == "Airforces")
                {
                    List<string> missionsInfo = args.Skip(6).ToList();
                    List<Mission> missions = GetMissions(missionsInfo);

                    Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                    soldiers.Add(commando);
                }
            }

            line = Console.ReadLine();
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }

    private static List<Mission> GetMissions(List<string> missionsInfo)
    {
        List<Mission> missions = new List<Mission>();

        for (int i = 0; i < missionsInfo.Count - 1; i+=2)
        {
            if (missionsInfo[i + 1] == "inProgress" || missionsInfo[i + 1] == "Finished")
            {
                Mission mission = new Mission(missionsInfo[i], missionsInfo[i + 1]);
                missions.Add(mission);
            }
        }

        return missions;
    }

    private static List<Repair> GetRepairs(List<string> repairsInfo)
    {
        List<Repair> repairs = new List<Repair>();

        for (int i = 0; i < repairsInfo.Count - 1; i += 2)
        {
            Repair repair = new Repair(repairsInfo[i], int.Parse(repairsInfo[i + 1]));
            repairs.Add(repair);
        }

        return repairs;
    }

    private static List<Private> GetPrivates(List<Soldier> soldiers, List<int> ids)
    {
        List<Private> privates = new List<Private>();

        foreach (var id in ids)
        {
            foreach (var soldier in soldiers.Where(x => x.GetType().Name == nameof(Private)))
            {
                if (id == soldier.Id)
                {
                    privates.Add((Private)soldier);
                }
            }
        }

        return privates;
    }
}
