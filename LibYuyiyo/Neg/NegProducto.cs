using LibYuyiyo.DAO;
using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Neg
{
    public static class NegProducto
    {
        public static bool CrearProducto(Producto producto)
        {
            int respuesta = 0;

            if (DaoProducto.sqlExiste(producto))
            {

                respuesta = DaoProducto.sqlActualizar(producto);

            }
            else
            {
                respuesta = DaoProducto.sqlAgregar(producto);
            }


            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool ActualizarProducto(Producto producto)
        {
            int respuesta = 0;

            respuesta = DaoProducto.sqlActualizar(producto);


            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static System.Data.DataTable listarTodos()
        {
            return DaoProducto.sqlLeerTodos();
        }

        public static Producto buscarProducto(Producto producto)
        {
            DataTable dt = DaoProducto.sqlLeer(producto);

            Producto pv = new Producto(int.Parse(dt.Rows[0]["Id"].ToString()),
                                        dt.Rows[0]["Descripcion"].ToString(),
                                        DateTime.Parse(dt.Rows[0]["Fecha_vencimiento"].ToString()),
                                        int.Parse(dt.Rows[0]["Precio"].ToString()),
                                        int.Parse(dt.Rows[0]["Stock"].ToString()),
                                        int.Parse(dt.Rows[0]["Tipo_producto_id"].ToString()));

            return pv;

        }

        public static DataTable listarProductos()
        {
            return DaoProducto.sqlLeerConTipoProducto();

        }

        public static bool EliminarProducto(Producto producto)
        {
            int respuesta = 0;

            if (DaoProducto.sqlExiste(producto))
            {

                respuesta = DaoProducto.sqlEliminar(producto);

            }



            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
