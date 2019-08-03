using MySql.Data.MySqlClient;
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
    public partial class PreBuiltComp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginController.IsUserLoggedIn(this);

            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                // Specifying each column in the select statement to ensure order of output
                using (MySqlCommand fillPBSCommand = new MySqlCommand(@"SELECT cpu.brand, cpu.model, cpu.clock, cpu.core, cpu.price, 
                                                                ram.brand, ram.speed, ram.memoryType, ram.price, 
                                                                hd.brand, hd.type, hd.size, hd.price,
                                                                d.brand, d.size, d.resolution, d.responseTime, d.price,
                                                                os.brand, os.version, os.price,
                                                                pbs.id
                                                                FROM display d, hardDrive hd, OS os, processor cpu, ram, preBuilt pbs
                                                                WHERE pbs.display = d.ID AND
                                                                pbs.hardDrive = hd.ID AND
                                                                pbs.OS = os.ID AND
                                                                pbs.processor = cpu.ID AND
                                                                pbs.ram = ram.ID", con))
                {
                    using (MySqlDataReader reader = fillPBSCommand.ExecuteReader())
                    {
                        DataTable tempTable = new DataTable();
                        tempTable.Columns.Add(new DataColumn("System", typeof(string)));
                        tempTable.Columns.Add(new DataColumn("Price", typeof(string)));

                        List<PreBuilt> listOfSystems = new List<PreBuilt>();
                        while (reader.Read())
                        {

                            Processor processor = new Processor(reader[0].ToString(), reader[1].ToString(),
                                                                reader[2].ToString(), reader[3].ToString(),
                                                                reader[4].ToString());

                            // Create the RAM component
                            RAM ram = new RAM(reader[5].ToString(), reader[6].ToString(), reader[7].ToString(),
                                              reader[8].ToString());

                            // Create the Hard Drive component
                            HardDrive hardDrive = new HardDrive(reader[9].ToString(), reader[10].ToString(),
                                                                reader[11].ToString(), reader[12].ToString());

                            // Create the Display component
                            Display display = new Display(reader[13].ToString(), reader[14].ToString(),
                                                          reader[15].ToString(), reader[16].ToString(),
                                                          reader[17].ToString());

                            // Create the Operating System component
                            OS os = new OS(reader[18].ToString(), reader[19].ToString(), reader[20].ToString());

                            PreBuilt computer = new PreBuilt(reader[21].ToString(), processor, ram, hardDrive,
                                                                         display, os);
                            listOfSystems.Add(computer);

                        }
                        this.PreBuiltComputersGridView.DataSource = listOfSystems;
                        this.PreBuiltComputersGridView.DataBind();
                        this.PreBuiltComputersGridView.Columns[0].Visible = false;
                    }

                    if (!IsPostBack)
                    {
                        using (MySqlCommand getTotalPriceCommand = new MySqlCommand(@"SELECT totalPrice 
                                                                                  FROM currentOrder 
                                                                                  WHERE username=@username", con))
                        {
                            getTotalPriceCommand.Parameters.AddWithValue("@username", Session["username"]);
                            object tempPrice = getTotalPriceCommand.ExecuteScalar();
                            string totalPrice = string.Empty;
                            if (tempPrice != null)
                            {
                                totalPrice = tempPrice.ToString();
                            }
                            Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
                            if (totalCostLabel != null)
                            {
                                totalCostLabel.Text = totalPrice;
                            }
                            getTotalPriceCommand.Dispose();
                        }

                        //int componentRowIndex = -1;
                        //using (MySqlCommand getRowIndexCommand = new MySqlCommand(@"SELECT PreBuilt
                        //                                                            FROM currentOrder 
                        //                                                            WHERE username=@username", con))
                        //{
                        //    getRowIndexCommand.Parameters.AddWithValue("@username", Session["username"]);
                        //    object outputRow = getRowIndexCommand.ExecuteScalar();
                        //    if (outputRow != null)
                        //    {
                        //        componentRowIndex = Convert.ToInt32(outputRow.ToString());
                        //        getRowIndexCommand.Dispose();
                        //    }
                        //}

                        //int rowIndex = -1;
                        //foreach (GridViewRow gvr in this.PreBuiltComputersGridView.Rows)
                        //{
                        //    if (Convert.ToInt32(gvr.Cells[1].Text) == componentRowIndex)
                        //    {
                        //        rowIndex = gvr.RowIndex;
                        //        break;
                        //    }
                        //}
                        //this.PreBuiltComputersGridView.SelectRow(rowIndex);
                    }
                }

                //using (MySqlCommand tableRows = new MySqlCommand("SELECT * FROM " + tableName, con))
                //{
                //using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM ", con))
                //{
                //    DataTable tempTable = new DataTable();
                //    adapter.Fill(tempTable);
                //    gridview.DataSource = tempTable;
                //    gridview.DataBind();
                //    con.Close();
                //}
                //}
            }

            // CHECK IF "selectedPreBuiltComputerRowIndex" and "PreBuilt" exist in the session, if they do load
            // up the correct index and the data
            //if (Session["PreBuilt"] != null)
            //{
            //    this.PreBuiltComputersGridView.DataSource = Session["PreBuilt"];
            //}
            //else
            //{
            //    this.PreBuiltComputersGridView.DataSource = PreBuilt.GetAllPreBuilts();
            //    Session.Add("PreBuilt", this.PreBuiltComputersGridView.DataSource);
            //}
            //if (Session["selectedPreBuiltComputerRowIndex"] != null)
            //{
            //    this.PreBuiltComputersGridView.SelectRow((int)Session["selectedPreBuiltComputerRowIndex"]);
            //}

            //this.PreBuiltComputersGridView.DataBind();
        }

        protected void PreBuiltComputersGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gv = sender as GridView;
            if (gv.SelectedIndex == -1)
            {
                return;
            }
            List<PreBuilt> pbsList = gv.DataSource as List<PreBuilt>;
            PreBuilt pbs = pbsList[gv.SelectedIndex];
            pbs.PreBuiltIndex = gv.SelectedIndex;

            List<int> componentIndicies = new List<int>();

            string constr = ConfigurationManager.ConnectionStrings["tma3"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                con.Open();
                using (MySqlCommand getComponentIndexCommand = new MySqlCommand(@"SELECT ID, processor, hardDrive, OS, display, ram
                                                                              FROM preBuilt WHERE ID=@rowId", con))
                {
                    // +1 because the AutoIncrementing is 1 indexed
                    getComponentIndexCommand.Parameters.AddWithValue("@rowId", pbs.Id);
                    using (MySqlDataReader reader = getComponentIndexCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                componentIndicies.Add((int)reader[i]);
                            }
                        }
                    }
                    getComponentIndexCommand.Dispose();
                }

                using (MySqlCommand updateUserSelectionCommand = new MySqlCommand(@"INSERT INTO currentOrder (username, preBuilt, display, hardDrive, OS, processor, ram, totalPrice) 
                                                                               VALUES (@username, @preBuilt, @display, @hardDrive, @OS, @processor, @ram, @totalPrice)
                                                                               ON DUPLICATE KEY UPDATE username=@username, preBuilt=@preBuilt, display=@display, hardDrive=@hardDrive, 
                                                                               OS=@OS, processor=@processor, ram=@ram, totalPrice=@totalPrice", con))
                {
                    //updateUserSelectionCommand.Parameters.AddWithValue("@username", Session["username"]);
                    //updateUserSelectionCommand.Parameters.AddWithValue("@preBuilt", pbs.ToString());
                    //updateUserSelectionCommand.Parameters.AddWithValue("@display", pbs.DisplayPart);
                    //updateUserSelectionCommand.Parameters.AddWithValue("@hardDrive", pbs.HardDrivePart);
                    //updateUserSelectionCommand.Parameters.AddWithValue("@OS", pbs.OperatingSystemPart);
                    //updateUserSelectionCommand.Parameters.AddWithValue("@processor", pbs.ProcessorPart);
                    //updateUserSelectionCommand.Parameters.AddWithValue("@ram", pbs.RamPart);
                    //updateUserSelectionCommand.Parameters.AddWithValue("@totalPrice", pbs.Price.Replace("$", ""));
                    updateUserSelectionCommand.Parameters.AddWithValue("@username", Session["username"]);
                    updateUserSelectionCommand.Parameters.AddWithValue("@preBuilt", componentIndicies[0]);
                    updateUserSelectionCommand.Parameters.AddWithValue("@display", componentIndicies[4]);
                    updateUserSelectionCommand.Parameters.AddWithValue("@hardDrive", componentIndicies[2]);
                    updateUserSelectionCommand.Parameters.AddWithValue("@OS", componentIndicies[3]);
                    updateUserSelectionCommand.Parameters.AddWithValue("@processor", componentIndicies[1]);
                    updateUserSelectionCommand.Parameters.AddWithValue("@ram", componentIndicies[5]);
                    updateUserSelectionCommand.Parameters.AddWithValue("@totalPrice", pbs.Price.Replace("$", ""));
                    int affectedRows = updateUserSelectionCommand.ExecuteNonQuery();
                }
                con.Close();
            }

            //Session.Add(pbs.ProcessorPart.GetSessionName(), pbs.ProcessorPart);
            //Session.Add(pbs.RamPart.GetSessionName(), pbs.RamPart);
            //Session.Add(pbs.HardDrivePart.GetSessionName(), pbs.HardDrivePart);
            //Session.Add(pbs.DisplayPart.GetSessionName(), pbs.DisplayPart);
            //Session.Add(pbs.OperatingSystemPart.GetSessionName(), pbs.OperatingSystemPart);
            //Session.Add(pbs.SoundCardPart.GetSessionName(), pbs.SoundCardPart);
            // Keep the totalPrice stored as a double
            //Session.Add("totalPrice", Convert.ToDouble(pbs.Price.Replace("$","")));

            Label totalCostLabel = (Label)Master.FindControl("TotalCostLabel");
            if (totalCostLabel != null)
            {
                totalCostLabel.Text = pbs.Price;
            }

            //Session.Add("selectedPreBuiltComputerRowIndex", pbs.PreBuiltIndex);
        }

        protected void AddCartButton_Click(object sender, EventArgs e)
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
    }
}