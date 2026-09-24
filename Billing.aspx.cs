using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BakeryBillingSystem
{
	public partial class Billing : Page
	{
		DBHelper db = new DBHelper();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Username"] == null)
			{
				Response.Redirect("Login.aspx");
				return;
			}

			if (!IsPostBack)
			{
				LoadProducts();
			}
		}

		private void LoadProducts()
		{
			string query = "SELECT ProductId, ProductName FROM Products";

			DataTable dt = db.ExecuteQuery(query);

			ddlProduct.DataSource = dt;
			ddlProduct.DataTextField = "ProductName";
			ddlProduct.DataValueField = "ProductId";
			ddlProduct.DataBind();

			ddlProduct.Items.Insert(0, "Select Product");
		}

		protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ddlProduct.SelectedIndex > 0)
			{
				string query = "SELECT Price FROM Products WHERE ProductId=@ProductId";

				SqlParameter[] parameters =
				{
					new SqlParameter("@ProductId", ddlProduct.SelectedValue)
				};

				DataTable dt = db.ExecuteQuery(query, parameters);

				if (dt.Rows.Count > 0)
				{
					txtPrice.Text = dt.Rows[0]["Price"].ToString();
				}
			}
			else
			{
				txtPrice.Text = "";
			}
		}

		protected void btnCalculate_Click(object sender, EventArgs e)
		{
			if (ddlProduct.SelectedIndex == 0)
			{
				lblTotal.Text = "Select Product";
				return;
			}

			decimal price = Convert.ToDecimal(txtPrice.Text);
			int qty = Convert.ToInt32(txtQty.Text);

			decimal total = price * qty;

			lblTotal.Text = "₹ " + total.ToString("0.00");
		}

		protected void btnSaveBill_Click(object sender, EventArgs e)
		{
			decimal total = Convert.ToDecimal(txtPrice.Text) * Convert.ToInt32(txtQty.Text);

			string query = @"INSERT INTO Bills
                            (CustomerName, TotalAmount)
                            VALUES
                            (@CustomerName,@TotalAmount)";

			SqlParameter[] parameters =
			{
				new SqlParameter("@CustomerName", txtCustomer.Text),
				new SqlParameter("@TotalAmount", total)
			};

			int rows = db.ExecuteNonQuery(query, parameters);

			if (rows > 0)
			{
				Response.Redirect("Bill.aspx");
			}
			else
			{
				lblStatus.Text = "Error while saving bill.";
			}
		}
	}
}