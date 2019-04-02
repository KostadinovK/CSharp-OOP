using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using Chainblock.Contracts;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private Chainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock();
        }

        [Test]
        public void Constructor_InitializeCorrectly()
        {
            int actualCount = chainblock.Count;
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Add_ExistingTransactionShouldThrowInvalidOperationException()
        {
            ITransaction transaction =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 100);

            chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.Add(transaction));
        }

        [Test]
        public void Add_ShouldIncrementCountCorrectly()
        {
            ITransaction transaction =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 100);

            chainblock.Add(transaction);

            var expectedCount = 1;
            var actualCount = chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ContainsTransaction_ShouldReturnFalse()
        {
            ITransaction t = 
                new Transaction(1, TransactionStatus.Successfull, "Gosho", "Gichka", 12);

            Assert.IsFalse(chainblock.Contains(t));
        }

        [Test]
        public void ContainsTransaction_ShouldReturnTrue()
        {
            ITransaction t =
                new Transaction(1, TransactionStatus.Successfull, "Gosho", "Gichka", 12);

            chainblock.Add(t);

            Assert.IsTrue(chainblock.Contains(t));
        }

        [Test]
        public void ContainsId_ShouldReturnFalse()
        {
            ITransaction t =
                new Transaction(1, TransactionStatus.Successfull, "Gosho", "Gichka", 12);

            Assert.IsFalse(chainblock.Contains(t.Id));
        }

        [Test]
        public void ContainsId_ShouldReturnTrue()
        {
            ITransaction t =
                new Transaction(1, TransactionStatus.Successfull, "Gosho", "Gichka", 12);

            chainblock.Add(t);

            Assert.IsTrue(chainblock.Contains(t.Id));
        }

        [Test]
        public void RemoveById_NonExistingTransactionShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(2));
        }

        [Test]
        public void RemoveById_ExistingTransactionShouldDecreaseCountCorrectly()
        {
            ITransaction t =
                new Transaction(1, TransactionStatus.Successfull, "Gosho", "Gichka", 12);

            chainblock.Add(t);
            chainblock.RemoveTransactionById(t.Id);

            var expectedCount = 0;
            var actualCount = chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ChangeTransactionStatus_NonExistingTransactionShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.ChangeTransactionStatus(12, TransactionStatus.Failed)
                );
        }

        [Test]
        public void ChangeTransactionStatus_ExistingTransactionShouldWorkCorrectly()
        {
            ITransaction transaction =
                new Transaction(1, TransactionStatus.Failed, "Pesho", "Gosho", 100);

            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Successfull);

            Assert.AreEqual(TransactionStatus.Successfull, transaction.Status);
        }

        [Test]
        public void GetById_InvalidIdShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(22));
        }

        [Test]
        public void GetById_ShouldReturnCorrectly()
        {
            ITransaction expectedTransaction =
                new Transaction(1, TransactionStatus.Failed, "Pesho", "Gosho", 100);

            chainblock.Add(expectedTransaction);

            var actual = chainblock.GetById(expectedTransaction.Id);

            Assert.AreEqual(expectedTransaction, actual);
        }

        [Test]
        public void GetByTransactionStatus_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByTransactionStatus(TransactionStatus.Aborted)
                );
        }

        [Test]
        public void GetByTransactionStatus_ShouldWorkCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Aborted, "Drago", "Gichka", 10);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction>{transaction2, transaction1};
            var actual = chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted)
            );
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ShouldWorkCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Aborted, "Drago", "Gichka", 10);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<string> { "Pesho", "Pesho" };
            var actual = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted)
            );
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ShouldWorkCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Aborted, "Drago", "Gichka", 10);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<string> { "Gosho", "Gichka" };
            var actual = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnCorrectly()
        {

            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Aborted, "Drago", "Gichka", 10);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction> { transaction2, transaction1, transaction3 };
            var actual = chainblock.GetAllOrderedByAmountDescendingThenById();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderOrderedByAmountDescending("Drago")
            );
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ShouldReturnCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Aborted, "Drago", "Gichka", 10);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction> { transaction2, transaction1};
            var actual = chainblock.GetBySenderOrderedByAmountDescending("Pesho");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverOrderedByAmountThenById("Drago")
            );
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ShouldReturnCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gichka", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Aborted, "Drago", "Gichka", 100);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction> { transaction2, transaction1, transaction3 };
            var actual = chainblock.GetByReceiverOrderedByAmountThenById("Gichka");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnEmptyCollection()
        {
            var result = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 100);

            Assert.IsEmpty(result);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ShouldReturnCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gichka", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Successfull, "Drago", "Gichka", 10);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction> { transaction1, transaction3};
            var actual = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 100);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetBySenderAndMinimumAmountDescending("Drago", 10)
            );
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ShouldReturnCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gichka", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Aborted, "Drago", "Gichka", 100);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction> { transaction2};
            var actual = chainblock.GetBySenderAndMinimumAmountDescending("Pesho", 1000);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainblock.GetByReceiverAndAmountRange("Drago", 10, 100)
            );
        }

        [Test]
        public void GetByReceiverAndAmountRange_ShouldReturnCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gichka", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Aborted, "Drago", "Gichka", 100);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction> { transaction2 };
            var actual = chainblock.GetByReceiverAndAmountRange("Gichka", 1000, 10000);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnEmptyCollection()
        {
            var result = chainblock.GetAllInAmountRange(1, 100);

            Assert.IsEmpty(result);
        }

        [Test]
        public void GetAllInAmountRange_ShouldReturnCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gichka", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Successfull, "Drago", "Gichka", 10);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction> { transaction1, transaction3 };
            var actual = chainblock.GetAllInAmountRange(10, 1000);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetEnumerator_ShouldWorkCorrectly()
        {
            ITransaction transaction1 =
                new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gichka", 100);

            ITransaction transaction2 =
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gichka", 1100);

            ITransaction transaction3 =
                new Transaction(3, TransactionStatus.Successfull, "Drago", "Gichka", 10);

            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);

            var expected = new List<ITransaction> { transaction1, transaction2, transaction3 };
            var actual = new List<ITransaction>();

            foreach (var t in chainblock)
            {
                actual.Add(t);
            }

            Assert.AreEqual(expected, actual);
        }
    }

}
