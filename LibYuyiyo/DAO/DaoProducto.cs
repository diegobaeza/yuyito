using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoProducto
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Producto");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(Producto producto)
        {
            String sql = String.Format("select * from Producto where Id = '{0}'", producto.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }

        public static DataTable sqlLeerConTipoProducto()
        {
            String sql = String.Format("SELECT p.Id as Id, p.Descripcion as Descripcion, p.Fecha_vencimiento as Fecha_vencimiento, p.Precio as Precio, p.Stock as Stock, r.Descripcion as nombre_tipo FROM Producto p JOIN Tipo_Producto r ON (p.Tipo_producto_id = r.Id)");
            return BD.BD.getInstance().sqlLeer(sql);
        }

        public static bool sqlExiste(Producto producto)
        {
            String sql = String.Format("select * from Producto where Id = '{0}'", producto.Id);
            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);
            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static int sqlAgregar(Producto producto)
        {
            String sql = string.Format("insert into Producto (Descripcion, Fecha_vencimiento, Precio, Stock, Tipo_producto_id) values('{0}','{1}','{2}','{3}','{4}')",
                producto.Descripcion,
                producto.Fecha_vencimiento,
                producto.Precio,
                producto.Stock,
                producto.Tipo_producto_id
                );
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(Producto producto)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Producto set Descripcion = '{1}', Fecha_vencimiento = '{2}', Precio = '{3}', Stock = '{4}', Tipo_producto_id = {5} where Id = {0}",
                producto.Id,
                producto.Descripcion,
                producto.Fecha_vencimiento,
                producto.Precio,
                producto.Stock,
                producto.Tipo_producto_id));
            return respuesta;
        }
        public static int sqlEliminar(Producto producto)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Producto where Id = {0}", producto.Id));
            return respuesta;
        }
    }
}
