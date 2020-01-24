using MonitoreoUniversal.Negocio;
using MonitoreUniversal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonitoreoUniversal.vistas
{
    public partial class Login : System.Web.UI.Page
    {

        public static void CerrarSesion()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string auths = HttpContext.Current.Session["Autenticacion"].ToString();
                    if (auths.Equals("true"))
                    {
                        Response.Redirect("index.aspx");
                    }


                }
                catch (Exception exp)
                {
                    CerrarSesion();
                }

                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Session["Autenticacion"] = "false";

            CredencialesAccesoNegocio metodos = new CredencialesAccesoNegocio();

            List<CredencialesAcceso> credencialesAccesos = metodos.getAllCredencialesAcceso(user.Text);
            int cont = credencialesAccesos.Count();
            if (cont>0) {
                if (password.Text == credencialesAccesos[0].constraseña)
                {
                    Session["Autenticacion"] = "true";
                    Session["nombreUsuario"] = credencialesAccesos[0].nombreUsuario;
                    Session["idUsuario"] = credencialesAccesos[0].usuarios.idUsuario;
                    Session["nombre"] = credencialesAccesos[0].usuarios.nombre;
                    Session["apellidoP"] = credencialesAccesos[0].usuarios.apellidoP;
                    Session["apellidoM"] = credencialesAccesos[0].usuarios.apellidoM;
                    Session["correo"] = credencialesAccesos[0].usuarios.correo;

                    user.Text = "";
                    password.Text = "";

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "script", "llamar();", true);

                }
                else {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "toastr.warning('la contraseña no coincide con la informacion','¡Lo sentimos!')", true);
                }
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "toastr.warning('No estas registrado en Monitor 360°','¡Lo sentimos!')", true);
            }
        }
    }
}