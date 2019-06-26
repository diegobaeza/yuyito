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
    public partial class nuevoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddTipoUsuario.DataSource = NegUsuario.listarTipoUsuario();
                ddTipoUsuario.DataValueField = "id";
                ddTipoUsuario.DataTextField = "descripcion";
                ddTipoUsuario.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //if (txtDescripcion.Text.Length < 1)
            //{
            //    txtDescripcion.Text = txtDescripcion.Attributes["placeholder"];
            //}
            //if (txtFechaV.Text.Length < 1)
            //{
            //    txtFechaV.Text = txtFechaV.Attributes["placeholder"];
            //}
            //if (txtPrecio.Text.Length < 1)
            //{
            //    txtPrecio.Text = txtPrecio.Attributes["placeholder"];
            //}
            //if (txtStock.Text.Length < 1)
            //{
            //    txtStock.Text = txtStock.Attributes["placeholder"];
            //}


            int result;

            if (txtUsuario.Text.Length < 1)
            {
                lblErrUsu.Text = "Debe ingresar un nombre de usuario.";
                lblErrUsu.Visible = true;

                return;
            }

            else if (txtUsuario.Text.Length > 20)
            {
                lblErrUsu.Text = "Nombre de usuario demaciado largo.";
                lblErrUsu.Visible = true;

                return;
            }


            lblErrUsu.Visible = false;

            if (txtContra.Text.Length < 1)
            {
                lblErrCont.Text = "Debe ingresar una contraseña.";
                lblErrCont.Visible = true;

                return;
            }

            else if (txtContra.Text.Length > 50)
            {
                lblErrCont.Text = "Contraseña demaciado larga.";
                lblErrCont.Visible = true;

                return;
            }


            lblErrCont.Visible = false;


            if (txtCorreo.Text.Length < 1)
            {
                lblErrCorr.Text = "Debe ingresar un correo.";
                lblErrCorr.Visible = true;

                return;
            }

            else if (txtCorreo.Text.Length > 50)
            {
                lblErrCorr.Text = "Correo demaciado largo.";
                lblErrCorr.Visible = true;

                return;
            }


            lblErrCorr.Visible = false;


            if (txtNombre.Text.Length < 1)
            {
                lblErrNom.Text = "Debe ingresar un Nombre.";
                lblErrNom.Visible = true;

                return;
            }

            else if (txtNombre.Text.Length > 50)
            {
                lblErrNom.Text = "Nombre demaciado largo.";
                lblErrNom.Visible = true;

                return;
            }


            lblErrNom.Visible = false;


            if (txtApellido.Text.Length < 1)
            {
                lblErrApe.Text = "Debe ingresar un Apellido.";
                lblErrApe.Visible = true;

                return;
            }

            else if (txtApellido.Text.Length > 50)
            {
                lblErrApe.Text = "Apellido demaciado largo.";
                lblErrApe.Visible = true;

                return;
            }


            lblErrApe.Visible = false;

            if (txtFechaN.Text.Length < 1)
            {
                lblErrFN.Text = "Debe ingresar una fecha de vencimiento.";
                lblErrFN.Visible = true;
                return;
            }

            else if (txtFechaN.Text.Length > 40)
            {
                lblErrFN.Text = "Formato incorrecto en fecha de vencimiento.";
                lblErrFN.Visible = true;

                return;
            }

            lblErrFN.Visible = false;


            if (ddTipoUsuario.SelectedItem.Text.Equals(""))
            {
                lblErrTiU.Text = "Debe seleccionar un Tipo de Usuario.";
                lblErrTiU.Visible = true;

                return;
            }

            lblErrUsu.Visible = false;
            lblErrCont.Visible = false;
            lblErrCorr.Visible = false;
            lblErrNom.Visible = false;
            lblErrApe.Visible = false;
            lblErrFN.Visible = false;
            lblErrTiU.Visible = false;

            //string param = Request.QueryString["id"];

            //if (param != null)
            //{


            //    Producto actProducto = new Producto(int.Parse(param),
            //                                            txtDescripcion.Text,
            //                                            DateTime.Parse(txtFechaV.Text).Date,
            //                                            int.Parse(txtPrecio.Text),
            //                                            int.Parse(txtStock.Text),
            //                                            int.Parse(ddTipoProducto.SelectedValue.ToString()));

            //    if (NegProducto.ActualizarProducto(actProducto))
            //    {
            //        string script = "alert('Producto Actualizado.');";

            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);


            //    }
            //    else
            //    {
            //        string script = "alert('Hubo un problema actualizando el Producto.');";

            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
            //    }


            //    Response.Redirect("listarProductos.aspx");

            //}


            Usuario usuario = new Usuario(
                txtUsuario.Text,
                txtContra.Text,
                txtCorreo.Text,
                txtNombre.Text,
                txtApellido.Text,
                DateTime.Parse(txtFechaN.Text),
                '1',
                int.Parse(ddTipoUsuario.SelectedValue.ToString()));



            if (NegUsuario.CrearUsuario(usuario))
            {
                string script = "alert('Usuario Creado.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                txtUsuario.Text = "";
                txtContra.Text = "";
                txtCorreo.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtFechaN.Text = "";
                
                return;
            }
            else
            {
                string script = "alert('Ha ocurrido un problema creando el usuario.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                return;
            }
        }
    }
}