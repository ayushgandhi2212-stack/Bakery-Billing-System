using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BakeryBillingSystem
{
	public class DBHelper
	{
		// Read connection string from Web.config
		private readonly string connectionString =
			ConfigurationManager.ConnectionStrings["BakeryDB"].ConnectionString;

		// Return SQL Connection
		public SqlConnection GetConnection()
		{
			return new SqlConnection(connectionString);
		}

		// Execute INSERT, UPDATE, DELETE
		public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
		{
			int rows = 0;

			using (SqlConnection con = GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}

					con.Open();
					rows = cmd.ExecuteNonQuery();
				}
			}

			return rows;
		}

		// Execute SELECT and return DataTable
		public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
		{
			DataTable dt = new DataTable();

			using (SqlConnection con = GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}

					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
					{
						da.Fill(dt);
					}
				}
			}

			return dt;
		}

		// Execute Scalar (COUNT, SUM, MAX, etc.)
		public object ExecuteScalar(string query, SqlParameter[] parameters = null)
		{
			object result;

			using (SqlConnection con = GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					if (parameters != null)
					{
						cmd.Parameters.AddRange(parameters);
					}

					con.Open();
					result = cmd.ExecuteScalar();
				}
			}

			return result;
		}
	}
}