using LibYuyiyo.Entidades;
using LibYuyiyo.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmaYuyito
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string param = Request.QueryString["id"];
                if (param != null)
                {
                    Cliente pBuscar = new Cliente(int.Parse(Request.QueryString["id"]));
                    Cliente cliente = NegCliente.buscarCliente(pBuscar);
                    TxtNombre.Attributes["placeholder"] = cliente.Nombre;
                    TxtApellido.Attributes["placeholder"] = cliente.Apellido;
                    TxtRut.Attributes["placeholder"] = cliente.Rut.ToString();
                    TxtEstado.Attributes["placeholder"] = cliente.Estado.ToString();

                    btnAgregar.Text = "Modificar";

                }
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (TxtNombre.Text.Length < 1)
            {
                TxtNombre.Text = TxtNombre.Attributes["placeholder"];
            }
            if (TxtApellido.Text.Length < 1)
            {
                TxtApellido.Text = TxtApellido.Attributes["placeholder"];
            }
            if (TxtRut.Text.Length < 1)
            {
                TxtRut.Text = TxtRut.Attributes["placeholder"];
            }

            int result;

            if (TxtNombre.Text.Length < 1)
            {
                lblErrNom.Text = "ingrese un nombre.";
                lblErrNom.Visible = true;
                return;
            }
            else if (TxtNombre.Text.Length > 20)
            {
                lblErrNom.Text = "nombre ingresado demasiado largo.";
                lblErrNom.Visible = true;
                return;
            }
            else if(int.TryParse(TxtNombre.Text, out result))
            {
                lblErrNom.Text = "no debe contener numeros.";
                lblErrNom.Visible = true;
                return;
            }
            lblErrNom.Visible = false;

            if (TxtApellido.Text.Length < 1)
            {
                lblErrApe.Text = "debe ingresar un apellido.";
                lblErrApe.Visible = true;
                return;
            }
            else if (TxtApellido.Text.Length > 20)
            {
                lblErrApe.Text = "apellido ingresado demasiado lardo.";
                lblErrApe.Visible = true;
                return;
            }
            else if(int.TryParse(TxtApellido.Text, out result))
            {
                lblErrApe.Text = "el apellido no debe contener numeros.";
                lblErrApe.Visible = true;
                return;
            }
            lblErrApe.Visible = false;

            if(TxtRut.Text.Length < 1)
            {
                lblErrRut.Text = "debe ingresar un Rut valido.";
                lblErrRut.Visible = true;
                return;
            }
            else if (TxtRut.Text.Length > 10)
            {
                lblErrRut.Text = "rut ingresado demasiado largo.";
                lblErrRut.Visible = true;
                return;
            }
            lblErrRut.Visible = false;

            string param = Request.QueryString["id"];
            if (param != null)
            {
               Cliente actCliente = new Cliente(int.Parse(param),
                    TxtNombre.Text,
                    TxtApellido.Text,
                    TxtRut.Text,
                    '1');

                if (NegCliente.ActualizarCliente(actCliente))
                {
                    string script = "alert('Cliente actualizado.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);


                }
                else
                {
                    string script = "alert('Hubo un problema actualizando al cliente.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                }


                Response.Redirect("");
            }


            Cliente newCliente = new Cliente(
                   TxtNombre.Text,
                   TxtApellido.Text,
                   TxtRut.Text,
                   '1');



            if (NegCliente.CrearCliente(newCliente))
            {
                string script = "alert('Cliente Registrado.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                TxtNombre.Text = "";
                TxtApellido.Text = "";
                TxtRut.Text = "";
                return;
            }
            else
            {
                string script = "alert('Ha ocurrido un problema registrando al Cliente.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                return;
            }
        }
    }
}