using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {
        private DealerShop dealershop;
        private Vehicle vehicle;

        [SetUp]
        public void Setup()
        {
            dealershop = new DealerShop(10);
            vehicle = new Vehicle("BMW", "340i", 2024);
        }

        [Test]
        public void ConstructorCreatesANewInstance()
        {
            Assert.IsNotNull(dealershop);
        }

        [Test]
        public void CosntructorImplementsCapacityCorrectly()
        {
            int expectedCapacity = 10;

            DealerShop dealerShop = new DealerShop(10);
            Assert.AreEqual(expectedCapacity, dealerShop.Capacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void CapacitySetterThrowsExceptionIfCapacityIsZeroOrNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new DealerShop(capacity));
        }

        [Test]
        public void ConstructorCreatesANewInstanceOfTheListVehicles()
        {
            Assert.IsNotNull(dealershop.Vehicles);
        }

        [Test]
        public void AddVehicleMethodAdssElementToTheListCorrectly()
        {
            int expectedCount = 1;
            dealershop.AddVehicle(vehicle);

            Assert.AreEqual(expectedCount, dealershop.Vehicles.Count);
        }

        [Test]
        public void AddVehicleMethodReturnsStringCorrectly()
        {
            string expectedResult = $"Added {vehicle.ToString()}";
            string actualResult = dealershop.AddVehicle(vehicle);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddVehicleMethodShouldThrowExceptionIfCountEqualsCapacity()
        {
            DealerShop dealerShop = new DealerShop(1);
            dealerShop.AddVehicle(vehicle);

            Vehicle secondVehicle = new Vehicle("BMW", "M5CS", 2022);
            Assert.Throws<InvalidOperationException>(() => dealerShop.AddVehicle(secondVehicle), "Inventory is full");
        }

        [Test]
        public void SellVehicleMethodShouldRemoveVehicleFromList()
        {
            dealershop.AddVehicle(vehicle);

            int expectedResult = 0;
            dealershop.SellVehicle(vehicle);

            Assert.AreEqual(expectedResult, dealershop.Vehicles.Count);
        }

        [Test]
        public void SellVehicleMethodShouldReturnTrueIfVehicleIsInListAndWasRemovedFromList()
        {
            dealershop.AddVehicle(vehicle);

            Assert.IsTrue(dealershop.SellVehicle(vehicle));
        }

        [Test]
        public void SellVehicleMethodShouldReturnFalseIfVehicleIsntInList()
        {
            Assert.IsFalse(dealershop.SellVehicle(vehicle));
        }

        [Test]
        public void VehicleReportMethodShouldReturnCorrectOutpu()
        {
            dealershop.AddVehicle(vehicle);

            string expectedResult = CreateExpectedInventoryReport(dealershop);
            string actualResult = dealershop.InventoryReport();

            Assert.AreEqual(expectedResult, actualResult);
        }

        private string CreateExpectedInventoryReport(DealerShop dealerShop)
        {
            StringBuilder sb = new();
            sb.AppendLine("Inventory Report");
            sb.AppendLine($"Capacity: {dealershop.Capacity}");
            sb.AppendLine($"Vehicles: {dealershop.Vehicles.Count}");
            sb.AppendLine($"{vehicle.ToString()}");

            return sb.ToString().TrimEnd();
        }
    }
}
