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
    public partial class listarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = NegProducto.listarProductos();
            gvProductos.DataSource = dt;
            gvProductos.DataBind();
        }

        protected void btnEliminar_Click(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = (GridViewRow)gvProductos.Rows[e.RowIndex];

            Producto producto = new Producto(
                int.Parse(row.Cells[2].Text));


            if (NegProducto.EliminarProducto(producto))
            {

                string script = "alert(\"Eliminado\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

            }
            else
            {
                string script = "alert(\"No se pudo eliminar\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }

            recargarLista();


        }

        public void recargarLista()
        {
            this.gvProductos.DataSource = null;

            DataTable dt = NegProducto.listarProductos();
            gvProductos.DataSource = dt;

            gvProductos.DataBind();

        }


        protected void btnEditar_Click(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvProductos.Rows[e.NewEditIndex];

            int valor = int.Parse(row.Cells[2].Text);

            Response.Redirect("agregarProducto.aspx?id=" + valor);



        }
    }
}