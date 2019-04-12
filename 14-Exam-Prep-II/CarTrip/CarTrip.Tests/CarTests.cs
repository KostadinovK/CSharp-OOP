using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            var model = "Opel Corsa";
            var tankCapacity = 20;
            var fuelAmount = 10;
            var fuelConsumptionPerKm = 1;

            var car = new Car(model, tankCapacity, fuelAmount, fuelConsumptionPerKm);

            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(tankCapacity, car.TankCapacity);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
            Assert.AreEqual(fuelConsumptionPerKm, car.FuelConsumptionPerKm);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Constructor_InvalidModelShouldThrowArgumentException(string model)
        {
            var tankCapacity = 20;
            var fuelAmount = 10;
            var fuelConsumptionPerKm = 1;

            Assert.Throws<ArgumentException>(() => new Car(model, tankCapacity, fuelAmount, fuelConsumptionPerKm));
        }

        [Test]
        public void Constructor_InvalidFuelAmountShouldThrowArgumentException()
        {
            var model = "Mazda 6";
            var tankCapacity = 20;
            var invalidFuelAmount = 100;
            var fuelConsumptionPerKm = 1;

            Assert.Throws<ArgumentException>(
                () => new Car(model, tankCapacity, invalidFuelAmount, fuelConsumptionPerKm));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void Constructor_InvalidFuelConsumptionPerKmShouldThrowArgumentException(double fuelConsumption)
        {
            var model = "Mazda 6";
            var tankCapacity = 20;
            var fuelAmount = 20;

            Assert.Throws<ArgumentException>(() => new Car(model, tankCapacity, fuelAmount, fuelConsumption));
        }

        [Test]
        public void Drive_ShouldThrowInvalidOperationException()
        {
            var car = new Car("Opel Corsa", 100, 100, 10);
            var biggestDistanceThanFuelAmount = 100;

            Assert.Throws<InvalidOperationException>(() => car.Drive(biggestDistanceThanFuelAmount));
        }

        [Test]
        public void Drive_ShouldWorkCorrectly()
        {

            var car = new Car("Opel Corsa", 100, 100, 2);
            var distance = 40;

            var expectedFuelAmount = car.FuelAmount - distance * car.FuelConsumptionPerKm;
            car.Drive(distance);
            var actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void Refuel_ShouldThrowInvalidOperationException()
        {
            var car = new Car("Opel Corsa", 100, 100, 10);
            var invalidRefuelFuelAmount = 200;

            Assert.Throws<InvalidOperationException>(() => car.Refuel(invalidRefuelFuelAmount));
        }

        [Test]
        public void Refuel_ShouldWorkCorrectly()
        {

            var car = new Car("Opel Corsa", 200, 100, 2);
            var fuelAmountToRefuel = 40;

            var expectedFuelAmount = car.FuelAmount + fuelAmountToRefuel;
            car.Refuel(fuelAmountToRefuel);
            var actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
    }
}