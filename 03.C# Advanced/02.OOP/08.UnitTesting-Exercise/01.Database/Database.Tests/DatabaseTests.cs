namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq.Expressions;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2);
        }

        //Constructor
        [Test]
        public void ConstructorShouldNotCreateNullDatabase()
        {
            Assert.IsNotNull(database);
        }

        [Test]
        public void ConstructorShouldCreateDatabaseWithCorrectCount()
        {
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(1, 2, 3, 4, 5, 6)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void ConstructorShouldAddElementsToDatabase(params int[] arr)
        {
            database = new Database(arr);
            Assert.AreEqual(arr.Length, database.Count);
        }

        [Test]
        public void CosntructorShouldThrowExceptionIfElemntsCountIsBiggerThanTheLength()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() => new Database(data), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void CountShouldWorkCorrectly()
        {
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, database.Count);
        }

        //Add
        [TestCase(10)]
        [TestCase(-1)]
        public void AddMethodShouldIncreaseCount(int element)
        {
            int expectedCount = 3;
            database.Add(3);
            Assert.AreEqual(expectedCount, database.Count);
        }


        [TestCase(1, 2, 3, 4, 5, 6)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15)]
        public void AddMethodShouldAddElementsToDatabase(params int[] arr)
        {
            database = new Database(arr);

            int[] actualResult = database.Fetch();

            Assert.AreEqual(arr, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfElementIsAddedWhenCapacityIsReached()
        {
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            database = new Database(data);

            Assert.Throws<InvalidOperationException>(() => database.Add(17), "Array's capacity must be exactly 16 integers!");
        }

        //Remove
        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            int expectedResult = 1;
            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void RemoveMethodShouldRemoveElements()
        {
            int[] expectedResult = new int[0];

            database.Remove();
            database.Remove();

            int[] actualResult = database.Fetch();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            database = new();

            Assert.Throws<InvalidOperationException>(() => database.Remove(), "The collection is empty!");
        }

        //Fetch
        [TestCase(1, 2, 3)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8)]
        public void FetchMethodShouldReturnTheDatabsa(params int[] arr)
        {
            database = new Database(arr);

            int[] actualResult = database.Fetch();
            Assert.AreEqual(arr, actualResult);
        }
    }
}
