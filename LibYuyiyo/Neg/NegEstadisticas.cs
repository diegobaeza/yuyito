using LibYuyiyo.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Neg
{
    public class NegEstadisticas
    {
        public static DataTable traerInformacionIngresos()
        {
            DataTable dt = DaoEstadisticas.sqlTraerDatosIngresos();
           
            return dt;

        }

        public static DataTable traerInformacionProductos()
        {
            DataTable dt = DaoEstadisticas.sqlTraerDatosProductos();

            return dt;

        }
    }
}
