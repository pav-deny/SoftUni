namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        // ---------------------------------------------------------
        // Constructor Tests
        // ---------------------------------------------------------

        [Test]
        public void ConstructorShouldInitializeProperties()
        {
            Warrior w = new Warrior("Gosho", 10, 100);

            Assert.AreEqual("Gosho", w.Name);
            Assert.AreEqual(10, w.Damage);
            Assert.AreEqual(100, w.HP);
        }

        // ---------------------------------------------------------
        // Name Validation
        // ---------------------------------------------------------

        [Test]
        public void ConstructorShouldThrowExceptionWhenNameIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(null, 10, 100);
            });
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("", 10, 100);
            });
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenNameIsWhitespace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("   ", 10, 100);
            });
        }

        // ---------------------------------------------------------
        // Damage Validation
        // ---------------------------------------------------------

        [Test]
        public void ConstructorShouldThrowExceptionWhenDamageIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Gosho", 0, 100);
            });
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenDamageIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Gosho", -5, 100);
            });
        }

        // ---------------------------------------------------------
        // HP Validation
        // ---------------------------------------------------------

        [Test]
        public void ConstructorShouldThrowExceptionWhenHPIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior("Gosho", 10, -1);
            });
        }

        // ---------------------------------------------------------
        // Attack Method Tests
        // ---------------------------------------------------------

        [Test]
        public void AttackShouldThrowExceptionWhenAttackerHpIs30OrLess()
        {
            Warrior attacker = new Warrior("A", 10, 30);
            Warrior defender = new Warrior("B", 10, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackShouldThrowExceptionWhenDefenderHpIs30OrLess()
        {
            Warrior attacker = new Warrior("A", 10, 100);
            Warrior defender = new Warrior("B", 10, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackShouldThrowExceptionWhenAttackingTooStrongEnemy()
        {
            Warrior attacker = new Warrior("A", 10, 40);
            Warrior defender = new Warrior("B", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        // ---------------------------------------------------------
        // Successful Attack Tests
        // ---------------------------------------------------------

        [Test]
        public void AttackShouldReduceHpCorrectly()
        {
            Warrior attacker = new Warrior("A", 20, 100);
            Warrior defender = new Warrior("B", 10, 100);

            attacker.Attack(defender);

            Assert.AreEqual(90, attacker.HP); // 100 - 10
            Assert.AreEqual(80, defender.HP); // 100 - 20
        }

        [Test]
        public void AttackShouldSetDefenderHpToZeroWhenDamageIsLethal()
        {
            Warrior attacker = new Warrior("A", 200, 100);
            Warrior defender = new Warrior("B", 50, 100);

            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
        }
    }
}