using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
       [Test]
       public void TestCtorWorksCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.IsNotNull(raceEntry.Counter);
        }
       [Test]
       public void TestAddRiderCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle motorcycle = new UnitMotorcycle("Seat", 60, 150);
            UnitRider rider = new UnitRider("Gosho", motorcycle);

            string expectedOutput = $"Rider {rider.Name} added in race.";

            Assert.AreEqual(expectedOutput, raceEntry.AddRider(rider));
        }
        [Test]
        public void TestAddRiderCorrectlyCount()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle motorcycle = new UnitMotorcycle("Seat", 60, 150);
            UnitRider rider = new UnitRider("Gosho", motorcycle);

            int expectedCount = 1;

            raceEntry.AddRider(rider);

            Assert.AreEqual(expectedCount, raceEntry.Counter);
        }
        [Test]
        public void TestAddRiderWhenIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(null);
            });
        }
        [Test]
        public void TestAddRiderWhenRiderAdded()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle motorcycle = new UnitMotorcycle("Seat", 60, 150);
            UnitRider rider = new UnitRider("Gosho", motorcycle);

            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddRider(rider);
            });
        }
        [Test]
        public void TestCalculateAverageHorsePowerCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle motorcycle1 = new UnitMotorcycle("BMW", 40, 150);
            UnitRider rider1 = new UnitRider("Pesho", motorcycle1);

            UnitMotorcycle motorcycle2 = new UnitMotorcycle("Seat", 60, 150);
            UnitRider rider2 = new UnitRider("Gosho", motorcycle2);

            raceEntry.AddRider(rider1);
            raceEntry.AddRider(rider2);

            double expextedAvarageHP = 50;

            Assert.AreEqual(expextedAvarageHP, raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void TestCalculateAverageHorsePowerNotCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle motorcycle = new UnitMotorcycle("BMW", 40, 150);
            UnitRider rider = new UnitRider("Pesho", motorcycle);

            raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }
    }
}