using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chainblock.Models;
using System.Reflection;
using System.Globalization;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction transaction;


        [SetUp]
        public void Setup()
        {
            chainblock = new ChainBlock();
            transaction = new Transaction(1, TransactionStatus.Successfull, "Maria", "Ivan", 1000.5);
        }

        [Test]
        public void ConstructorShouldInitializeTransactionsCollection()
        {
            Type chainblockType = typeof(ChainBlock);

            FieldInfo transactionsField = chainblockType
                .GetField("transactionsById", BindingFlags.Instance | BindingFlags.NonPublic);

            IDictionary<int, ITransaction> transactionsById = transactionsField
                .GetValue(chainblock) as IDictionary<int, ITransaction>;

            Assert.IsNotNull(transactionsById);
            Assert.AreEqual(0, transactionsById.Count);
        }

        [Test]
        public void AddShouldAppendTheTransactionsToTheTransactionsByIdCollection()
        {
            chainblock.Add(transaction);

            bool isTransactionAdded = chainblock.Contains(transaction.Id);

            Assert.IsTrue(isTransactionAdded);
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            int expectedCount = 1;

            chainblock.Add(transaction);

            Assert.AreEqual(expectedCount, chainblock.Count);
        }

        [Test]
        public void AddShouldTrhowExceptionWhenAddingSameTransaction()
        {
            chainblock.Add(transaction);

            ArgumentException ex = Assert.Throws<ArgumentException>
                (() => chainblock.Add(transaction));

            Assert.AreEqual("Transaction already exists!", ex.Message);
        }

        [Test]
        public void ContainsShoudlReturnTrueWhenTransactionExists()
        {
            chainblock.Add(transaction);

            Assert.True(chainblock.Contains(transaction.Id));
        }

        [Test]
        public void ContainsShoudlReturnFalseWhenTransactionDoesntExists()
        {
            Assert.False(chainblock.Contains(transaction.Id));
        }

        [TestCase(TransactionStatus.Aborted, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Successfull, TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Failed, TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Unauthorised, TransactionStatus.Successfull)]
        public void ChangeTransactionStatusShouldChangeStatusCorrectly(TransactionStatus from, TransactionStatus to)
        {
            transaction.Status = from;
            chainblock.Add(transaction);

            chainblock.ChangeTransactionStatus(transaction.Id, to);

            Assert.AreEqual(transaction.Status, to);
        }
    }
}
