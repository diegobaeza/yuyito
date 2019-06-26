using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibYuyiyo.Entidades;
using LibYuyiyo.Neg;

namespace AlmaYuyito
{
    public partial class agregarRubro : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string param = Request.QueryString["id"];
            if (param != null)
            {
                Rubro rbuscar = new Rubro(int.Parse(Request.QueryString["id"]));
                Rubro rubro = NegRubro.BuscarRubro(rbuscar);
                txtNombre.Attributes["placeholder"]= rubro.Descripcion;
                btnAgregar.Text = "Modificar";
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int result;
            if (txtNombre.Text.Length < 1)
            {
                lblErrNom.Text = "Debe ingresar un nombre.";
                lblErrNom.Visible = true;
                return;
            }

            if (txtNombre.Text.Length > 100)
            {
                lblErrNom.Text = "Nombre ingresado demaciado largo.";
                lblErrNom.Visible = true;
                return;
            }

            if (int.TryParse(txtNombre.Text, out result))
            {
                lblErrNom.Text = "El nombre no puede contener numeros.";
                lblErrNom.Visible = true;
                return;
            }


            lblErrNom.Visible = false;


            string param = Request.QueryString["id"];

            if (param != null)
            {
                Rubro actRubro = new Rubro(int.Parse(param), txtNombre.Text);

                if (NegRubro.ActualizarRubro(actRubro))
                {
                    string script = "alert('Rubro Actualizado.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);


                }
                else
                {
                    string script = "alert('Hubo un problema actualizando el rubro.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                }


                Response.Redirect("listarRubros.aspx");

            }

            Rubro rubro = new Rubro(
                txtNombre.Text);

           

            if (NegRubro.CrearRubro(rubro)){
                string script = "alert('Rubro Creado.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);



            }
            else
            {
                string script = "alert('Hubo un problema creando el rubro.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            }

            txtNombre.Text = "";


            
        }

    }
}