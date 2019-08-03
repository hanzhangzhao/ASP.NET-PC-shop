using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part4
{
    public static class LoginController
    {
        // Checks if a session is available, if not redirect the user to the Login page
        public static void IsUserLoggedIn(System.Web.UI.Page page)
        {
            if (page.Session["username"] == null)
            {
                page.Response.Redirect("~/Login.aspx");
            }
        }
    }
}