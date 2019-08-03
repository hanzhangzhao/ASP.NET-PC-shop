using MySql.Data.MySqlClient;
using part4;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace part4
{
    public partial class DIY : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginController.IsUserLoggedIn(this);
            //string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            //using (MySqlConnection con = new MySqlConnection(constr))
            //{
            //    con.Open();
            //    using (MySqlCommand processorCommand = new MySqlCommand("SELECT * FROM processor", con))
            //    {
            //        this.ProcessorGridView.DataSource = processorCommand.ExecuteReader();
            //        this.ProcessorGridView.DataBind();
            //        con.Close();
            //    }
            //}

            // Check if the user has a current order. If not, then do not display the GridView for the different parts
            if (DoesUserHaveOrder())
            {
                // Bind data from each component to their respective Gridviews
                BindDatabaseToGridview("processor", this.ProcessorGridView);
                BindDatabaseToGridview("ram", this.RAMGridView);
                BindDatabaseToGridview("hardDrive", this.HardDriveGridView);
                BindDatabaseToGridview("OS", this.OSGridView);
                BindDatabaseToGridview("display", this.DisplayGridView);

                // If the page load is not a postback, then highlight the columns retrieved from the database for
                // each gridview
                if (!IsPostBack)
                {
                    string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        con.Open();
                        SelectCurrentComponent("processor", con, this.ProcessorGridView);
                        SelectCurrentComponent("ram", con, this.RAMGridView);
                        SelectCurrentComponent("hardDrive", con, this.HardDriveGridView);
                        SelectCurrentComponent("OS", con, this.OSGridView);
                        SelectCurrentComponent("display", con, this.DisplayGridView);
                        con.Close();
                    }
                }

                // Show the gridviews and associated header labels
                this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = true;
                //this.SelectPreBuiltComputerFirstLabel.Visible = false;
                this.ProcessorLabel.Visible = true;
                this.RAMLabel.Visible = true;
                this.HardDriveLabel.Visible = true;
                this.OSLabel.Visible = true;
                this.DisplayLabel.Visible = true;
                this.AddToCartButton.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('Select a pre-built then come back.');window.location='PreBuiltComp.aspx';</script>");
                // There is no current order, so hide all gridview and labels and display the proper label text
                this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
                this.ProcessorLabel.Visible = true;
                this.RAMLabel.Visible = true;
                this.HardDriveLabel.Visible = true;
                this.OSLabel.Visible = true;
                this.DisplayLabel.Visible = true;
                this.AddToCartButton.Visible = true;
            }

        }

        //protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    // Get the gridview, update the page index, and load the new data for that page into the gridview
        //    GridView gridView = sender as GridView;
        //    gridView.PageIndex = e.NewPageIndex;
        //    gridView.DataBind();

        //    // Highlight the component in the gridview depending on which gridview was used
        //    string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        con.Open();
        //        if (gridView == this.ProcessorGridView)
        //        {
        //            SelectCurrentComponent("processor", con, gridView);
        //        }
        //        else if (gridView == this.RAMGridView)
        //        {
        //            SelectCurrentComponent("ram", con, gridView);
        //        }
        //        else if (gridView == this.HardDriveGridView)
        //        {
        //            SelectCurrentComponent("hardDrive", con, gridView);
        //        }
        //        else if (gridView == this.OSGridView)
        //        {
        //            SelectCurrentComponent("OS", con, gridView);
        //        }
        //        else if (gridView == this.DisplayGridView)
        //        {
        //            SelectCurrentComponent("display", con, gridView);
        //        }
        //    }
        //}

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridView gv = sender as GridView;
                Component component = gv.DataSource as Component;

                // If the Selected index is -1, then no row was selected on the current page
                if (gv.SelectedIndex >= 0)
                {
                    if (gv.SelectedIndex != -1)
                    {
                        string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
                        using (MySqlConnection con = new MySqlConnection(constr))
                        {
                            con.Open();
                            if (gv == this.ProcessorGridView)
                            {
                                UpdateCurrentSelection("processor", con, gv);
                            }
                            else if (gv == this.RAMGridView)
                            {
                                UpdateCurrentSelection("ram", con, gv);
                            }
                            else if (gv == this.HardDriveGridView)
                            {
                                UpdateCurrentSelection("hardDrive", con, gv);
                            }
                            else if (gv == this.OSGridView)
                            {
                                UpdateCurrentSelection("OS", con, gv);
                            }
                            else if (gv == this.DisplayGridView)
                            {
                                UpdateCurrentSelection("display", con, gv);
                            }
                            con.Close();
                        }

                        //// Get the real selected index
                        //int index = gv.SelectedIndex + (gv.PageSize * gv.PageIndex);
                        //Components component = componentList[index];
                        //Components oldComponent = Session[component.GetSessionName()] as Components;

                        //double totalPrice = (double)Session["totalPrice"];
                        //totalPrice -= oldComponent.GetPrice();
                        //totalPrice += component.GetPrice();

                        //Session.Add(component.GetSessionName(), component);
                        //Session.Add("totalPrice", totalPrice);
                        //UpdateTotalCostLabel();
                    }
                }
            }
            catch { }
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                object editId;
                using (MySqlCommand isOrderEditCommand = new MySqlCommand(@"SELECT editId FROM currentOrder WHERE username=@username", con))
                {
                    isOrderEditCommand.Parameters.AddWithValue("@username", Session["username"]);
                    editId = isOrderEditCommand.ExecuteScalar();
                    isOrderEditCommand.Dispose();
                }
                if (editId.ToString() == "")
                {
                    using (MySqlCommand saveOrderCommand = new MySqlCommand(@"INSERT INTO orders (username, preBuilt, display, hardDrive, OS, processor, ram, totalPrice)
                                                                    SELECT username, preBuilt, display, hardDrive, OS, processor, ram,totalPrice
                                                                    FROM currentOrder 
                                                                    WHERE username=@username", con))
                    {
                        saveOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                        int affectedRow = saveOrderCommand.ExecuteNonQuery();
                        saveOrderCommand.Dispose();
                    }
                }
                else
                {
                    using (MySqlCommand saveOrderCommand = new MySqlCommand(@"UPDATE orders o INNER JOIN currentOrder co ON o.ID=co.editId
                                                                          SET o.username=co.username, o.preBuilt=co.preBuilt, o.display=co.display, 
                                                                          o.hardDrive=co.hardDrive, o.OS=co.OS, o.processor=co.processor, o.ram=co.ram, 
                                                                          o.totalPrice=co.totalPrice
                                                                          WHERE co.username=@username AND o.username=@username", con))
                    {
                        saveOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                        int affectedRow = saveOrderCommand.ExecuteNonQuery();
                        saveOrderCommand.Dispose();
                    }
                }


                using (MySqlCommand deleteCurrentOrderCommand = new MySqlCommand(@"DELETE FROM currentOrder WHERE username=@username", con))
                {
                    deleteCurrentOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                    int affectedRow = deleteCurrentOrderCommand.ExecuteNonQuery();
                    deleteCurrentOrderCommand.Dispose();
                }
                con.Close();
            }

            Response.Redirect("Cart.aspx");
        }

        public void UpdateTotalCostLabel()
        {
            double totalPrice = 0;
            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand totalPriceCommand = new MySqlCommand("SELECT totalPrice FROM currentOrder WHERE username=@username ", con))
                {
                    totalPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
                    string totalPriceString = totalPriceCommand.ExecuteScalar().ToString();
                    totalPrice = Convert.ToDouble(totalPriceString.Replace("$", ""));
                }
                con.Close();
            }

            Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
            if (totalCostLabel != null)
            {
                totalCostLabel.Text = "$" + totalPrice;
            }
        }

        public GridView GetGridViewFromComponent(Component component)
        {
            return (GridView)RecurseControl(this.Master, component.GetGridView());
        }

        public Control RecurseControl(Control root, string Id)
        {
            if (root.ID == Id)
                return root;

            foreach (Control control in root.Controls)
            {
                Control foundControl = RecurseControl(control, Id);
                if (foundControl != null)
                    return foundControl;
            }

            return null;
        }

        public void BindDatabaseToGridview(string tableName, GridView gridview)
        {
            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                //using (MySqlCommand tableRows = new MySqlCommand("SELECT * FROM " + tableName, con))
                //{
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM " + tableName, con))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    gridview.Columns[0].Visible = true;
                    gridview.DataSource = tempTable;
                    gridview.DataBind();
                    gridview.Columns[0].Visible = false;
                    con.Close();
                }
                //}
            }
        }

        public void SelectCurrentComponent(string component, MySqlConnection con, GridView gv)
        {
            int componentRowIndex = -1;
            using (MySqlCommand getRowIndexCommand = new MySqlCommand("SELECT " + component +
                                                                     @" FROM currentOrder 
                                                                    WHERE username=@username", con))
            {
                getRowIndexCommand.Parameters.AddWithValue("@username", Session["username"]);
                componentRowIndex = Convert.ToInt32(getRowIndexCommand.ExecuteScalar().ToString());
                getRowIndexCommand.Dispose();
            }

            int rowIndex = -1;
            foreach (GridViewRow gvr in gv.Rows)
            {
                if (Convert.ToInt32(gvr.Cells[1].Text) == componentRowIndex)
                {
                    rowIndex = gvr.RowIndex;
                    break;
                }
            }
            gv.SelectRow(rowIndex);
            UpdateTotalCostLabel();
        }

        public void UpdateCurrentSelection(string component, MySqlConnection con, GridView gv)
        {
            double oldPrice = 0.0;
            double totalPrice = 0.0;
            using (MySqlCommand totalPriceCommand = new MySqlCommand("SELECT totalPrice FROM currentOrder WHERE username=@username", con))
            {
                totalPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
                string totalPriceString = totalPriceCommand.ExecuteScalar().ToString();
                totalPrice = Convert.ToDouble(totalPriceString.Replace("$", ""));
                totalPriceCommand.Dispose();
            }
            using (MySqlCommand getOldPriceCommand = new MySqlCommand("SELECT Price " +
                                                                      "FROM (SELECT " + component + @" as oldId
                                                                          FROM currentOrder 
                                                                          WHERE username=@username) oldIDTable, "
                                                                        + component + " componentTable" +
                                                                        " WHERE componentTable.id=oldIDTable.oldId", con))
            {
                getOldPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
                string oldPriceString = getOldPriceCommand.ExecuteScalar().ToString();
                oldPrice = Convert.ToDouble(oldPriceString.Replace("$", ""));
                getOldPriceCommand.Dispose();
            }

            // The price is always in the last column
            double newPrice = Convert.ToDouble(gv.SelectedRow.Cells[gv.Columns.Count].Text.Replace("$", ""));
            totalPrice = totalPrice - oldPrice + newPrice;

            using (MySqlCommand updateOrderCommand = new MySqlCommand("UPDATE currentOrder SET " + component + "=@component, totalPrice=@newTotal WHERE username=@username", con))
            {
                updateOrderCommand.Parameters.AddWithValue("@username", Session["username"]);
                updateOrderCommand.Parameters.AddWithValue("@component", gv.SelectedRow.Cells[1].Text);
                updateOrderCommand.Parameters.AddWithValue("@newTotal", "$" + totalPrice);
                int affectedRows = updateOrderCommand.ExecuteNonQuery();
                updateOrderCommand.Dispose();
            }
            UpdateTotalCostLabel();
        }

        public bool DoesUserHaveOrder()
        {
            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand findUserCommand = new MySqlCommand("SELECT * FROM currentOrder WHERE username=@username", con))
                {
                    findUserCommand.Parameters.AddWithValue("@username", Session["username"]);
                    using (MySqlDataReader reader = findUserCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            con.Close();
                            findUserCommand.Dispose();
                            return true;
                        }
                        findUserCommand.Dispose();
                    }
                }
                con.Close();
            }
            return false;
        }
    }
}
    //public partial class DIY : Page
    //{
    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        if (Session["processor"] != null && Session["ram"] != null && Session["hardDrive"] != null &&
    //            Session["display"] != null && Session["OS"] != null && Session["totalPrice"] != null)
    //        {
    //            List<Component> listOfProcessors = ComponentGenerator.GetAllProcessors();
    //            this.ProcessorGridView.DataSource = listOfProcessors;
    //            this.ProcessorGridView.DataBind();

    //            List<Component> listOfRAMs = ComponentGenerator.GetAllRAMs();
    //            this.RAMGridView.DataSource = listOfRAMs;
    //            this.RAMGridView.DataBind();

    //            List<Component> listOfHardDrives = ComponentGenerator.GetAllHardDrives();
    //            this.HardDriveGridView.DataSource = listOfHardDrives;
    //            this.HardDriveGridView.DataBind();

    //            List<Component> listOfOSs = ComponentGenerator.GetAllOSs();
    //            this.OSGridView.DataSource = listOfOSs;
    //            this.OSGridView.DataBind();

    //            List<Component> listOfDisplays = ComponentGenerator.GetAllDisplays();
    //            this.DisplayGridView.DataSource = listOfDisplays;
    //            this.DisplayGridView.DataBind();


    //            UpdateTotalCostLabel();

    //            if (!IsPostBack)
    //            {
    //                this.ProcessorGridView.SelectRow(Component.GetIndexOfComponent(Session["processor"] as Processor, listOfProcessors));
    //                this.RAMGridView.SelectRow(Component.GetIndexOfComponent(Session["ram"] as RAM, listOfRAMs));
    //                this.HardDriveGridView.SelectRow(Component.GetIndexOfComponent(Session["hardDrive"] as HardDrive, listOfHardDrives));
    //                this.OSGridView.SelectRow(Component.GetIndexOfComponent(Session["OS"] as OS, listOfOSs));
    //                this.DisplayGridView.SelectRow(Component.GetIndexOfComponent(Session["display"] as Display, listOfDisplays));
    //            }
    //            this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = true;
    //            this.ProcessorLabel.Visible = true;
    //            this.RAMLabel.Visible = true;
    //            this.HardDriveLabel.Visible = true;
    //            this.OSLabel.Visible = true;
    //            this.DisplayLabel.Visible = true;
    //            this.AddToCartButton.Visible = true;
    //        }
    //        else
    //        {
    //            Response.Write("<script>alert('Select a pre-built then come back.');window.location='PreBuiltComp.aspx';</script>");


    //            List<Component> listOfProcessors = ComponentGenerator.GetAllProcessors();
    //            this.ProcessorGridView.DataSource = listOfProcessors;
    //            this.ProcessorGridView.DataBind();

    //            List<Component> listOfRAMs = ComponentGenerator.GetAllRAMs();
    //            this.RAMGridView.DataSource = listOfRAMs;
    //            this.RAMGridView.DataBind();

    //            List<Component> listOfHardDrives = ComponentGenerator.GetAllHardDrives();
    //            this.HardDriveGridView.DataSource = listOfHardDrives;
    //            this.HardDriveGridView.DataBind();

    //            List<Component> listOfOSs = ComponentGenerator.GetAllOSs();
    //            this.OSGridView.DataSource = listOfOSs;
    //            this.OSGridView.DataBind();

    //            List<Component> listOfDisplays = ComponentGenerator.GetAllDisplays();
    //            this.DisplayGridView.DataSource = listOfDisplays;
    //            this.DisplayGridView.DataBind();


    //            UpdateTotalCostLabel();

    //        }
    //    }

    //    protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            GridView gv = sender as GridView;
    //            if (gv.SelectedIndex >= 0)
    //            {
    //                List<Component> componentList = gv.DataSource as List<Component>;
    //                if (gv.SelectedIndex != -1)
    //                {
    //                    if (Session["totalPrice"] != null)
    //                    {
    //                        // Get the real selected index
    //                        int index = gv.SelectedIndex + (gv.PageSize * gv.PageIndex);
    //                        Component component = componentList[index];
    //                        Component oldComponent = Session[component.GetSessionName()] as Component;

    //                        double totalPrice = (double)Session["totalPrice"];
    //                        totalPrice -= oldComponent.GetPrice();
    //                        totalPrice += component.GetPrice();

    //                        Session.Add(component.GetSessionName(), component);
    //                        Session.Add("totalPrice", totalPrice);
    //                        UpdateTotalCostLabel();
    //                    }
                        //else
                        //{
                        //Session.Add("preBuilts", PreBuilt.GetAllPreBuilts());
                        //int index = gv.SelectedIndex + (gv.PageSize * gv.PageIndex);
                        //List<PreBuilt> preBuilt = new List<PreBuilt>();
                        //Component component = componentList[index];
                        //Session.Add(component.GetSessionName(), component);
                        //double totalPrice = (double)Session["totalPrice"];

                        //Session.Add(component.GetSessionName(), component);
                        //Session.Add("totalPrice", totalPrice);
                        //UpdateTotalCostLabel();
                        //// Keep the totalPrice stored as a double

                        //PreBuilt newSystem = new PreBuilt(Session["processor"] as Component, Session["ram"] as Component,
                        //                              Session["hardDrive"] as Component, Session["display"] as Component,
                        //                              Session["OS"] as Component);
                        //Session["cart"] = new List<PreBuilt>() { newSystem };
                        //}
        //            }
        //        }
        //    }
        //    catch { }
        //}

    //    protected void AddToCartButton_Click(object sender, EventArgs e)
    //    {
    //        if (Session["processor"] != null && Session["ram"] != null && Session["hardDrive"] != null &&
    //            Session["display"] != null && Session["OS"] != null && Session["totalPrice"] != null)
    //        {
    //            PreBuilt newSystem = new PreBuilt(Session["processor"] as Component, Session["ram"] as Component,
    //                                                      Session["hardDrive"] as Component, Session["display"] as Component,
    //                                                      Session["OS"] as Component);
    //            if (Session["cart"] == null)
    //            {
    //                Session.Clear();
    //                Session["cart"] = new List<PreBuilt>() { newSystem };
    //            }
    //            else
    //            {
    //                List<PreBuilt> cartContents = Session["cart"] as List<PreBuilt>;
    //                if (Session["EditingRow"] != null)
    //                {
    //                    int rowToEdit = (int)Session["EditingRow"];
    //                    Session.Clear();
    //                    cartContents[rowToEdit] = newSystem;
    //                    Session["cart"] = cartContents;
    //                }
    //                else
    //                {
    //                    Session.Clear();
    //                    cartContents.Add(newSystem);
    //                    Session["cart"] = cartContents;
    //                }
    //            }
    //        }
    //        Response.Redirect("Cart.aspx");
    //    }

    //    public void UpdateTotalCostLabel()
    //    {
    //        Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
    //        if (totalCostLabel != null)
    //        {
    //            totalCostLabel.Text = "$" + Session["totalPrice"];
    //        }
    //    }

    //    public GridView GetGridViewFromComponent(Component component)
    //    {
    //        return (GridView)RecurseControl(this.Master, component.GetGridView());
    //    }

    //    public Control RecurseControl(Control root, string Id)
    //    {
    //        if (root.ID == Id)
    //            return root;

    //        foreach (Control control in root.Controls)
    //        {
    //            Control foundControl = RecurseControl(control, Id);
    //            if (foundControl != null)
    //                return foundControl;
    //        }

    //        return null;
    //    }
    //}
