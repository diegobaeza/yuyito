using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoEstadisticas
    {
        public static DataTable sqlTraerDatosIngresos()
        {
            String sql = String.Format("SELECT MONTH(Fecha)as Mes, (Select Sum(b.Total) from Boleta b where b.Fecha = Fecha) as Total from Boleta group by Fecha;");
            return BD.BD.getInstance().sqlLeer(sql);
        }

        public static DataTable sqlTraerDatosProductos()
        {
            String sql = String.Format("SELECT TOP 5 sum(d.Cantidad) AS Vendidos, p.Descripcion as Producto FROM Detalle_Venta d JOIN Producto p ON (d.Producto_id = p.Id) group by p.Descripcion;");
            return BD.BD.getInstance().sqlLeer(sql);
        }
    }
}
