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
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string param = Request.QueryString["id"];
                if (param != null)
                {
                    Producto pBuscar = new Producto(int.Parse(Request.QueryString["id"]));
                    Producto producto = NegProducto.buscarProducto(pBuscar);
                    txtDescripcion.Attributes["placeholder"] = producto.Descripcion;
                    txtFechaV.Attributes["placeholder"] = producto.Fecha_vencimiento.ToString();
                    txtPrecio.Attributes["placeholder"] = producto.Precio.ToString();
                    txtStock.Attributes["placeholder"] = producto.Stock.ToString();
                    ddTipoProducto.SelectedValue = producto.Tipo_producto_id.ToString();

                    btnAgregar.Text = "Modificar";

                }

                if (!IsPostBack)
                {
                    ddTipoProducto.DataSource = NegTipoProducto.listarTodos();
                    ddTipoProducto.DataValueField = "id";
                    ddTipoProducto.DataTextField = "descripcion";
                    ddTipoProducto.DataBind();
                }
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtDescripcion.Text.Length < 1)
            {
                txtDescripcion.Text = txtDescripcion.Attributes["placeholder"];
            }
            if (txtFechaV.Text.Length < 1)
            {
                txtFechaV.Text = txtFechaV.Attributes["placeholder"];
            }
            if (txtPrecio.Text.Length < 1)
            {
                txtPrecio.Text = txtPrecio.Attributes["placeholder"];
            }
            if (txtStock.Text.Length < 1)
            {
                txtStock.Text = txtStock.Attributes["placeholder"];
            }


            int result;

            if (txtDescripcion.Text.Length < 1)
            {
                lblErrDes.Text = "Debe ingresar una descripcion.";
                lblErrDes.Visible = true;

                return;
            }

            else if (txtDescripcion.Text.Length > 20)
            {
                lblErrDes.Text = "Descripcion demaciado larga.";
                lblErrDes.Visible = true;

                return;
            }

            else if(int.TryParse(txtDescripcion.Text, out result))
            {
                lblErrDes.Text = "La descripcion no puede contener numeros.";
                lblErrDes.Visible = true;

                return;
            }

            lblErrDes.Visible = false;

            if(txtFechaV.Text.Length < 1)
            {
                lblErrFec.Text = "Debe ingresar una fecha de vencimiento.";
                lblErrFec.Visible = true;
                return;
            }

            else if(txtFechaV.Text.Length > 40)
            {
                lblErrFec.Text = "Formato incorrecto en fecha de vencimiento.";
                lblErrFec.Visible = true;

                return;
            }

            lblErrFec.Visible = false;

            if (txtPrecio.Text.Length < 1)
            {
                lblErrPre.Text = "Debe ingresar un precio.";
                lblErrPre.Visible = true;

                return;
            }

            else if(!int.TryParse(txtPrecio.Text, out result))
            {
                lblErrPre.Text = "El precio no puede contener caracteres.";
                lblErrPre.Visible = true;

                return;
            }


            else if(txtPrecio.Text.Length < 1)
            {
                lblErrPre.Text = "Precio ingresado demaciado corto.";
                lblErrPre.Visible = true;

                return;
            }

            lblErrPre.Visible = false;


            if (txtStock.Text.Length < 1)
            {
                lblErrSto.Text = "Debe ingresar un stock.";
                lblErrSto.Visible = true;

                return;
            }

            else if (!int.TryParse(txtStock.Text, out result))
            {
                lblErrSto.Text = "El stock no puede contener caracteres.";
                lblErrSto.Visible = true;

                return;
            }


            else if (txtStock.Text.Length < 1)
            {
                lblErrSto.Text = "Stock ingresado demaciado corto.";
                lblErrSto.Visible = true;

                return;
            }

            lblErrSto.Visible = false;


            if (ddTipoProducto.SelectedItem.Text.Equals(""))
            {
                lblErrTiP.Text = "Debe seleccionar un Tipo de Producto.";
                lblErrTiP.Visible = true;

                return;
            }

            lblErrDes.Visible = false;
            lblErrFec.Visible = false;
            lblErrPre.Visible = false;
            lblErrTiP.Visible = false;

            string param = Request.QueryString["id"];

            if (param != null)
            {


                Producto actProducto = new Producto(int.Parse(param),
                                                        txtDescripcion.Text,
                                                        DateTime.Parse(txtFechaV.Text).Date,
                                                        int.Parse(txtPrecio.Text),
                                                        int.Parse(txtStock.Text),
                                                        int.Parse(ddTipoProducto.SelectedValue.ToString()));

                if (NegProducto.ActualizarProducto(actProducto))
                {
                    string script = "alert('Producto Actualizado.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);


                }
                else
                {
                    string script = "alert('Hubo un problema actualizando el Producto.');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                }


                Response.Redirect("listarProductos.aspx");

            }


            Producto producto = new Producto(
                txtDescripcion.Text,
                DateTime.Parse(txtFechaV.Text),
                int.Parse(txtPrecio.Text),
                int.Parse(txtStock.Text),
                int.Parse(ddTipoProducto.SelectedValue.ToString()));

            

            if (NegProducto.CrearProducto(producto))
            {
                string script = "alert('Producto Creado.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                txtDescripcion.Text = "";
                txtFechaV.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
                return;
            }
            else
            {
                string script = "alert('Ha ocurrido un problema creando el producto.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                return;
            }


        }
    }
}