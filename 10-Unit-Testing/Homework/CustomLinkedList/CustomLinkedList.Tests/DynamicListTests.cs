using System;
using NUnit.Framework;

namespace CustomLinkedList.Tests
{
    [TestFixture]
    public class DynamicListTests
    {
        private DynamicList<int> list;

        [SetUp]
        public void SetUp()
        {
            list = new DynamicList<int>();
        }

        [Test]
        public void InitializeDynamicListShouldWorkCorrectly()
        {
            Assert.AreEqual(0, list.Count, "Initialization is invalid!");
        }

        [Test]
        public void AddItemShouldIncreaseCount()
        {
            list.Add(1);

            Assert.AreEqual(1, list.Count, "Count doesn't increase!");
        }

        [Test]
        public void RemoveAtValidIndexShouldReturnsAndDecreaseCountCorrectly()
        {
            list.Add(5);
            var element = list.RemoveAt(0);

            Assert.AreEqual(0, list.Count, "Count doesn't increase!");
            Assert.AreEqual(5, element, $"Element isn't equal to {5}!");
        }

        [Test]
        public void RemoveAtInvalidIndexShouldThrowArgumentOutOfRangeException()
        {
            list.Add(5);

            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(33), "Didn't throw exception!");
        }

        [Test]
        public void RemoveExistingElementShouldReturnValidIndex()
        {
            list.Add(5);

            var index = list.Remove(5);

            Assert.AreEqual(0,index, "Indexes are not equal!");
            Assert.AreEqual(0, list.Count, "Count doesn't increase!");
        }

        [Test]
        public void RemoveNonExistingElementShouldReturnValidIndex()
        {
            var index = list.Remove(5);

            Assert.AreEqual(-1, index, "Index must be -1!");
            Assert.AreEqual(0, list.Count, "Count doesn't increase!");
        }

        [Test]
        public void IndexOfExistingElementShouldReturnValidIndex()
        {
            list.Add(5);

            var index = list.IndexOf(5);

            Assert.AreEqual(0, index, "Index doesn't match!");
        }

        [Test]
        public void IndexOfNonExistingElementShouldReturnValidIndex()
        {
            Assert.AreEqual(-1, list.IndexOf(4), "Index doesn't match!");
        }


        [Test]
        public void ContainsExistingElementShouldReturnTrue()
        {
            list.Add(5);

            var contains = list.Contains(5);

            Assert.IsTrue(contains, "Contains() returned False!");
        }

        [Test]
        public void ContainsNonExistingElementShouldReturnFalse()
        {
            var contains = list.Contains(5);

            Assert.IsFalse(contains, "Contains() returned True!");
        }
    }
}
