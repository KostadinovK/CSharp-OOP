using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace _02_ExtendedDatabase.Tests
{
    [TestFixture]
    public class PeopleTests
    {
        [Test]
        public void PeopleConstructorShouldWorkCorrectly()
        {
            People people = new People(1, "Kosta");

            Assert.AreEqual(1, people.Id);
            Assert.AreEqual("Kosta", people.Username);
        }
    }
}
