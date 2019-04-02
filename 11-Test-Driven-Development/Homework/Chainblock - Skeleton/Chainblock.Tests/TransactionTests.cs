using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            var id = 12;
            var status = TransactionStatus.Aborted;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 1000;

            Transaction transaction = new Transaction(id, status, from, to, amount);

            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(status, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }

        [Test]
        public void Constructor_InvalidIdShouldThrowArgumentException()
        {
            var id = -12;
            var status = TransactionStatus.Aborted;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 1000;

            Assert.Throws<ArgumentException>(() => new Transaction(id, status, from, to, amount));
        }

        [Test]
        public void Constructor_InvalidSenderNameShouldThrowArgumentNullException()
        {
            var id = 12;
            var status = TransactionStatus.Aborted;
            string from = null;
            var to = "Gosho";
            var amount = 1000;

            Assert.Throws<ArgumentNullException>(() => new Transaction(id, status, from, to, amount));
        }

        [Test]
        public void Constructor_InvalidReceiverNameShouldThrowArgumentNullException()
        {
            var id = 12;
            var status = TransactionStatus.Aborted;
            var from = "Pesho";
            string to = null;
            var amount = 1000;

            Assert.Throws<ArgumentNullException>(() => new Transaction(id, status, from, to, amount));
        }

        [Test]
        public void Constructor_InvalidAmountShouldThrowArgumentException()
        {
            var id = 12;
            var status = TransactionStatus.Aborted;
            var from = "Pesho";
            var to = "Gosho";
            var amount = -1000;

            Assert.Throws<ArgumentException>(() => new Transaction(id, status, from, to, amount));
        }

        [Test]
        public void CompareTo_ShouldCompareByIdCorrectly()
        {
            var firstId = 12;
            var secondId = 22;

            var status = TransactionStatus.Aborted;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 1000;

            var firstTransaction = new Transaction(firstId, status, from, to, amount);
            var secondTransaction = new Transaction(secondId, status, from, to, amount);

            var expected = -1;
            var actual = firstTransaction.CompareTo(secondTransaction);

            Assert.AreEqual(expected, actual);
        }
    }
}
