using MMABooksBusinessClasses;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
		private static IConfiguration _configuration;

		static ProductDB()
		{
			string folder = System.AppContext.BaseDirectory;
			var builder = new ConfigurationBuilder()
					.SetBasePath(folder)
					.AddJsonFile("mySqlSettings.json", optional: true, reloadOnChange: true);

			_configuration = builder.Build();
		}

		public static MySqlConnection GetConnection()
		{
			string connectionString = _configuration.GetConnectionString("mySql");
			return new MySqlConnection(connectionString);
		}
		
        public static bool AddProduct(Product product)
        {
			using (MySqlConnection connection = GetConnection())
			{
				string sql = "INSERT INTO products (ProductCode, Description, UnitPrice, OnHandQuantity) " +
			 "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
				cmd.Parameters.AddWithValue("@Description", product.Description);
				cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
				cmd.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

				connection.Open();
				int rowsAffected = cmd.ExecuteNonQuery();
				return rowsAffected == 1;
			}
		}

		public static bool DeleteProduct(Product product)
		{
			using (MySqlConnection connection = GetConnection())
			{
				string sql = "DELETE FROM products WHERE ProductCode = @ProductCode AND Description = @Description AND UnitPrice = @UnitPrice AND OnHandQuantity = @OnHandQuantity";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
				cmd.Parameters.AddWithValue("@Description", product.Description);
				cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
				cmd.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

				connection.Open();
				int rowsAffected = cmd.ExecuteNonQuery();
				return rowsAffected == 1;
			}
		}


		public static Product GetProduct(string productCode)
        {
			using (MySqlConnection connection = GetConnection())
			{
				string sql = "SELECT * FROM products WHERE ProductCode = @ProductCode";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@ProductCode", productCode);

				connection.Open();
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						Product product = new Product();
						product.ProductCode = reader["ProductCode"].ToString();
						product.Description = reader["Description"].ToString();
						product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
						product.OnHandQuantity = Convert.ToInt32(reader["OnHandQuantity"]);
						return product;
					}
					else
					{
						return null;
					}
				}
			}
		}

		public static List<Product> GetList()
		{
			List<Product> products = new List<Product>();

			using (MySqlConnection connection = GetConnection())
			{
				string sql = "SELECT * FROM products";
				MySqlCommand cmd = new MySqlCommand(sql, connection);

				connection.Open();
				using (MySqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						Product product = new Product();
						product.ProductCode = reader["ProductCode"].ToString();
						product.Description = reader["Description"].ToString();
						product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
						product.OnHandQuantity = Convert.ToInt32(reader["OnHandQuantity"]);
						products.Add(product);
					}
				}
			}

			return products;
		}


		public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
			using (MySqlConnection connection = GetConnection())
			{
				string sql = "UPDATE products SET Description = @Description, UnitPrice = @UnitPrice, OnHandQuantity = @OnHandQuantity WHERE ProductCode = @ProductCode";
				MySqlCommand cmd = new MySqlCommand(sql, connection);
				cmd.Parameters.AddWithValue("@Description", newProduct.Description);
				cmd.Parameters.AddWithValue("@UnitPrice", newProduct.UnitPrice);
				cmd.Parameters.AddWithValue("@OnHandQuantity", newProduct.OnHandQuantity);
				cmd.Parameters.AddWithValue("@ProductCode", oldProduct.ProductCode);

				connection.Open();
				int rowsAffected = cmd.ExecuteNonQuery();
				return rowsAffected == 1;
			}
		}
    }
}
