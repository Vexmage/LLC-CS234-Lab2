using MMABooksBusinessClasses;
using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace MMABooksBusinessClasses
{
    public class Customer
    {
        public Customer() { }

		private int customerID;
		private string name;
		private string address;
		private string city;
		private string state;
		private string zipCode;

		public int CustomerID
		{
			get
			{
				return customerID;
			}
			set
			{
				if (value > 0)
					customerID = value;
				else
					throw new ArgumentOutOfRangeException("CustomerID must be a positive integer");

			}
		}

		public string Name
		{
			get { return name; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					name = value;
				else
					throw new ArgumentException("Name cannot be null or empty");
			}
		}

		public string Address
		{
			get { return address; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					address = value;
				else
					throw new ArgumentException("Address cannot be null or empty");
			}
		}

		public string City
		{
			get { return city; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					city = value;
				else
					throw new ArgumentException("City cannot be null or empty");
			}
		}

		public string State
		{
			get { return state; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					state = value;
				else
					throw new ArgumentException("State cannot be null or empty");
			}
		}

		public string ZipCode
		{
			get { return zipCode; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					zipCode = value;
				else
					throw new ArgumentException("ZipCode cannot be null or empty");
			}
		}

		public override string ToString()
		{
			return $"{Name}, {Address}, {City}, {State}, {ZipCode}";
		}

	}
}

