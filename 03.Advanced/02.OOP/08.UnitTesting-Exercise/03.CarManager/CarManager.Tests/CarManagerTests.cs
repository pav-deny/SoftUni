namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new("Mazda", "6", 5, 50);
        }

        [Test]
        public void ConstrunctorShouldCreateCarCorrectlyWithZeroFuelAmount()
        {
            string expectedMake = "Mazda";
            string expectedModel = "6";
            double expectedFuelConsumption = 10;
            double expectedFuelCapacity = 50;

            Car car = new Car("Mazda", "6", 10, 50);

            Assert.IsNotNull(car);
            Assert.Zero(car.FuelAmount);
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void  CarMakeShouldThrowExceptionIfNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "6", 20, 10), "Make cannot be null or empty!");
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarModelShouldThrowExceptionIfNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mazda", model, 20, 10), "Model cannot be null or empty!");
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void CarFuelConsumptionShouldThrowExceptionIfZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mazda", "6", fuelConsumption, 10), "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void CarFuelCapacityShouldThrowExceptionIfZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mazda", "6", 10, fuelCapacity), "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-6)]
        public void RefuelMethodShouldThrowExceptionIfAmountIsZeroOrNegative(double amount)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(amount), "Fuel amount cannot be zero or negative!");
        }

        [TestCase(20)]
        [TestCase(50)]
        public void RefuelMethodShouldIncreaseFuelAmount(double amount)
        {
            car.Refuel(amount);
            Assert.AreEqual(amount, car.FuelAmount);
        }

        [Test]
        public void RefuelMethodShouldFillUpToCapacityIfRefuelAmountGoesAboveCapacity()
        {
            double expectedValue = 50;

            car.Refuel(100);
            double actualValue = car.FuelAmount;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void DriveMethodShouldDecreaseFuelAmount()
        {
            car.Refuel(50);

            car.Drive(10);
            double expectedFuelAmount = 49.5;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfFuelAmountIsntEnough()
        {
            car.Refuel(1);

            Assert.Throws<InvalidOperationException>(() => car.Drive(100), "You don't have enough fuel to drive!");
        }
    }
}