using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int initialDurability = 10;
        private const int initialBrokenDurability = -10;
        private const int initialAttack = 10;

        [Test]
        public void AxeShouldLooseDurabillityAfterAttack()
        {
            Axe axe = new Axe(initialAttack, initialDurability);

            axe.Attack(new(10, 2));

            Assert.That(axe.DurabilityPoints, Is.EqualTo(initialDurability - 1));
        }

        [Test]
        public void BrokenAxeShouldThrowExceptionWhenAttackMethodIsCalled()
        {
            Axe axe = new Axe(initialAttack, initialBrokenDurability);
            Dummy dummy = new Dummy(5, 5);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");
        }
    }
}