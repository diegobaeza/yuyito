using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoOrdenProducto
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Orden_Producto");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(OrdenProducto ordenProducto)
        {
            String sql = String.Format("select * from Orden_Producto where Id = '{0}'", ordenProducto.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }
        //public static DataTable sqlLeerConRubro()
        //{
        //    String sql = String.Format("SELECT p.Id, p.Nombre, p.Direccion, p.Telefono, p.Activo, r.Descripcion FROM Proveedor p JOIN Rubro r ON (p.Rubro_id = r.id)");
        //    return BD.BD.getInstance().sqlLeer(sql);
        //}

        public static bool sqlExiste(OrdenProducto ordenProducto)
        {
            String sql = String.Format("SELECT * FROM Orden_Producto WHERE Id = {0}", ordenProducto.Id);

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(OrdenProducto ordenProducto)
        {
            String sql = string.Format("Insert into Orden_Producto (Fecha_recepcion, Fecha_emision, Estado, Total, Usuario_id, Proveedor_id) values('{0}','{1}','{2}', {3}, {4}, {5})",
                                                            ordenProducto.Fecha_recepcion,
                                                            ordenProducto.Fecha_emision,
                                                            ordenProducto.Estado,
                                                            ordenProducto.Total,
                                                            ordenProducto.Usuario_id,
                                                            ordenProducto.Proveedor_id
                                                            );
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(OrdenProducto ordenProducto)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Orden_Producto set Fecha_recepcion = '{1}', Fecha_emision = '{2}', Estado = '{3}', Total = {4}, Usuario_id = {5}, Proveedor_id = {6} where Id = {0}",
                                                            ordenProducto.Id,
                                                            ordenProducto.Fecha_recepcion,
                                                            ordenProducto.Fecha_emision,
                                                            ordenProducto.Estado,
                                                            ordenProducto.Total,
                                                            ordenProducto.Usuario_id,
                                                            ordenProducto.Proveedor_id));
            return respuesta;
        }

        public static int sqlEliminar(OrdenProducto ordenProducto)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Orden_Producto where Id = {0}", ordenProducto.Id));
            return respuesta;
        }
    }
}
