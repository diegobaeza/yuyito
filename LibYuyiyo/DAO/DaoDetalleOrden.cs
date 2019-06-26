using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoDetalleOrden
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Detalle_Orden");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(OrdenProducto ordenProducto)
        {
            String sql = String.Format("select * from Detalle_Orden where Orden_producto_id = '{0}'", ordenProducto.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }

        //public static DataTable sqlLeerConRubro()
        //{
        //    String sql = String.Format("SELECT p.Id, p.Nombre, p.Direccion, p.Telefono, p.Activo, r.Descripcion FROM Proveedor p JOIN Rubro r ON (p.Rubro_id = r.id)");
        //    return BD.BD.getInstance().sqlLeer(sql);
        //}

        public static bool sqlExiste(DetalleOrden detalleOrden)
        {
            String sql = String.Format("SELECT * FROM Detalle_Orden WHERE Id = {0}", detalleOrden.Id);

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(DetalleOrden detalleOrden)
        {
            String sql = string.Format("Insert into Detalle_Orden (Cantidad, Producto_id, Orden_producto_id) values('{0}','{1}','{2}')",
                                                            detalleOrden.Cantidad,
                                                            detalleOrden.Producto_id,
                                                            detalleOrden.Orden_producto_id
                                                            );
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(DetalleOrden detalleOrden)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Detalle_Orden set Cantidad = {1} , Producto_id = {2}, Orden_producto_id = {3} where Id = {0}",
                                                            detalleOrden.Id,
                                                            detalleOrden.Cantidad,
                                                            detalleOrden.Producto_id,
                                                            detalleOrden.Orden_producto_id));
            return respuesta;
        }

        public static int sqlEliminar(DetalleOrden detalleOrden)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Detalle_Orden where Id = {0}", detalleOrden.Id));
            return respuesta;
        }
    }
}
