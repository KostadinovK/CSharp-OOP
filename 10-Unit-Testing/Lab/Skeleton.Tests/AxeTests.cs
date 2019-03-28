using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void WeaponAttackShouldDropDurabilityByOne()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints,"Weapon's Durability doesn't decrease.");
        }

        [Test]
        public void AttackWithBrokenWeaponShouldThrowInvalidOperationException()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Broken Weapon didn't throw exception.");
        }
    }
}
