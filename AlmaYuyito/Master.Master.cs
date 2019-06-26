using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmaYuyito
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("~/autenticacion.aspx");
            }
        }

        protected void btnSemiC_Click(object sender, EventArgs e)
        {
            string script = "semiColapsar()";

            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);

        }
        protected void btnModal_Click(object sender, EventArgs e)
        {
            /*string script = "ocultarModal()";

            ScriptManager.RegisterStartupScript(this, GetType(),
                                  "ServerControlScript", script, true);*/
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/autenticacion.aspx");
        }

        /*public void btnColapsar_Click(object sender, EventArgs e)
        {
            Control element = FindControl("nav-lateral");
            Control contenido = FindControl("contenido");
            Control icFlecha = FindControl("icono-flecha");
            Control menuParrafos = document.getElementsByClassName("item-menu-text");
            Control menuIconos = document.getElementsByClassName("item-menu-icon");
            int i;

            var lblproveedor = document.getElementById("lblProveedor");

            if (element.style.width === "4rem")
            {

                if (screen.width > 799 && screen.width < 1001)
                {
                    element.style.width = "30%";
                }
                else
                {
                    element.style.width = "15rem";
                }

                contenido.style.width = "100%";
                icFlecha.classList.add("invertir");

                for (i = 0; i < menuParrafos.length; i++)
                {
                    menuParrafos[i].classList.remove('hidden');
                }

                for (i = 0; i < menuIconos.length; i++)
                {
                    menuIconos[i].classList.remove('icon-semi-collapse');
                }

            }
            else
            {
                element.style.width = "4rem";
                contenido.style.width = "100%";
                icFlecha.classList.remove("invertir");
                for (i = 0; i < menuParrafos.length; i++)
                {
                    menuParrafos[i].classList.add('hidden');
                }

                for (i = 0; i < menuIconos.length; i++)
                {
                    menuIconos[i].classList.add('icon-semi-collapse');
                }
            }

        }*/
    }
}