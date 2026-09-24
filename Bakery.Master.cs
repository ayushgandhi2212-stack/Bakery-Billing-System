using System;

namespace BakeryBillingSystem
{
	public partial class Bakery : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["Username"] != null)
			{
				lblUser.Text = "👤 Welcome, " + Session["Username"].ToString();
			}

			string pageName = System.IO.Path.GetFileName(Request.Path);

			if (pageName.Equals("Login.aspx", StringComparison.OrdinalIgnoreCase))
			{
				btnLogout.Visible = false;
				lblUser.Visible = false;
			}
			else
			{
				btnLogout.Visible = (Session["Username"] != null);
				lblUser.Visible = (Session["Username"] != null);
			}
		}
		protected void btnLogout_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Session.Abandon();

			Response.Redirect("Login.aspx");
		}
	}
}