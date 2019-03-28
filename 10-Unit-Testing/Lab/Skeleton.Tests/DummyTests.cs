using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LoosesHealthWhenAttackedShouldWorkCorrectly()
        {
            Dummy dummy = new Dummy(10,10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health, "Dummy Health doesn't looses health when attacked.");
        }

        [Test]
        public void AttackedDeadDummyShouldThrowInvalidOperationException()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5), "Should throw exception when attacked a dead dummy");
        }

        [Test]
        public void GiveExperienceFromDeadDummyShouldWorkCorrectly()
        {
            Dummy dummy = new Dummy(0, 10);

            var exp = dummy.GiveExperience();

            Assert.AreEqual(10, exp, "Dead Dummy didn't give experience.");
        }

        [Test]
        public void GiveExperienceFromAliveDummyShouldThrowInvalidOperationException()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive Dummy cant give experience, should throw InvalidOperationException.");
        }
    }
}
