namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        // ---------------------------
        // Constructor / Basic Tests
        // ---------------------------

        [Test]
        public void Constructor_ShouldInitializeCollection()
        {
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(0, arena.Count);
        }

        // ---------------------------
        // Enroll Tests
        // ---------------------------

        [Test]
        public void Enroll_ShouldAddWarrior()
        {
            Warrior w = new Warrior("A", 10, 100);

            arena.Enroll(w);

            Assert.AreEqual(1, arena.Count);
            Assert.Contains(w, arena.Warriors.ToList());
        }

        [Test]
        public void Enroll_AlreadyExistingWarrior_ShouldThrowException()
        {
            Warrior w1 = new Warrior("A", 10, 100);
            Warrior w2 = new Warrior("A", 20, 100);

            arena.Enroll(w1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(w2);
            });
        }

        // ---------------------------
        // Fight Tests
        // ---------------------------

        [Test]
        public void Fight_ShouldThrowException_WhenAttackerNotFound()
        {
            arena.Enroll(new Warrior("B", 10, 100));

            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Missing", "B");
            });

            Assert.AreEqual("There is no fighter with name Missing enrolled for the fights!", ex.Message);
        }

        [Test]
        public void Fight_ShouldThrowException_WhenDefenderNotFound()
        {
            arena.Enroll(new Warrior("A", 10, 100));

            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("A", "Missing");
            });

            Assert.AreEqual("There is no fighter with name Missing enrolled for the fights!", ex.Message);
        }

        [Test]
        public void Fight_ShouldCallAttackMethod()
        {
            Warrior attacker = new Warrior("A", 50, 100);
            Warrior defender = new Warrior("B", 40, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("A", "B");

            // After fight:
            // Attacker HP decreases by defender.Damage: 100 - 40 = 60
            // Defender HP decreases by attacker.Damage: 100 - 50 = 50
            Assert.AreEqual(60, attacker.HP);
            Assert.AreEqual(50, defender.HP);
        }

        [Test]
        public void Fight_ShouldReduceDefenderHpToZero_WhenDamageIsHigher()
        {
            Warrior attacker = new Warrior("A", 200, 100);
            Warrior defender = new Warrior("B", 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("A", "B");

            Assert.AreEqual(0, defender.HP);
        }
    }
}
