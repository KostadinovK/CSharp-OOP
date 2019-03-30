using System;
using NUnit.Framework;

namespace _02_ExtendedDatabase.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void SetUp()
        {
            database = new ExtendedDatabase();
        }

        [Test]
        public void AddANonExistingPeopleShouldWorkCorrectly()
        {
            People p = new People(22,"Kosta");

            database.Add(p);

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void AddAnExistingPeopleShouldThrowInvalidOperationException()
        {
            People p = new People(22, "Kosta");
            database.Add(p);

            Assert.Throws<InvalidOperationException>(() => database.Add(p));
        }

        [Test]
        public void RemoveByIdShouldWorkCorrectly()
        {
            People people = new People(22, "Kosta");

            database.Add(people);
            People p = database.RemoveById(people.Id);

            Assert.AreEqual(0, database.Count);
            Assert.AreEqual(people, p);
        }

        [Test]
        public void RemoveByIdWithNegativeIdShouldThrowArgumentOutOfRangeException()
        {
            People people = new People(-2, "Kosta");

            Assert.Throws<ArgumentOutOfRangeException>(() => database.RemoveById(people.Id));
        }

        [Test]
        public void RemoveByIdWithNonExistingIdShouldThrowInvalidOperationException()
        {
            People p = new People(22, "Kosta");

            Assert.Throws<InvalidOperationException>(() => database.RemoveById(p.Id));
        }

        [Test]
        public void RemoveByUsernameShouldWorkCorrectly()
        {
            People people = new People(22, "Kosta");

            database.Add(people);
            People p = database.RemoveByUsername(people.Username);

            Assert.AreEqual(0, database.Count);
            Assert.AreEqual(people, p);
        }

        [Test]
        public void RemoveByUsernameWithInvalidUsernameShouldThrowArgumentNullException()
        {
            People people = new People(2, null);

            Assert.Throws<ArgumentNullException>(() => database.RemoveByUsername(people.Username));
        }

        [Test]
        public void RemoveByUsernameWithNonExistingUsernameShouldThrowInvalidOperationException()
        {
            People p = new People(22, "Kosta");

            Assert.Throws<InvalidOperationException>(() => database.RemoveByUsername(p.Username));
        }

        [Test]
        public void FindByIdWithNegativeIdShouldThrowArgumentOutOfRangeException()
        {
            People p = new People(-2,"Kosta");

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(p.Id));
        }

        [Test]
        public void FindByIdWithNonExistingIdShouldThrowInvalidOperationException()
        {
            People p = new People(2, "Kosta");

            Assert.Throws<InvalidOperationException>(() => database.FindById(p.Id));
        }

        [Test]
        public void FindByIdWithExistingIdShouldWorkCorrectly()
        {
            People p = new People(2, "Kosta");

            database.Add(p);
            People finded = database.FindById(p.Id);

            Assert.AreEqual(p, finded);
        }

        [Test]
        public void FindByUsernameWithInvalidUsernameShouldThrowArgumentNullException()
        {
            People p = new People(2, null);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(p.Username));
        }

        [Test]
        public void FindByUsernameWithNonExistingUsernameShouldThrowInvalidOperationException()
        {
            People p = new People(2, "Kosta");

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(p.Username));
        }

        [Test]
        public void FindByUsernameWithExistingIdShouldWorkCorrectly()
        {
            People p = new People(2, "Kosta");

            database.Add(p);
            People finded = database.FindByUsername(p.Username);

            Assert.AreEqual(p, finded);
        }

    }
}
