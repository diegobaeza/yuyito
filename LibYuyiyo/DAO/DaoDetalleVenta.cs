using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoDetalleVenta
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Detalle_Venta");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(Boleta boleta)
        {
            String sql = String.Format("select * from Detalle_Venta where Boleta_id = '{0}'", boleta.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }

        //public static DataTable sqlLeerConRubro()
        //{
        //    String sql = String.Format("SELECT p.Id, p.Nombre, p.Direccion, p.Telefono, p.Activo, r.Descripcion FROM Proveedor p JOIN Rubro r ON (p.Rubro_id = r.id)");
        //    return BD.BD.getInstance().sqlLeer(sql);
        //}

        public static bool sqlExiste(DetalleVenta detalleVenta)
        {
            String sql = String.Format("SELECT * FROM Detalle_Venta WHERE Id = {0}", detalleVenta.Id);

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(DetalleVenta detalleVenta)
        {
            String sql = string.Format("Insert into Detalle_Venta (Cantidad, Boleta_id, Producto_id) values('{0}','{1}','{2}')",
                                                            detalleVenta.Cantidad,
                                                            detalleVenta.Boleta_id,
                                                            detalleVenta.Producto_id
                                                            );
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(DetalleVenta detalleVenta)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Detalle_Venta set Cantidad = {1} , Boleta_id = {2}, Producto_id = {3} where Id = {0}",
                                                            detalleVenta.Id,
                                                            detalleVenta.Cantidad,
                                                            detalleVenta.Boleta_id,
                                                            detalleVenta.Producto_id));
            return respuesta;
        }

        public static int sqlEliminar(DetalleVenta detalleVenta)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Detalle_Venta where Id = {0}", detalleVenta.Id));
            return respuesta;
        }
    }
}
