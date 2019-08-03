using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace part4
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                LoginLabel.Text = "Welcome to our site";
                LoginLink.Text = "Login";
                SignoutLink.Visible = false;
                SignupLink.Visible = true;
                LoginLink.Visible = true;
            }
            else
            {
                LoginLabel.Text = "Welcome back, " + Session["Username"].ToString();
                LoginLink.Visible = false;
                SignupLink.Visible = false;
                SignoutLink.Visible = true;
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect(Page.Request.Url.ToString(), true);
 
        }
    }
}