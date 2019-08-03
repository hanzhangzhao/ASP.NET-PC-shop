using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace part4
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
            FeedbackErrorLabel.Visible = false;

            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand feedbackCommand = new MySqlCommand(@"SELECT username, feedbackText FROM feedback", con))
                {
                    using (MySqlDataReader reader = feedbackCommand.ExecuteReader())
                    {
                        this.FeedbackDisp.DataSource = reader;
                        this.FeedbackDisp.DataBind();
                        reader.Dispose();
                    }
                    feedbackCommand.Dispose();

                }
                con.Close();
            }
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('Please login to leave feedbacks.');window.location='/Login.aspx';</script>");
            }
            else
            {
                FeedbackName.Text = Session["username"].ToString();
            }

        }
        public void FeedbackSubmit(object sender, EventArgs e)
        {
            var submited = true;
            submited = submited & CheckNameEmpty();
            submited = submited & CheckFbEmpty();

            if (submited)
            {
                string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    using (MySqlCommand feedbackCommand = new MySqlCommand(@"INSERT INTO feedback(username, feedbackText) VALUES(@username, @feedbackText)", con))
                    {
                        feedbackCommand.Parameters.AddWithValue("@username", Session["username"]);
                        feedbackCommand.Parameters.AddWithValue("@feedbackText", this.FeedbackContent.Text);
                        int affectedRows = feedbackCommand.ExecuteNonQuery();
                    }

                    using (MySqlCommand feedbackCommand = new MySqlCommand(@"SELECT username, feedbackText FROM feedback", con))
                    {
                        using (MySqlDataReader reader = feedbackCommand.ExecuteReader())
                        {
                            this.FeedbackDisp.DataSource = reader;
                            this.FeedbackDisp.DataBind();
                            reader.Dispose();
                        }
                        feedbackCommand.Dispose();

                    }
                }

                FeedbackErrorLabel.Text = "Your feedback has been succussfully sent.";
                FeedbackErrorLabel.ForeColor = System.Drawing.Color.Red;
                FeedbackName.Text = String.Empty;
                FeedbackContent.Text = String.Empty;
            }
            else
            {
                FeedbackErrorLabel.Visible = true;
            }
        }

        protected void TextChanged(object sender, EventArgs e) => CheckNameEmpty();

        private bool CheckNameEmpty()
        {
            bool valid = !string.IsNullOrEmpty(FeedbackName.Text);
            return valid;
            throw new NotImplementedException();
        }

        protected void FeedbackTextChanged(object sender, EventArgs e) => CheckFbEmpty();

        private bool CheckFbEmpty()
        {
            bool valid = !string.IsNullOrEmpty(FeedbackContent.Text);
            return valid;
        }
    }


}