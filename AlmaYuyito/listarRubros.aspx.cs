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
    public partial class listarRubros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = NegRubro.listarTodos();
            gvRubros.DataSource = dt;
            gvRubros.DataBind();

        }
        protected void btnEliminar_Click(object sender,GridViewDeleteEventArgs e)
        {
           
            GridViewRow row = (GridViewRow)gvRubros.Rows[e.RowIndex];

            Rubro rubro = new Rubro(
                int.Parse(row.Cells[2].Text)
                );

            if (NegRubro.VerificarRubro(rubro))
            {
                string script = "alert('No se puede eliminar, está siendo utilizado.');";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
                return;
            }

            if (NegRubro.EliminarRubro(rubro)){

                string script = "alert(\"Eliminado\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);

            }
            else
            {
                string script = "alert(\"No se puede eliminar, un proveedor tiene designado este rubro.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);


            }

            recargarLista();


        }

        public void recargarLista()
        {
            this.gvRubros.DataSource = null;

            DataTable dt = NegProveedor.listarProveedores();
            gvRubros.DataSource = dt;

            gvRubros.DataBind();

        }


        protected void btnEditar_Click(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvRubros.Rows[e.NewEditIndex];

            int valor = int.Parse(row.Cells[2].Text);

            Response.Redirect("agregarRubro.aspx?id=" + valor);



        }

    }
}