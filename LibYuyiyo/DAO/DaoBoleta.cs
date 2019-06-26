using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoBoleta
    {

        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Boleta");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(Boleta boleta)
        {
            String sql = String.Format("select * from Boleta where Id = '{0}'", boleta.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }

        /*public static DataTable sqlLeerConRubro()
        {
            String sql = String.Format("SELECT p.Id, p.Nombre, p.Direccion, p.Telefono, p.Activo, r.Descripcion FROM Proveedor p JOIN Rubro r ON (p.Rubro_id = r.id)");
            return BD.BD.getInstance().sqlLeer(sql);
        }*/

        public static bool sqlExiste(Boleta boleta)
        {
            String sql = String.Format("SELECT * FROM Boleta WHERE Id = {0}", boleta.Id);

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(Boleta boleta)
        {
            String sql = string.Format("Insert into Boleta (Fecha, Total, Direccion, Telefono, Fiado, Usuario_id, Cliente_id) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                                            boleta.Fecha,
                                                            boleta.Total,
                                                            boleta.Direccion,
                                                            boleta.Telefono,
                                                            boleta.Fiado,
                                                            boleta.Usuario_id,
                                                            boleta.Cliente_id
                                                            );
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(Boleta boleta)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Boleta set Fecha = '{1}', Total = '{2}', Direccion = '{3}', Telefono = '{4}', Fiado = '{5}', Usuario_id = '{6}', Cliente_id = '{7}' where Id = '{0}'",
                                                            boleta.Id,
                                                            boleta.Fecha,
                                                            boleta.Total,
                                                            boleta.Direccion,
                                                            boleta.Telefono,
                                                            boleta.Fiado,
                                                            boleta.Usuario_id,
                                                            boleta.Cliente_id));
            return respuesta;
        }

        public static int sqlEliminar(Boleta boleta)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Boleta where Id = {0}", boleta.Id));
            return respuesta;
        }
    }
}
