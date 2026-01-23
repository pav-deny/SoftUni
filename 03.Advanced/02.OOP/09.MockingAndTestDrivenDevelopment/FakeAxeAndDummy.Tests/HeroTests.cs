using NUnit.Framework;

namespace FakeAxeAndDummy.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGainsExperienceWhenTargetIsDead()
        {
            FakeTarget fakeTarget = new FakeTarget();
            FakeWeapon fakeWeapon = new FakeWeapon();

            Hero hero = new Hero("TestHero", fakeWeapon);
            hero.Attack(fakeTarget);

            Assert.That(hero.Experience, Is.EqualTo(250));
        }
    }
}
