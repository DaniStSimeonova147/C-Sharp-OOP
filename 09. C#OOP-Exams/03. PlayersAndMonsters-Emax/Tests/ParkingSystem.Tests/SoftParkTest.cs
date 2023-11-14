namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCtorWorksCorrectly()
        {
            SoftPark softPark = new SoftPark();

            int expectedCount = 12;

            Assert.AreEqual(expectedCount, softPark.Parking.Count);
        }
        [Test]
        public void TestParkCarCorrectly()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Seat", "1225");

            string expectedOutput = $"Car:{car.RegistrationNumber} parked successfully!";

            Assert.AreEqual(expectedOutput, softPark.ParkCar("A1", car));
        }
        
        [Test]
        public void TestParkCarWhenDoesnotExistsParkSpot()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Seat", "1225");

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar("A10", car);
            });
        }
        [Test]
        public void TestParkCarWhenParkSpotIsAlready()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Seat", "1225");

            Car car2 = new Car("BMW", "1005");

            softPark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.ParkCar("A1", car2);
            });
        }

        [Test]
        public void TestParkCarWhenCarIsParked()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Seat", "1225");
            softPark.ParkCar("A1", car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                softPark.ParkCar("A2", car);
            });
        }
        [Test]
        public void TestRemoveCarCorrectly()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Seat", "1225");
            softPark.ParkCar("A1", car);

            string expectedOutput = $"Remove car:{car.RegistrationNumber} successfully!";

            Assert.AreEqual(expectedOutput, softPark.RemoveCar("A1", car));
        }

        [Test]
        public void TestRemoveCarWhenParkSpotDoesnotExsists()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Seat", "1225");

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.RemoveCar("A10", car);
            });
        }
        [Test]
        public void TestRemoveCarWhenCarDoesnotExists()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Seat", "1225");

            Assert.Throws<ArgumentException>(() =>
            {
                softPark.RemoveCar("A1", car);
            });
        }
    }
}