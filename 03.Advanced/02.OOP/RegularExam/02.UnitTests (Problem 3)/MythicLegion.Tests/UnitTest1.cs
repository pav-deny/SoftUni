using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace MythicLegion.Tests
{
    public class Tests
    {
        private Legion legion;
        private Hero hero;

        [SetUp]
        public void Setup()
        {
            legion = new Legion();
            hero = new Hero("Ivan", "Warrior");
        }

        [Test]
        public void ConstructorCreatesNewInstance()
        {
            Legion legion = new Legion();
            Assert.IsNotNull(legion);
        }

        [Test]
        public void AddHeroMethodShouldAddHero()
        {
            legion.AddHero(hero);

            string wrongResult = "No heroes in the legion.";
            Assert.AreNotEqual(wrongResult, legion.GetLegionInfo());
        }

        [Test]
        public void AddHeroMethodShouldThrowExceptionIfHeroIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => legion.AddHero(null), "Hero cannot be null");
        }

        [Test]
        public void AddHeroMethodShouldThrowExceptionIfHeroIsAlreadyInTheLegion()
        {
            legion.AddHero(hero);

            Assert.Throws<ArgumentException>(() => legion.AddHero(hero), $"Hero with name {hero.Name} already exists in the legion.");
        }

        [Test]
        public void RemoveHeroMethodShouldRemoveHero()
        {
            legion.AddHero(hero);
            string expectedResult = "No heroes in the legion.";

            legion.RemoveHero(hero.Name);
            Assert.AreEqual(expectedResult, legion.GetLegionInfo());
        }

        [Test]
        public void RemoveHeroMethodShouldReturnTrueIfHeroRemovedSuccesfully()
        {
            legion.AddHero(hero);

            Assert.IsTrue(legion.RemoveHero(hero.Name));
        }

        [Test]
        public void RemoveHeroMethodShouldReturnFalseExceptionIfHeroNotInLegion()
        {
            Assert.IsFalse(legion.RemoveHero(hero.Name));
        }

        [Test]
        public void TrainHeroMethodShouldReturnCorrectStringIfHeroIsTrained()
        {
            legion.AddHero(hero);
            string expectedResult = $"{hero.Name} has been trained.";

            Assert.AreEqual(expectedResult, legion.TrainHero(hero.Name));
        }

        [Test]
        public void TrainHeroMethodShouldSetHerosIsTrainedPropertyToTrue()
        {
            legion.AddHero(hero);

            legion.TrainHero(hero.Name);
            Assert.IsTrue(hero.IsTrained);
        }

        [Test]
        public void TrainHeroMethodShouldIncreaseHerosPowerByTen()
        {
            legion.AddHero(hero);
            int expectedResult = hero.Power + 10;

            legion.TrainHero(hero.Name);

            Assert.AreEqual(expectedResult, hero.Power);
        }

        [Test]
        public void TrainHeroMethodShouldIncreaseHerosHealthByOne()
        {
            legion.AddHero(hero);
            int expectedResult = hero.Health + 1;

            legion.TrainHero(hero.Name);

            Assert.AreEqual(expectedResult , hero.Health);
        }

        [Test]
        public void TrainMethodShouldReturnCorrectStringIfHeroIsntInLegion()
        {
            string expectedresult = $"Hero with name {hero.Name} not found.";
            string actualResult = legion.TrainHero(hero.Name);

            Assert.AreEqual(expectedresult, actualResult);
        }

        [Test]
        public void GetLegionInfoMethodShouldReturnCorrectString()
        {
            legion.AddHero(hero);

            Hero hero2 = new Hero("Petar", "Mage");
            legion.AddHero(hero2);

            string ecxpectedResult = $"{hero.ToString()}{Environment.NewLine}{hero2.ToString()}";
       
            Assert.AreEqual(ecxpectedResult, legion.GetLegionInfo());
        }

        [Test]
        public void GetLegionInfoMethodShouldReturnCorrectStringIfThereAreNoHeroesInLegion()
        {
            string expectedResult = "No heroes in the legion.";

            Assert.AreEqual(expectedResult, legion.GetLegionInfo());
        }
    }
}