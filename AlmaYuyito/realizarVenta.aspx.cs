using LibYuyiyo.Entidades;
using LibYuyiyo.Neg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AlmaYuyito
{
    
    public partial class realizarVenta : System.Web.UI.Page
    {

        static DataTable dt = new DataTable();
        DataRow filaProducto ;


        protected void Page_Load(object sender, EventArgs e)
        {
            btnAgregarVenta.Attributes["data-toggle"] = "modal";
            btnAgregarVenta.Attributes["data-target"] = "#exampleModal";

            if (dt.Columns.Count < 1)
            {
                dt.Columns.Add("Id");
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Precio");
                filaProducto = dt.NewRow();
            }

            if (!IsPostBack)
            {

                dt = new DataTable();
                ddProductos.DataSource = NegProducto.listarTodos();
                ddProductos.DataValueField = "id";
                ddProductos.DataTextField = "descripcion";
                ddProductos.DataBind();
                
            }

            gvProductos.DataSource = dt;

            gvProductos.DataBind();
        }

        protected void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            lblErrId.Visible = false;
            lblErrCant.Visible = false;
            lblErrRut.Visible = false;
            lblErrGv.Visible = false;
            Producto producto;
            int precio;
            Producto productoTotal;
            int total = 0;

            

            if (TxtId.Text.Length > 0)
            {
                producto = NegProducto.buscarProducto(new Producto(int.Parse(TxtId.Text)));

                if (producto == null)
                {
                    lblErrId.Text = "No existe un producto con el id ingresado";
                    lblErrId.Visible = true;
                    return;
                }
                if (producto.Stock < 1)
                {
                    //No hay Stock
                    return;
                }
                int salida = 1;
                if (!int.TryParse(txtCantidad.Text.ToString(), out salida))
                {
                    lblErrCant.Text = "Debe ingresar una cantidad.";
                    lblErrCant.Visible = true;
                    return;
                }

                precio = producto.Precio * int.Parse(txtCantidad.Text);

                productoTotal = new Producto(producto.Id, producto.Descripcion, int.Parse(txtCantidad.Text), precio);

                
            }
            else
            {
                producto = NegProducto.buscarProducto(new Producto(int.Parse(ddProductos.SelectedValue.ToString())));

                if (producto == null)
                {
                    TxtId.Text = "No existe un producto con el id ingresado";
                    return;
                }

                if (producto.Stock < 1)
                {
                    //No hay Stock
                    return;
                }
                int salida = 1;
                if (!int.TryParse(txtCantidad.Text.ToString(), out salida))
                {
                    lblErrCant.Text = "Debe ingresar una cantidad.";
                    lblErrCant.Visible = true;
                    return;
                }
                precio = producto.Precio * int.Parse(txtCantidad.Text);

                productoTotal = new Producto(producto.Id, producto.Descripcion, int.Parse(txtCantidad.Text), precio);
               
     
            }

            filaProducto = dt.NewRow();

            filaProducto["Id"] = productoTotal.Id;
            filaProducto["Descripcion"] = productoTotal.Descripcion;
            filaProducto["Cantidad"] = productoTotal.Stock;
            filaProducto["Precio"] = productoTotal.Precio;

            dt.Rows.Add(filaProducto);

            

            gvProductos.DataSource = dt;

            gvProductos.DataBind();



            foreach (DataRow row in dt.Rows)
            {
                total += int.Parse(row["Precio"].ToString());
                
            }

            txtTotal.Text = total.ToString();


        }


        protected void BtnEliminarProducto_Click(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvProductos.Rows[e.RowIndex];
            int total = int.Parse(txtTotal.Text);
            total -= int.Parse(row.Cells[4].Text);
            txtTotal.Text = total.ToString();
            dt.Rows.RemoveAt(e.RowIndex);
            gvProductos.DataSource = dt;
            gvProductos.DataBind();
        }

        protected void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            if(chbFiado.Checked)
            {
                if (txtRut.Text.Length < 1)
                {
                    lblErrRut.Text = "Debe ingresar un rut.";
                    lblErrRut.Visible = true;

                    return;
                }
            }
            

            else if (txtRut.Text.Length > 9)
            {
                lblErrRut.Text = "Rut demasiado largo.";
                lblErrRut.Visible = true;

                return;
            }
            lblErrRut.Visible = false;

            if (dt.Rows.Count < 1)
            {
                lblErrGv.Text = "Debe Agregar Productos antes de finalizar la venta.";
                lblErrGv.Visible = true;

                return;
            }
            lblErrGv.Visible = false;

            


             Boleta boleta= new Boleta(
                DateTime.Now,
                int.Parse(txtTotal.Text.ToString()),
                "Direccion",
                8192334,
                '1',
                int.Parse(Session["Id"].ToString()),
                1);



            if (NegBoleta.CrearBoleta(boleta,dt))
            {
                string script = "alert('Boleta Creada.');";

                //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                TxtId.Text = "";
                txtRut.Text = "";

                dt.Clear();

                gvProductos.DataSource = dt;

                gvProductos.DataBind();

                
            }
            else
            {
                string script = "alert('Ha ocurrido un problema registrando la boleta.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);

                return;
            }
        }
    }
}