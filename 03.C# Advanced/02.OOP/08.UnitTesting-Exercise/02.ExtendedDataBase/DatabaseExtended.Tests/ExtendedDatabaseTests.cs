namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Security.Cryptography.X509Certificates;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private Database database;

        [SetUp]
        public void SetUp()
        {
            people = new Person[]
            {
                new Person(1, "Mike"),
                new Person(2, "Ivan"),
                new Person(3, "John"),
                new Person(4, "Deny")
            };

            database = new(people);
        }

        [Test]
        public void Person_ConstructorShouldCreateAValidPerson()
        {
            Person person = new Person(12367, "pav.deny");

            Assert.IsNotNull(person);
        }

        [Test]
        public void ConstructorShouldIncreaseCount()
        {
            Person[] people = new Person[]
            {
                new (1, "Mike"),
                new (2, "Josh"),
                new (3, "Kevin"),
            };

            Database database = new(people);
            Assert.NotZero(database.Count);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfPeopleGoAboveCapacity()
        {
            Person[] people = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                people[i] = new Person(i, $"{i}");
            }

            Assert.Throws<ArgumentException>(() => new Database(people), "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            int expectedValue = 5;

            Person person = new(10, "IvanM");
            database.Add(person);

            Assert.AreEqual(expectedValue, database.Count);
        }

        [Test]
        public void AddMethodShouldAddPersonToDatabase()
        {
            Person person = new(100, "IvanM");
            database.Add(person);

            Person foundPerson = database.FindByUsername("IvanM");
            Assert.IsNotNull(foundPerson);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCountEqualsCapacity()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                people[i] = new Person(i, $"{i}");
            }

            database = new(people);
            Person person = new(100, "ABV");

            Assert.Throws<InvalidOperationException>(() => database.Add(person), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfUserWithSameNameExists()
        {
            Person[] people = new Person[] { new Person(1, "George") };
            database = new(people);

            Person person = new Person(2, "George");

            Assert.Throws<InvalidOperationException>(() => database.Add(person), "There is already user with this username!");
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfUserWithSameIdExists()
        {
            Person[] people = new Person[] { new Person(1, "George") };
            database = new(people);

            Person person = new Person(1, "Ivan");

            Assert.Throws<InvalidOperationException>(() => database.Add(person), "There is already user with this Id!");
        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            int expectedValue = 3;

            database.Remove();

            Assert.AreEqual(expectedValue, database.Count);
        }

        [Test]
        public void RemoveMethodShouldRemovePersonFromDatabase()
        {
            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.FindById(4));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfDatabaseIsEmpty()
        {
            database = new();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsernameMethodShouldReturnTheCorrectPerson()
        {
            Person expectedPerson = people[0];

            Person actualPerson = database.FindByUsername("Mike");

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameMethodShouldThrowExceptionIfParameterIsNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username), "Username parameter is null!");
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfUserIsntInDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("BabaYaga"), "No user is present by this username!");
        }

        [Test]
        public void FindByIdMethodShouldReturnTheCorrectPerson()
        {
            Person expectedPerson = people[1];

            Person actualPerson = database.FindById(2);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-10), "Id should be a positive number!");
        }

        [Test]
        public void FindByIdMethodShouldThrowExceptionIfUserIsntInDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(100), "No user is present by this ID!");
        }
    }
}