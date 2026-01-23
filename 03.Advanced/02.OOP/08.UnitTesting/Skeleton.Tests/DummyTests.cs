using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int initialAliveHealth = 10;
        private const int initialDeadHealth = -10;
        private const int damage = 5;
        private const int experience = 10;

        [Test]
        public void DummyShouldLoseHealthAfterBeingAttacked()
        {
            Dummy dummy = new Dummy(initialAliveHealth, experience);

            dummy.TakeAttack(damage);

            Assert.That(dummy.Health, Is.EqualTo(initialAliveHealth - damage));
        }

        [Test]
        public void DeadDummyShouldThrowExceptionWhenAttacked()
        {
            Dummy dummy = new Dummy(initialDeadHealth, experience);

            Assert.Throws<InvalidOperationException>(() =>  dummy.TakeAttack(damage), "Dummy is dead.");
        }

        [Test]
        public void DeadDummyShouldGiveXPWhenMethodGiveExperienceIsUsed()
        {
            Dummy dummy = new Dummy(initialDeadHealth, experience);

            int xp = 0;
            xp = dummy.GiveExperience();

            Assert.That(xp, Is.Not.EqualTo(0));
        }

        [Test]
        public void AliveDummyShouldThrowExceptionWhenMethodGiveExperienceIsUsed()
        {
            Dummy dummy = new Dummy(initialAliveHealth, experience);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");
        }
    }
}