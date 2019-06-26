using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoTipoProducto
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Tipo_Producto");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(TipoProducto tipoProducto)
        {
            String sql = String.Format("select * from Tipo_Producto where Id = '{0}'", tipoProducto.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static bool sqlDepende(TipoProducto tipoProducto)
        {
            String sql = "";

            if (tipoProducto.Id > 0)
            {
                sql = String.Format("SELECT * FROM Producto p JOIN Tipo_Producto r ON (p.Tipo_producto_id = r.Id) WHERE p.Tipo_producto_id = '{0}'", tipoProducto.Id);
            }

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static bool sqlExiste(TipoProducto tipoProducto)
        {
            String sql = "";

            if (tipoProducto.Id > 0)
            {
                sql = String.Format("SELECT * FROM Tipo_Producto WHERE Id = '{0}'", tipoProducto.Id);
            }
            else if (tipoProducto.Descripcion.Length > 0)
            {
                sql = String.Format("SELECT * FROM Tipo_Producto WHERE Descripcion = '{0}'", tipoProducto.Descripcion);
            }


            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(TipoProducto tipoProducto)
        {
            String sql = string.Format("Insert into Tipo_Producto (Descripcion) values('{0}')",
                                                            tipoProducto.Descripcion
                                                            );
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }

        public static int sqlActualizar(TipoProducto tipoProducto)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Tipo_Producto set Descripcion = '{1}' where Id= '{0}'",
                                                            tipoProducto.Id,
                                                            tipoProducto.Descripcion));
            return respuesta;
        }

        public static int sqlEliminar(TipoProducto tipoProducto)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Tipo_Producto where Id = {0}", tipoProducto.Id));
            return respuesta;
        }
    }
}

