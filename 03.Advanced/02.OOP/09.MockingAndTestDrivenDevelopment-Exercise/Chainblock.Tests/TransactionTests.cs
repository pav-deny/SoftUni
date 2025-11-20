using Chainblock.Contracts;
using Chainblock.ExceptionMessages;
using Chainblock.Models;
using NUnit.Framework;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        //Constructor
        [Test]
        public void ConstructorShouldInitializeTransactionProperly()
        {
            //Arrange //Act
            ITransaction transaction = new Transaction(12, TransactionStatus.Failed, "GoShow", "Kasskata", 67.69);

            //Assert
            Assert.IsNotNull(transaction);
        }

        [Test]
        public void ConstructorShouldInitializeIdProperly()
        {
            //Arrange 
            int expectedId = 1;

            //Act
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "Pesho", "Mecho", 23.43);

            //Assert
            Assert.AreEqual(expectedId, transaction.Id);
        }

        [Test]
        public void ConstructorShouldInitializeStatusProperly()
        {
            //Arrange 
            TransactionStatus expectedStatus = TransactionStatus.Successfull;

            //Act
            ITransaction transaction = new Transaction(1, expectedStatus, "Ivan", "Goshow", 56.56);

            //Assert
            Assert.AreEqual(expectedStatus, transaction.Status);
        }

        [Test]
        public void ConstructorShouldInitializeFromProperly()
        {
            //Arrange 
            string expectedFrom = "Ivan";

            //Act
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, expectedFrom, "Petyo", 67.69);

            //Assert
            Assert.AreEqual(expectedFrom, transaction.From);
        }

        [Test]
        public void ConstructorShouldInitializeToProperly()
        {
            //Arrange 
            string expectedTo = "Vanya";

            //Act
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "Kiro", expectedTo, 123.45);

            //Assert
            Assert.AreEqual(expectedTo, transaction.To);

        }

        [Test]
        public void ConstructorShouldInitializeAmmountProperly()
        {
            //Arrange 
            double expectedAmount = 1300.67;

            //Act
            ITransaction transaction = new Transaction(1, TransactionStatus.Aborted, "Kiro", "Breika", expectedAmount);

            //Assert
            Assert.AreEqual(expectedAmount, transaction.Amount);

        }

        //Validation
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-4)]
        [TestCase(-100)]
        public void IdSetterShouldThrowExceptionWithZeroOrNegativeValue(int id)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => { new Transaction(id, TransactionStatus.Failed, "Peshi", "IdkMan", 100); });

            Assert.AreEqual(TransactionExceptionMessages.IdValueNonPositive, ex.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void FromSetterShouldThrowExceptionWithNullOrWhiteSpaceValue(string from)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => { new Transaction(2, TransactionStatus.Failed, from, "IdkMan", 100); });

            Assert.AreEqual(TransactionExceptionMessages.FromValueNullOrWhiteSpace, ex.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void ToSetterShouldThrowExceptionWithNullOrWhiteSpaceValue(string to)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => { new Transaction(2, TransactionStatus.Failed, "IdkMan", to, 100); });

            Assert.AreEqual(TransactionExceptionMessages.ToValueNullOrWhiteSpace, ex.Message);
        }

        [TestCase(0)]
        [TestCase(-0.001)]
        [TestCase(-1000)]
        public void AmountSetterShouldTrhowExceptionWithZeroOrNegativeValue(double amount)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => { new Transaction(2, TransactionStatus.Failed, "IdkMan", "NzBrart", amount); });

            Assert.AreEqual(TransactionExceptionMessages.AmountValueNonPositive, ex.Message);
        }
    }
}