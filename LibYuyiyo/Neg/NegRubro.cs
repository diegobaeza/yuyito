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
    public class NegRubro
    {
        public static bool CrearRubro(Rubro rubro)
        {
            int respuesta = 0;

            if (DaoRubro.sqlExiste(rubro))
            {

                respuesta = DaoRubro.sqlActualizar(rubro);

            }
            else
            {
                respuesta = DaoRubro.sqlAgregar(rubro);
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

        public static bool ActualizarRubro(Rubro rubro)
        {
            int respuesta = 0;

            respuesta = DaoRubro.sqlActualizar(rubro);


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
            return DaoRubro.sqlLeerTodos();
        }
        public static bool EliminarRubro(Rubro rubro)
        {
            int respuesta = 0;

            if (DaoRubro.sqlExiste(rubro))
            {

                respuesta = DaoRubro.sqlEliminar(rubro);

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

        public static bool VerificarRubro(Rubro rubro)
        {
            int respuesta = 0;

            if (DaoRubro.sqlDepende(rubro))
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

        public static Rubro BuscarRubro(Rubro rubro)
        {
            DataTable dt = DaoRubro.sqlLeer(rubro);

            Rubro newRubro = new Rubro(int.Parse(dt.Rows[0]["Id"].ToString()), dt.Rows[0]["Descripcion"].ToString());
            return newRubro;
        }
    }

}
