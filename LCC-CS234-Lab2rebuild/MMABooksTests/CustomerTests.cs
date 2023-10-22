using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void TestAttributeSettingAndGetters()
        {
            // Arrange
            Customer c = new Customer();
            c.Name = "Baruch Spinoza";
            c.Address = "101 Main Street";
            c.City = "Miami";
            c.State = "FL";
            c.ZipCode = "12345";

            // Act & Assert
            Assert.AreEqual("Baruch Spinoza", c.Name);
            Assert.AreEqual("101 Main Street", c.Address);
            Assert.AreEqual("Miami", c.City);
            Assert.AreEqual("FL", c.State);
            Assert.AreEqual("12345", c.ZipCode);
        }

    }
}
