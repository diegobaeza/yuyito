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
    public partial class AgregarOrdenProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string param = Request.QueryString["id"];
                if (param != null)
                {
                    OrdenProducto opBuscar = new OrdenProducto(int.Parse(Request.QueryString["id"]));
                    OrdenProducto ordenProducto = NegOrdenProducto.buscarOrdenProducto(opBuscar);
                    txtFechaR.Attributes["placeholder"] = ordenProducto.Fecha_recepcion.ToString();
                    txtFechaE.Attributes["placeholder"] = ordenProducto.Fecha_emision.ToString();
                    txtEstado.Attributes["placeholder"] = ordenProducto.Estado.ToString();
                    txtTotal.Attributes["placeholder"] = ordenProducto.Total.ToString();
                    ddUsuario.SelectedValue = ordenProducto.Usuario_id.ToString();
                    ddProveedor.SelectedValue = ordenProducto.Proveedor_id.ToString();


                }

                if (!IsPostBack)
                {
                    ddUsuario.DataSource = NegUsuario.listarTodos();
                    ddUsuario.DataValueField = "id";
                    ddUsuario.DataTextField = "nombre_user";
                    ddUsuario.DataBind();
                }
                if (!IsPostBack)
                {
                    ddProveedor.DataSource = NegProveedor.listarTodos();
                    ddProveedor.DataValueField = "id";
                    ddProveedor.DataTextField = "nombre";
                    ddProveedor.DataBind();
                }
            }


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtFechaR.Text.Length < 1)
            {
                txtFechaR.Text = txtFechaR.Attributes["placeholder"];
            }
            if (txtFechaE.Text.Length < 1)
            {
                txtFechaE.Text = txtFechaE.Attributes["placeholder"];
            }
            if (txtEstado.Text.Length < 1)
            {
                txtEstado.Text = txtEstado.Attributes["placeholder"];
            }
            if (txtTotal.Text.Length < 1)
            {
                txtTotal.Text = txtTotal.Attributes["placeholder"];
            }


            int result;

            if (txtFechaR.Text.Length < 1)
            {
                lblErrFecR.Text = "Debe ingresar una fecha.";
                lblErrFecR.Visible = true;

                return;
            }
            else if (txtFechaR.Text.Length > 40)
            {
                lblErrFecR.Text = "Formato incorrecto en fecha de recepcion.";
                lblErrFecR.Visible = true;

                return;
            }

            if (txtFechaE.Text.Length < 1)
            {
                lblErrFecE.Text = "Nombre demasiado largo.";
                lblErrFecE.Visible = true;

                return;
            }
            else if (txtFechaE.Text.Length > 40)
            {
                lblErrFecE.Text = "Formato incorrecto en fecha de emision.";
                lblErrFecE.Visible = true;

                return;
            }
             

            if (txtEstado.Text.Length < 1)
            {
                lblErrEst.Text = "Debe ingresar estado.";
                lblErrEst.Visible = true;

                return;
            }
            else if (txtEstado.Text.Length > 1)
            {
                lblErrEst.Text = " Ingrese el estado correctamente";
                lblErrEst.Visible = true;
            }

            if(txtTotal.Text.Length < 1)
            {
                lblErrTot.Text = "Ingresar Total";
                lblErrTot.Visible = true;
            }

            else if (!int.TryParse(txtTotal.Text, out result))
            {
                lblErrTot.Text = "El total no puede contener caracteres.";
                lblErrTot.Visible = true;

                return;
            }


            if (ddUsuario.SelectedItem.Text.Equals(""))
            {
                lblErrUsu.Text = "Debe seleccionar un Usuario.";
                lblErrUsu.Visible = true;

                return;
            }
            if (ddProveedor.SelectedItem.Text.Equals(""))
            {
                lblErrPro.Text = "Debe seleccionar un Usuario.";
                lblErrPro.Visible = true;

                return;
            }

            lblErrFecE.Visible = false;
            lblErrFecR.Visible = false;
            lblErrEst.Visible = false;
            lblErrPro.Visible = false;
            lblErrUsu.Visible = false;
            lblErrTot.Visible = false;

            string param = Request.QueryString["id"];

            if (param != null)
            {


                OrdenProducto modOrdenpro = new OrdenProducto(int.Parse(param),
                                                        DateTime.Parse(txtFechaR.Text).Date,
                                                        DateTime.Parse(txtFechaE.Text).Date,
                                                        '1',
                                                        int.Parse(txtTotal.Text),                                             
                                                        int.Parse(ddUsuario.SelectedValue.ToString()),
                                                        int.Parse(ddProveedor.SelectedValue.ToString()));

                if (NegOrdenProducto.ActualizarOrdenProducto(modOrdenpro))
                {
                    string script = "alert('Orden de producto Actualizada.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);


                }
                else
                {
                    string script = "alert('Hubo un problema actualizando la orden.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                }


                Response.Redirect("");

            }
            OrdenProducto opro = new OrdenProducto(
               DateTime.Parse(txtFechaR.Text),
               DateTime.Parse(txtFechaE.Text),
               '1',
               int.Parse(txtTotal.Text),
               int.Parse(ddUsuario.SelectedValue.ToString()),
               int.Parse(ddProveedor.SelectedValue.ToString()));



            if (NegOrdenProducto.CrearOrdenProducto(opro))
            {
                string script = "alert('Orden de producto Creada.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                txtFechaE.Text = "";
                txtFechaR.Text = "";
                txtEstado.Text = "";
                txtTotal.Text = "";
                ddProveedor.SelectedIndex = 0;
                ddUsuario.SelectedIndex = 0;
                return;
            }
            else
            {
                string script = "alert('Ha ocurrido un problema creando la orden de producto.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                return;
            }
        }
    }
}
