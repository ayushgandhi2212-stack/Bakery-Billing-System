using System;
using System.Data;

namespace BakeryBillingSystem
{
	public partial class Bill : System.Web.UI.Page
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
				LoadBill();
			}
		}

		private void LoadBill()
		{
			string query = @"SELECT TOP 1 *
                             FROM Bills
                             ORDER BY BillId DESC";

			DataTable dt = db.ExecuteQuery(query);

			if (dt.Rows.Count > 0)
			{
				lblBillId.Text = dt.Rows[0]["BillId"].ToString();
				lblCustomer.Text = dt.Rows[0]["CustomerName"].ToString();
				lblDate.Text = Convert.ToDateTime(dt.Rows[0]["BillDate"]).ToString("dd/MM/yyyy hh:mm tt");
				lblAmount.Text = "₹ " + dt.Rows[0]["TotalAmount"].ToString();
			}
		}
	}
}