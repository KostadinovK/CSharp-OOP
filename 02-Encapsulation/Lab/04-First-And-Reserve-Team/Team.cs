using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public List<Person> FirstTeam
        {
            get => firstTeam;
        }
        public List<Person> ReserveTeam
        {
            get => reserveTeam;
        }

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person p)
        {
            if (p.Age < 40)
            {
                firstTeam.Add(p);
            }
            else
            {
                reserveTeam.Add(p);
            }
        }
    }
}
