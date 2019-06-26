using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoTipoUsuario
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Tipo_Usuario");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(TipoUsuario tipoUsuario)
        {
            String sql = String.Format("select * from Tipo_Usuario where Id = '{0}'", tipoUsuario.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static bool sqlDepende(TipoUsuario tipoUsuario)
        {
            String sql = "";

            if (tipoUsuario.Id > 0)
            {
                sql = String.Format("SELECT * FROM Usuario p JOIN Tipo_Usuario r ON (p.Tipo_usuario_id = r.Id) WHERE p.Tipo_usuario_id = '{0}'", tipoUsuario.Id);
            }

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static bool sqlExiste(TipoUsuario tipoUsuario)
        {
            String sql = "";

            if (tipoUsuario.Id > 0)
            {
                sql = String.Format("SELECT * FROM Tipo_Usuario WHERE Id = '{0}'", tipoUsuario.Id);
            }
            else if (tipoUsuario.Descripcion.Length > 0)
            {
                sql = String.Format("SELECT * FROM Tipo_Usuario WHERE Descripcion = '{0}'", tipoUsuario.Descripcion);
            }


            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(TipoUsuario tipoUsuario)
        {
            String sql = string.Format("Insert into Tipo_Usuario (Descripcion) values('{0}')",
                                                            tipoUsuario.Descripcion
                                                            );
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }

        public static int sqlActualizar(TipoUsuario tipoUsuario)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Tipo_Usuario set Descripcion = '{1}' where Id = '{0}'",
                                                            tipoUsuario.Id,
                                                            tipoUsuario.Descripcion));
            return respuesta;
        }

        public static int sqlEliminar(TipoUsuario tipoUsuario)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Tipo_Usuario where Id = {0}", tipoUsuario.Id));
            return respuesta;
        }
    }
}
