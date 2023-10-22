using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
	public class ProductDBTests
	{
		private string testProductCode;

		[SetUp]
		public void Setup()
		{
			// Set up a known state for your tests.
			Product testProduct = new Product
			{
				ProductCode = "TESTP",
				Description = "Test Product",
				UnitPrice = 10.00m,
				OnHandQuantity = 5
			};
			testProductCode = testProduct.ProductCode;
			ProductDB.AddProduct(testProduct);
		}

		[TearDown]
		public void Teardown()
		{
			if (!string.IsNullOrEmpty(testProductCode))
			{
				Product productToDelete = ProductDB.GetProduct(testProductCode);
				if (productToDelete != null)
				{
					ProductDB.DeleteProduct(productToDelete);
				}
			}
		}

		[Test]
		public void TestGetProduct()
		{
			Product p = ProductDB.GetProduct(testProductCode);
			Assert.AreEqual(testProductCode, p.ProductCode);
		}

		[Test]
		public void TestGetAllProducts()
		{
			List<Product> products = ProductDB.GetList();
			Assert.IsTrue(products.Count > 0);
		}

		[Test]
		public void TestAddProduct()
		{
			Product existingProduct = ProductDB.GetProduct("ADDPR");
			if (existingProduct != null)
			{
				ProductDB.DeleteProduct(existingProduct);
			}

			Product p = new Product
			{
				ProductCode = "ADDPR",
				Description = "Added Product",
				UnitPrice = 15.00m,
				OnHandQuantity = 5
			};
			bool isAdded = ProductDB.AddProduct(p);
			p = ProductDB.GetProduct("ADDPR");
			Assert.IsTrue(isAdded);
			Assert.AreEqual("Added Product", p.Description);
		}

		[Test]
		public void TestUpdateProduct()
		{
			Product originalProduct = ProductDB.GetProduct(testProductCode);

			Product updatedProduct = new Product
			{
				ProductCode = originalProduct.ProductCode,
				Description = "Updated Product",
				UnitPrice = 20.00m,
				OnHandQuantity = 8
			};

			bool isUpdated = ProductDB.UpdateProduct(originalProduct, updatedProduct);

			Product retrievedProduct = ProductDB.GetProduct(testProductCode);
			Assert.IsTrue(isUpdated);
			Assert.AreEqual("Updated Product", retrievedProduct.Description);
		}

		[Test]
		public void TestDeleteProduct()
		{
			Product p = new Product
			{
				ProductCode = "DELPR",
				Description = "Delete Product",
				UnitPrice = 12.00m,
				OnHandQuantity = 7
			};
			ProductDB.AddProduct(p);

			bool isDeleted = ProductDB.DeleteProduct(p);

			Product retrievedProduct = ProductDB.GetProduct("DELPR");
			Assert.IsTrue(isDeleted);
			Assert.IsNull(retrievedProduct);
		}
	}
}