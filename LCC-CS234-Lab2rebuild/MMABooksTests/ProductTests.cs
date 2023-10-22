using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MMABooksBusinessClasses; 

namespace MMABooksTests
{
    public class ProductTests
    {
        [Test]
        public void TestAttributeSettingAndGetters()
        {
            Product p = new Product();
            p.ProductCode = "12345";
            p.Description = "A product";
            p.UnitPrice = 10.00m;

            Assert.AreEqual("12345", p.ProductCode);
            Assert.AreEqual("A product", p.Description);
            Assert.AreEqual(10.00m, p.UnitPrice);
        }

        [Test]
        public void TestProductConstructor()
        {
            Product p1 = new Product();
            Assert.IsNotNull(p1);
            Assert.AreEqual(string.Empty, p1.ProductCode);
            Assert.AreEqual("Empty field", p1.Description);
            Assert.AreEqual(0.0m, p1.UnitPrice);

            string newCode = "12345";
            string newDescription = "A product";
            decimal newUnitPrice = 10.00m;
            Product p2 = new Product(newCode, newDescription, newUnitPrice, 7);
            Assert.IsNotNull(p2);
            Assert.AreEqual(newCode, p2.ProductCode);
            Assert.AreEqual(newDescription, p2.Description);
            Assert.AreEqual(newUnitPrice, p2.UnitPrice);
        }

		[Test]
		public void TestProductCodeValidation()
		{
			Product p = new Product();

			p.ProductCode = "12345";
			Assert.AreEqual("12345", p.ProductCode);

			Assert.Throws<ArgumentException>(() => p.ProductCode = "12345678901");
		}

		[Test]
		public void TestUnitPriceValidation()
		{
			Product p = new Product();

			p.UnitPrice = 10.00m;
			Assert.AreEqual(10.00m, p.UnitPrice);

			Assert.Throws<ArgumentException>(() => p.UnitPrice = -10.00m);
		}

		[Test]
		public void TestToStringMethod()
		{
			Product p = new Product("12345", "A product", 10.00m, 7);
			string expectedString = "Product Code: 12345, Description: A product, Unit Price: $10.00, On Hand Quantity: 7";
			Assert.AreEqual(expectedString, p.ToString());
		}


		[Test]
		public void TestDescriptionValidation()
		{
			Product p = new Product();

			Assert.Throws<ArgumentException>(() => p.Description = null);
			Assert.Throws<ArgumentException>(() => p.Description = "");

			string longDescription = new string('a', 251);  
			Assert.Throws<ArgumentException>(() => p.Description = longDescription);
		}

		[Test]
		public void TestOnHandQuantityValidation()
		{
			Product p = new Product();

			Assert.Throws<ArgumentException>(() => p.OnHandQuantity = -1);

		}


	}
}
