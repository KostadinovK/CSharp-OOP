using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using Skeleton.Contracts;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGetXpWhenTargetDiesShouldWorkCorrectly()
        {
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();
            Hero hero = new Hero("Kosta", mockWeapon.Object);

            mockWeapon.Setup(x => x.Attack(mockTarget.Object));
            var experience = 1;
            mockTarget.Setup(x => x.Health).Returns(0);
            mockTarget.Setup(x => x.IsDead).Returns(true);
            mockTarget.Setup(x => x.GiveExperience()).Returns(experience);
            hero.Attack(mockTarget.Object);

            Assert.AreEqual(experience, hero.Experience);
        }
    }
}
