using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
		private string _productCode;
		private decimal unitPrice;
		private string description;
		private int onHandQuantity;
		public string ProductCode
		{
			get { return _productCode; }
			set
			{
				if (value.Length > 10)
					throw new ArgumentException("ProductCode cannot exceed 10 characters.");
				_productCode = value;
			}
		}

		public string Description
		{
			get { return description; }
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentException("Description cannot be null or empty.");
				}
				if (value.Length > 250)
				{
					throw new ArgumentException("Description cannot exceed 250 characters.");
				}
				description = value;
			}
		}

		public int OnHandQuantity
		{
			get { return onHandQuantity; }
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("OnHandQuantity cannot be negative.");
				}

				onHandQuantity = value;
			}
		}

		public decimal UnitPrice
		{
			get { return unitPrice; }
			set
			{
				if (value < 0) 
				{
					throw new ArgumentException("UnitPrice cannot be negative.");
				}
				unitPrice = value;
			}
		}

		public override string ToString()
		{
			return $"Product Code: {ProductCode}, Description: {Description}, Unit Price: ${UnitPrice:F2}, On Hand Quantity: {OnHandQuantity}";
		}


		public Product Clone()
		{
			return new Product
			{
				ProductCode = this.ProductCode,
				Description = this.Description,
				UnitPrice = this.UnitPrice,
				OnHandQuantity = this.OnHandQuantity
			};
		}

		public Product()
		{
			ProductCode = string.Empty;
			Description = "Empty field";
			UnitPrice = 0.0m;
			OnHandQuantity = 0;
		}

		public Product(string productCode, string description, decimal unitPrice, int onHandQty) : this()
		{
			ProductCode = productCode;
			Description = description;
			UnitPrice = unitPrice;
			OnHandQuantity = onHandQty;
		}

	}
}
