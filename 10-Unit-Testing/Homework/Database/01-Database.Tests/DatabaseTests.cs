using System;
using NUnit.Framework;

namespace _01_Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void DatabaseConstructorShouldWorkCorrectly()
        {
            Database database = new Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);

            Assert.AreEqual(16, database.Count, "Count isn't equal to 16.");
        }

        [Test]
        public void DatabaseConstructorWithElementsCountLessThanCapacityShouldThrowInvalidOperationException()
        {
            Database database;

            Assert.Throws<InvalidOperationException>(() => database = new Database(1,2,3,4));
        }

        [Test]
        public void AddAnElementWhenDatabaseIsNotFullShouldWorkCorrectly()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            database.Remove();
            database.Add(4);

            Assert.AreEqual(16, database.Count);
            Assert.AreEqual(4, database.Fetch()[database.Count - 1]);
        }

        [Test]
        public void AddAnElementWhenDatabaseIsFullShouldThrowInvalidOperationException()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => database.Add(4));
        }

        [Test]
        public void RemoveAnElementWhenDatabaseIsNotEmptyShouldWorkCorrectly()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            var num = database.Remove();

            Assert.AreEqual(15, database.Count);
            Assert.AreEqual(16, num);
        }

        [Test]
        public void RemoveAnElementWhenDatabaseIsEmptyShouldThrowInvalidOperationException()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchDatabaseShouldWorkCorrectly()
        {
            Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            int[] expected = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            int[] actual = database.Fetch();

            Assert.AreEqual(expected, actual);
        }

    }
}
