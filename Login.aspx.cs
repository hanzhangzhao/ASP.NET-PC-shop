using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace part4
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;

            if (Session["username"] != null)
            {
                Response.Redirect("~/Cart.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand checkUsernameCommand = new MySqlCommand("SELECT username FROM users WHERE username=@inputtedUsername", con))
                {
                    checkUsernameCommand.Parameters.AddWithValue("@inputtedUsername", this.UsernameTextbox.Text);
                    string usernameExists = (string)checkUsernameCommand.ExecuteScalar();
                    if (usernameExists == null)
                    {
                        this.LoginErrorLabel.Text = "Username Does Not Exist";
                        this.LoginErrorLabel.Visible = true;
                        checkUsernameCommand.Dispose();
                        con.Close();
                        return;
                    }
                }

                using (MySqlCommand checkCredentialsCommand = new MySqlCommand("SELECT username FROM users WHERE username=@username AND password=@password", con))
                {
                    checkCredentialsCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                    checkCredentialsCommand.Parameters.AddWithValue("@password", this.PasswordTextBox.Text);

                    string validLoginUsername = (string)checkCredentialsCommand.ExecuteScalar();

                    if (validLoginUsername != null)
                    {
                        this.LoginErrorLabel.Text = string.Empty;
                        this.LoginErrorLabel.Visible = false;
                        Session.Add("username", validLoginUsername);
                        Session.Timeout = 60;
                        con.Close();
                        Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {
                        this.LoginErrorLabel.Text = "Invalid Username or Password";
                        this.LoginErrorLabel.Visible = true;
                        con.Close();
                    }
                }
            }
        }

        protected void PasswordRecoveryLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PasswordRecovery.aspx");
        }
    }
}