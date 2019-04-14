
using System;

namespace Telecom.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            var make = "OnePlus";
            var model = "5";
            var expectedPhonebookCount = 0;
            var phone = new Phone(make, model);

            var actualPhonebookCount = phone.Count;

            Assert.AreEqual(make, phone.Make);
            Assert.AreEqual(model, phone.Model);
            Assert.AreEqual(expectedPhonebookCount, actualPhonebookCount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_InvalidMakeShouldThrowArgumentException(string make)
        {
            var validModel = "validModel";

            Assert.Throws<ArgumentException>(() => new Phone(make, validModel));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Constructor_InvalidModelShouldThrowArgumentException(string model)
        {
            var validMake = "OnePlus";

            Assert.Throws<ArgumentException>(() => new Phone(validMake, model));
        }

        [Test]
        public void AddContact_AlreadyExistingContactShouldThrowInvalidOperationException()
        {
            var phone = new Phone("OnePlus", "5");

            phone.AddContact("Pesho", "09999");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "09"));
        }

        [Test]
        public void AddContact_ShouldWorkCorrectly()
        {
            var phone = new Phone("OnePlus", "5");
            var expectedPhonebookCount = 1;

            phone.AddContact("Pesho", "09999");
            var actualPhonebookCount = phone.Count;

            Assert.AreEqual(expectedPhonebookCount, actualPhonebookCount);
        }

        [Test]
        public void Call_NonExistingContactShouldThrowInvalidOperationException()
        {
            var phone = new Phone("OnePlus", "5");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Pesho"));
        }

        [Test]
        public void Call_ShouldWorkCorrectly()
        {
            var phone = new Phone("OnePlus", "5");
            phone.AddContact("Pesho", "phone");

            var expectedResult = "Calling Pesho - phone...";
            var actualResult = phone.Call("Pesho");

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}