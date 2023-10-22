using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    public class CustomerDBTests
    {
		private int testCustomerId;

		[SetUp]
		public void Setup()
		{
			// Here, you can set up a known state for your tests.
			Customer testCustomer = new Customer
			{
				Name = "Test Customer",
				Address = "123 Test Street",
				City = "Test City",
				State = "FL",  
				ZipCode = "11111"
			};
			testCustomerId = CustomerDB.AddCustomer(testCustomer);
		}




		[TearDown]
		public void Teardown()
		{
			if (testCustomerId > 0)  
			{
				Customer customerToDelete = CustomerDB.GetCustomer(testCustomerId);
				if (customerToDelete != null)
				{
					CustomerDB.DeleteCustomer(customerToDelete);
				}
			}
		}

		[Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(testCustomerId);
            Assert.AreEqual(testCustomerId, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            Customer originalCustomer = CustomerDB.GetCustomer(testCustomerId); // Fetch the original customer

            Customer updatedCustomer = new Customer
            {
                CustomerID = originalCustomer.CustomerID,
                Name = "Mickey Mouse",
                Address = originalCustomer.Address,
                City = originalCustomer.City,
                State = originalCustomer.State,
                ZipCode = originalCustomer.ZipCode
            };

            CustomerDB.UpdateCustomer(originalCustomer, updatedCustomer); // Updating the customer

            Customer retrievedCustomer = CustomerDB.GetCustomer(testCustomerId); // Fetching the updated customer for verification
            Assert.AreEqual("Mickey Mouse", retrievedCustomer.Name);
        }



		[Test]
		public void TestDeleteCustomer()
		{
			// Create a test customer to delete.
			Customer customerToDelete = new Customer
			{
				Name = "Test Delete Customer",
				Address = "123 Delete Street",
				City = "Delete City",
				State = "FL",
				ZipCode = "22222"
			};
			int customerToDeleteId = CustomerDB.AddCustomer(customerToDelete);

			// Ensure the customer was created successfully.
			Assert.Greater(customerToDeleteId, 0, "Failed to create test customer for deletion.");

			// Delete the test customer.
			customerToDelete.CustomerID = customerToDeleteId;
			CustomerDB.DeleteCustomer(customerToDelete);

			// Fetch the customer again to verify it was deleted.
			Customer retrievedCustomer = CustomerDB.GetCustomer(customerToDeleteId);
			Assert.IsNull(retrievedCustomer, "Customer was not deleted successfully.");
		}



	}
}
