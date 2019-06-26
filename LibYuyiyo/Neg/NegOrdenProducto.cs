using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibYuyiyo.Entidades;
using LibYuyiyo.DAO;
using System.Data;

namespace LibYuyiyo.Neg
{
    public static class NegOrdenProducto
    {
        public static bool CrearOrdenProducto(OrdenProducto ordenProducto)
        {
            int respuesta = 0;

            if (DaoOrdenProducto.sqlExiste(ordenProducto))
            {

                respuesta = DaoOrdenProducto.sqlActualizar(ordenProducto);

            }
            else
            {
                respuesta = DaoOrdenProducto.sqlAgregar(ordenProducto);
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
  

        public static bool ActualizarOrdenProducto(OrdenProducto ordenProducto)
        {
            int respuesta = 0;

            respuesta = DaoOrdenProducto.sqlActualizar(ordenProducto);


            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static OrdenProducto buscarOrdenProducto(OrdenProducto ordenProducto)
        {
            DataTable dt = DaoOrdenProducto.sqlLeer(ordenProducto);

            OrdenProducto op = new OrdenProducto(int.Parse(dt.Rows[0]["Id"].ToString()),
                                        DateTime.Parse(dt.Rows[0]["Fecha_recepcion"].ToString()),
                                        DateTime.Parse(dt.Rows[0]["Fecha_emision"].ToString()),
                                        dt.Rows[0]["Estado"].ToString()[0],
                                        int.Parse(dt.Rows[0]["Total"].ToString()),
                                        int.Parse(dt.Rows[0]["Usuario_id"].ToString()),
                                        int.Parse(dt.Rows[0]["Proveedor_id"].ToString()));
            return op;
        }

        public static bool EliminarOrdenProducto(OrdenProducto ordenProducto)
        {
            int respuesta = 0;

            if (DaoOrdenProducto.sqlExiste(ordenProducto))
            {

                respuesta = DaoOrdenProducto.sqlEliminar(ordenProducto);

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
