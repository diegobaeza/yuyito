using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{ 
    public class DaoProveedor
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Proveedor");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(Proveedor proveedor)
        {
            String sql = String.Format("select * from Proveedor where Id = '{0}'", proveedor.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeerConRubro()
        {
            String sql = String.Format("SELECT p.Id, p.Nombre, p.Direccion, p.Telefono, p.Activo, r.Descripcion FROM Proveedor p JOIN Rubro r ON (p.Rubro_id = r.id)");
            return BD.BD.getInstance().sqlLeer(sql);
        }

        public static bool sqlExiste(Proveedor proveedor)
        {
            String sql = String.Format("SELECT * FROM Proveedor WHERE Id = {0}", proveedor.Id);

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(Proveedor proveedor)
        {
            String sql = string.Format("Insert into Proveedor (Nombre,Direccion,Telefono,Activo,Rubro_id) values('{0}','{1}','{2}','{3}','{4}')",
                                                            proveedor.Nombre,
															proveedor.Direccion,
															proveedor.Telefono,
															proveedor.Activo,
															proveedor.Rubro_id
															);
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(Proveedor proveedor)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Proveedor set Nombre = '{1}', Direccion = '{2}', Telefono = '{3}' , Activo = '{4}', Rubro_id = '{5}' where Id = '{0}'",
                                                            proveedor.Id,
                                                            proveedor.Nombre,
															proveedor.Direccion,
															proveedor.Telefono,
															proveedor.Activo,
															proveedor.Rubro_id));
            return respuesta;
        }

        public static int sqlEliminar(Proveedor proveedor)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Proveedor where Id = {0}", proveedor.Id));
            return respuesta;
        }
    }
}
