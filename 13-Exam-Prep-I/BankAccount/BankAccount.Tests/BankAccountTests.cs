using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    [TestFixture]
    public class Tests
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {
            account = new BankAccount("validName", 200);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            var validName = "validName";
            var validBalance = 20m;

            BankAccount account = new BankAccount(validName, validBalance);

            Assert.AreEqual(validName, account.Name);
            Assert.AreEqual(validBalance, account.Balance);
        }

        [Test]
        [TestCase("As")]
        [TestCase("AVeryLongAndInvalidBankAccountNameForTestingPurpose")]
        public void Constructor_InvalidNameShouldThrowArgumentException(string name)
        {
            var validBalance = 20m;
            BankAccount account = null;

            Assert.Throws<ArgumentException>(() => account = new BankAccount(name, validBalance));
        }

        [Test]
        public void Constructor_InvalidBalanceShouldThrowArgumentException()
        {
            var validName = "ValidName";
            var invalidBalance = -200m;
            BankAccount account = null;

            Assert.Throws<ArgumentException>(() => account = new BankAccount(validName, invalidBalance));
        }

        [Test]
        public void Deposit_InvalidAmountShouldThrowInvalidOperationException()
        {
            var invalidAmount = -100;

            Assert.Throws<InvalidOperationException>(() => account.Deposit(invalidAmount));
        }

        [Test]
        public void Deposit_ValidAmountShouldWorkCorrectly()
        {
            var validAmount = 100;
            var expectedAmount = account.Balance + validAmount;

            account.Deposit(validAmount);

            var actualAmount = account.Balance;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        [TestCase(-100)]
        [TestCase(500)]
        public void Withdraw_InvalidAmountShouldThrowInvalidOperationException(decimal invalidAmount)
        {
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(invalidAmount));
        }

        [Test]
        public void Withdraw_ValidAmountShouldWorkCorrectly()
        {
            var validAmount = 100;
            var expectedAmount = account.Balance - validAmount;

            account.Withdraw(validAmount);

            var actualAmount = account.Balance;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

    }
}