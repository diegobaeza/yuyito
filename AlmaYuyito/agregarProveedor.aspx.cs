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
    public partial class agregarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string param = Request.QueryString["id"];
                if (param != null)
                {
                    Proveedor pBuscar = new Proveedor(int.Parse(Request.QueryString["id"]));
                    Proveedor proveedor = NegProveedor.buscarProveedor(pBuscar);
                    txtNombre.Attributes["placeholder"] = proveedor.Nombre;
                    txtDireccion.Attributes["placeholder"] = proveedor.Direccion;
                    txtTelefono.Attributes["placeholder"] = proveedor.Telefono.ToString();
                    ddRubro.SelectedValue = proveedor.Rubro_id.ToString();
                    btnAgregar.Text = "Modificar";
  
                }

                if (!IsPostBack)
                {
                    ddRubro.DataSource = NegRubro.listarTodos();
                    ddRubro.DataValueField = "id";
                    ddRubro.DataTextField = "descripcion";
                    ddRubro.DataBind();
                }               
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtNombre.Text.Length < 1)
            {
                txtNombre.Text = txtNombre.Attributes["placeholder"];
            }
            if (txtDireccion.Text.Length < 1)
            {
                txtDireccion.Text = txtDireccion.Attributes["placeholder"];
            }
            if (txtTelefono.Text.Length < 1)
            {
                txtTelefono.Text = txtTelefono.Attributes["placeholder"];
            }

            int result;

            if (txtNombre.Text.Length < 1)
            {
                lblErrNom.Text = "Debe ingresar un nombre.";
                lblErrNom.Visible = true;

                return;
            }

            else if (txtNombre.Text.Length > 20)
            {
                lblErrNom.Text = "Nombre demasiado largo.";
                lblErrNom.Visible = true;

                return;
            }

            else if(int.TryParse(txtNombre.Text, out result))
            {
                lblErrNom.Text = "El nombre no puede contener numeros.";
                lblErrNom.Visible = true;

                return;
            }

            lblErrNom.Visible = false;

            if(txtDireccion.Text.Length < 1)
            {
                lblErrDir.Text = "Debe ingresar una direccion.";
                lblErrDir.Visible = true;
                return;
            }

            else if(txtDireccion.Text.Length > 40)
            {
                lblErrDir.Text = "Direccion demaciado larga.";
                lblErrDir.Visible = true;

                return;
            }

            lblErrDir.Visible = false;

            if (txtTelefono.Text.Length < 1)
            {
                lblErrTel.Text = "Debe ingresar un numero de telefono.";
                lblErrTel.Visible = true;

                return;
            }

            else if(!int.TryParse(txtTelefono.Text, out result))
            {
                lblErrTel.Text = "El telefono no puede contener caracteres.";
                lblErrTel.Visible = true;

                return;
            }


            else if(txtTelefono.Text.Length < 5)
            {
                lblErrTel.Text = "Telefono ingresado demaciado corto.";
                lblErrTel.Visible = true;

                return;
            }

            else if(txtTelefono.Text.Length > 9)
            {
                lblErrTel.Text = "Telefono ingresado demasiado largo.";
                lblErrTel.Visible = true;

                return;
            }

            lblErrTel.Visible = false;

            if (ddRubro.SelectedItem.Text.Equals(""))
            {
                lblErrRubr.Text = "Debe seleccionar un rubro.";
                lblErrRubr.Visible = true;

                return;
            }

            lblErrNom.Visible = false;
            lblErrDir.Visible = false;
            lblErrTel.Visible = false;
            lblErrRubr.Visible = false;

            string param = Request.QueryString["id"];

            if (param != null)
            {


                Proveedor actProveedor = new Proveedor(int.Parse(param), 
                                                        txtNombre.Text, 
                                                        txtDireccion.Text, 
                                                        int.Parse(txtTelefono.Text), 
                                                        '1',
                                                        int.Parse(ddRubro.SelectedValue.ToString()));

                if (NegProveedor.ActualizarProveedor(actProveedor))
                {
                    string script = "alert('Proveedor Actualizado.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);


                }
                else
                {
                    string script = "alert('Hubo un problema actualizando el Proveedor.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                }


                Response.Redirect("listarProveedores.aspx");

            }


            Proveedor proveedor = new Proveedor(
                txtNombre.Text,
                txtDireccion.Text,
                int.Parse(txtTelefono.Text),
                '1',
                int.Parse(ddRubro.SelectedValue.ToString()));

            

            if (NegProveedor.CrearProveedor(proveedor))
            {
                string script = "alert('Proveedor Creado.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                return;
            }
            else
            {
                string script = "alert('Ha ocurrido un problema creado el proveedor.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                return;
            }


        }
    }
}