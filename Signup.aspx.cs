using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace part4
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
        }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
            
                using (MySqlCommand checkUsernameCommand = new MySqlCommand("SELECT username FROM users WHERE username=@username", con))
                {
                    checkUsernameCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                    string usernameExists = (string)checkUsernameCommand.ExecuteScalar();
                    if (usernameExists == null)
                    {
                        checkUsernameCommand.Dispose();
                        using (MySqlCommand addUserCommand = new MySqlCommand(@"INSERT INTO users (username, password, securityAnswer) 
                                                                    VALUES (@username, @password, @securityAnswer)", con))
                        {
                            addUserCommand.Parameters.AddWithValue("@username", this.UsernameTextbox.Text);
                            addUserCommand.Parameters.AddWithValue("@password", this.PasswordTextBox.Text);
                            addUserCommand.Parameters.AddWithValue("@securityAnswer", this.SecurityQTextBox.Text);
                            int affectedRows = addUserCommand.ExecuteNonQuery();
                            if (affectedRows == 1)
                            {
                                addUserCommand.Dispose();
                                con.Close();
                                Response.Write("<script>alert('Sign up successful.');window.location='/Login.aspx';</script>");
                            }
                            addUserCommand.Dispose();
                        }
                        
                    }
                    else{
                        SignupErrorLabel.Text = "This Username already exist";
                        checkUsernameCommand.Dispose();
                        con.Close();
                        return;
                    }
                    con.Close();
                }
            }
        }
    }
}