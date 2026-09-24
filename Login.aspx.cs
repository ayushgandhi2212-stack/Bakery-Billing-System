using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BakeryBillingSystem
{
	public partial class Login : Page
	{
		DBHelper db = new DBHelper();


		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Username"] != null)
			{
				Response.Redirect("Billing.aspx");
			}
		}
		protected void btnLogin_Click(object sender, EventArgs e)
		{
			string query = "SELECT * FROM Login WHERE Username=@Username AND Password=@Password";

			SqlParameter[] parameters =
			{
		new SqlParameter("@Username", txtUsername.Text.Trim()),
		new SqlParameter("@Password", txtPassword.Text.Trim())
	};

			DataTable dt = db.ExecuteQuery(query, parameters);

			if (dt.Rows.Count > 0)
			{
				Session["Username"] = txtUsername.Text.Trim();
				Response.Redirect("~/Billing.aspx", false);
				Context.ApplicationInstance.CompleteRequest();
			}
			else
			{
				lblMessage.Text = "Invalid Username or Password";
				lblMessage.ForeColor = System.Drawing.Color.Red;
			}
		}
		//protected void btnLogin_Click(object sender, EventArgs e)
		//{
		//	string query = "SELECT * FROM Login WHERE Username=@Username AND Password=@Password";

		//	SqlParameter[] parameters =
		//	{
		//		new SqlParameter("@Username", txtUsername.Text.Trim()),
		//		new SqlParameter("@Password", txtPassword.Text.Trim())
		//	};

		//	DataTable dt = db.ExecuteQuery(query, parameters);

		//	if (dt.Rows.Count > 0)
		//	{
		//		Session["Username"] = txtUsername.Text.Trim();
		//		Response.Redirect("Billing.aspx");
		//	}
		//	else
		//	{
		//		lblMessage.Text = "Invalid Username or Password";
		//		lblMessage.ForeColor = System.Drawing.Color.Red;
		//	}
		//}
		//	protected void btnLogin_Click(object sender, EventArgs e)
		//	{
		//		string query = "SELECT * FROM Login WHERE Username=@Username AND Password=@Password";

		//		SqlParameter[] parameters =
		//		{
		//	new SqlParameter("@Username", txtUsername.Text.Trim()),
		//	new SqlParameter("@Password", txtPassword.Text.Trim())
		//};

		//		DataTable dt = db.ExecuteQuery(query, parameters);

		//		lblMessage.Text = "Rows Found = " + dt.Rows.Count;

		//		if (dt.Rows.Count > 0)
		//		{
		//			Session["Username"] = txtUsername.Text.Trim();
		//			Response.Redirect("Billing.aspx");
		//		}
		//	}
	}
}