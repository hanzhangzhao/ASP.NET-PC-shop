﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace part4
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.FindControl("CostOfCurrentConfigurationLabel").Visible = false;
        }
    }
}