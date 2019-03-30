using System;
using System.Collections.Generic;
using System.Text;

namespace _02_ExtendedDatabase
{
    public class ExtendedDatabase
    {
        private Dictionary<long, People> byId;
        private Dictionary<string, People> byUsername;

        public int Count => byId.Count;
        public ExtendedDatabase()
        {
            byId = new Dictionary<long, People>();
            byUsername = new Dictionary<string, People>();
        }

        public void Add(People people)
        {
            if (people.Id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative!");
            }

            if (byId.ContainsKey(people.Id) || byUsername.ContainsKey(people.Username))
            {
                throw new InvalidOperationException("People with that Id or Username already exist!");
            }

            byId.Add(people.Id, people);
            byUsername.Add(people.Username, people);
        }

        public People RemoveById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative!");
            }

            if (!byId.ContainsKey(id))
            {
                throw new InvalidOperationException("People with this id doesn't exist!");
            }

            People toRemove = byId[id];
            byId.Remove(id);
            byUsername.Remove(toRemove.Username);

            return toRemove;
        }
        public People RemoveByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username cannot be empty or null!");
            }

            if (!byUsername.ContainsKey(username))
            {
                throw new InvalidOperationException("People with this username doesn't exist!");
            }

            People toRemove = byUsername[username];
            byUsername.Remove(username);
            byId.Remove(toRemove.Id);

            return toRemove;
        }

        public People FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative!");
            }

            if (!byId.ContainsKey(id))
            {
                throw new InvalidOperationException("People with this id doesn't exist!");
            }

            return byId[id];
        }

        public People FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username cannot be empty or null!");
            }

            if (!byUsername.ContainsKey(username))
            {
                throw new InvalidOperationException("People with this username doesn't exist!");
            }

            return byUsername[username];
        }
    }
}
