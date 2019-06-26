using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoCliente
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Cliente");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(Cliente cliente)
        {
            String sql = String.Format("select * from Cliente where Id = '{0}'", cliente.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static bool sqlExiste(Cliente cliente)
        {
            String sql = String.Format("select * from Cliente where Id = {0}", cliente.Id);
            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);
            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static int sqlAgregar(Cliente cliente)
        {
            String sql = string.Format("insert into Cliente (Nombre, Apellido, Rut, Estado) values('{0}','{1}','{2}','{3}')",
                cliente.Nombre,
                cliente.Apellido,
                cliente.Rut,
                cliente.Estado);
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(Cliente cliente)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Cliente set Nombre = '{1}', Apellido = '{2}', Rut = '{3}', Estado = '{4}' where Id = {0}",
                cliente.Id,
                cliente.Nombre,
                cliente.Apellido,
                cliente.Rut,
                cliente.Estado));
            return respuesta;
        }
        public static int sqlEliminar(Cliente cliente)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Cliente where Id = {0}", cliente.Id));
            return respuesta;
        }
    }
}
