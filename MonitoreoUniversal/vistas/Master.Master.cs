﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonitoreoUniversal
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string idUsuario = Session["idUsuario"].ToString();
                
            }
            catch (Exception ex)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}