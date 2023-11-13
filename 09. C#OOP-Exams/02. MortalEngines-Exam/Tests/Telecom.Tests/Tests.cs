namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void TestCtorCorrectly()
        {
            Phone phone = new Phone("iphone", "7plus");

            Assert.IsNotNull(phone.Count);
        }
        [Test]
        public void TestCorrectlyPhoneMake()
        {
            Phone phone = new Phone("iphone", "7plus");

            string expectedMake = "iphone";

            Assert.AreEqual(expectedMake, phone.Make);
        }
        [Test]
        public void TestNotCorrectlyPhoneMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(null, "7plus");
            });

        }
        [Test]
        public void TestCorrectlyPhoneModel()
        {
            Phone phone = new Phone("iphone", "7plus");

            string expectedModel = "7plus";

            Assert.AreEqual(expectedModel, phone.Model);
        }
        [Test]
        public void TestNotCorrectlyPhoneModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone("iphone", null);
            });
        }
        [Test]
        public void TestAddContactCorrectly()
        {
            Phone phone = new Phone("iphone", "7plus");

            int expectedCount = 1;

            phone.AddContact("Gosho", "0899807575");

            Assert.AreEqual(expectedCount, phone.Count);
        }
        [Test]
        public void TestAddContactNotCorrectly()
        {
            Phone phone = new Phone("iphone", "7plus");

            phone.AddContact("Gosho", "0899807575");

            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.AddContact("Gosho", "0899203569");
            });
        }
        [Test]
        public void TestCallCorrectly()
        {
            Phone phone = new Phone("iphone", "7plus");

            phone.AddContact("Gosho", "0899807575");

            string expectedOutput = $"Calling Gosho - 0899807575...";

            Assert.AreEqual(expectedOutput, phone.Call("Gosho"));
        }
        [Test]
        public void TestCallNotCorrectly()
        {
            Phone phone = new Phone("iphone", "7plus");

            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.Call("Ico");
            });
        }
    }
}