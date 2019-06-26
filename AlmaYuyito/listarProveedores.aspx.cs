using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibYuyiyo.Entidades;
using LibYuyiyo.Neg;

namespace AlmaYuyito
{
    public partial class listarProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = NegProveedor.listarProveedores();
            gvProveedores.DataSource = dt;
            gvProveedores.DataBind();
        }


        protected void btnEliminar_Click(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = (GridViewRow)gvProveedores.Rows[e.RowIndex];

            Proveedor proveedor = new Proveedor(
                int.Parse(row.Cells[2].Text));


            if (NegProveedor.EliminarProveedor(proveedor))
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
            this.gvProveedores.DataSource = null;

            DataTable dt = NegProveedor.listarProveedores();
            gvProveedores.DataSource = dt;

            gvProveedores.DataBind();

        }

        protected void btnEditar_Click(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvProveedores.Rows[e.NewEditIndex];

            int valor = int.Parse(row.Cells[2].Text);

            Response.Redirect("agregarProveedor.aspx?id=" + valor);



        }
    }
}