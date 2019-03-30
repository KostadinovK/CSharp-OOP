using System;
using System.Collections.Generic;
using System.Text;

namespace _02_ExtendedDatabase
{
    public class People
    {
        public long Id { get; set; }
        public string Username { get; set; }

        public People(long id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
