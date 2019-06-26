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
    public class NegTipoProducto
    {
        public static bool CrearTipoProducto(TipoProducto tipoProducto)
        {
            int respuesta = 0;

            if (DaoTipoProducto.sqlExiste(tipoProducto))
            {

                respuesta = DaoTipoProducto.sqlActualizar(tipoProducto);

            }
            else
            {
                respuesta = DaoTipoProducto.sqlAgregar(tipoProducto);
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

        public static bool ActualizarTipoProducto(TipoProducto tipoProducto)
        {
            int respuesta = 0;

            respuesta = DaoTipoProducto.sqlActualizar(tipoProducto);


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
            return DaoTipoProducto.sqlLeerTodos();
        }

        public static bool EliminarTipoProducto(TipoProducto tipoProducto)
        {
            int respuesta = 0;

            if (DaoTipoProducto.sqlExiste(tipoProducto))
            {

                respuesta = DaoTipoProducto.sqlEliminar(tipoProducto);

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

        public static bool VerificarTipoProducto(TipoProducto tipoProducto)
        {
            int respuesta = 0;

            if (DaoTipoProducto.sqlDepende(tipoProducto))
            {

                respuesta = 1;

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

        public static TipoProducto BuscarTipoProducto(TipoProducto tipoProducto)
        {
            DataTable dt = DaoTipoProducto.sqlLeer(tipoProducto);

            TipoProducto newTipoProducto = new TipoProducto(int.Parse(dt.Rows[0]["Id"].ToString()), dt.Rows[0]["Descripcion"].ToString());
            return newTipoProducto;
        }
    }
}
