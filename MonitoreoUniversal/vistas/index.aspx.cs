using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonitoreoUniversal
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string auth = HttpContext.Current.Session["Autenticacion"].ToString();
                    if (auth.Equals("false"))
                    {
                        Session.Clear();
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                    }
                }
                catch (Exception exp)
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx");
                }

                return;
            }
        }
    }
}