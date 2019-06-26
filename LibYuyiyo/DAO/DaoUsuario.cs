using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{
    public class DaoUsuario
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Usuario");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(Usuario usuario)
        {
            String sql = String.Format("select * from Usuario where Nombre_user = '{0}'", usuario.Nombre_user);
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeerConTipo()
        {
            String sql = String.Format("SELECT p.Id, p.Nombre_user, p.Contrasena, p.Correo, p.Nombre, p.Apellido, p.Fecha_nacimiento, p.Activo, r.Descripcion FROM Usuario p JOIN Tipo_Usuario r ON (p.Tipo_usuario_id = r.Id)");
            return BD.BD.getInstance().sqlLeer(sql);
        }

        public static bool sqlExiste(Usuario usuario)
        {
            String sql = String.Format("SELECT * FROM Usuario WHERE Id = {0}", usuario.Id);

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(Usuario usuario)
        {
            String sql = string.Format("Insert into Usuario (Nombre_user,Contrasena,Correo,Nombre, Apellido, Fecha_nacimiento, Activo, Tipo_usuario_id) values('{0}','{1}','{2}','{3}','{4}', '{5}', '{6}', '{7}')",
                                                            usuario.Nombre_user,
                                                            usuario.Contrasena,
                                                            usuario.Correo,
                                                            usuario.Nombre,
                                                            usuario.Apellido,
                                                            usuario.Fecha_nacimiento.ToString("MM/dd/yyyy"),
                                                            usuario.Activo,
                                                            usuario.Tipo_usuario_id
                                                            );
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(Usuario usuario)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Usuario set Nombre_user = '{1}', Contrasena = '{2}', Correo = '{3}', Nombre = '{4}', Apellido= '{5}', Fecha_nacimiento = '{6}', Activo = '{7}', Tipo_usuario_id = '{8}' where Id = '{0}'",
                                                            usuario.Id,
                                                            usuario.Nombre_user,
                                                            usuario.Contrasena,
                                                            usuario.Correo,
                                                            usuario.Nombre,
                                                            usuario.Apellido,
                                                            usuario.Fecha_nacimiento,
                                                            usuario.Activo,
                                                            usuario.Tipo_usuario_id));
            return respuesta;
        }

        public static int sqlEliminar(Usuario usuario)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Usuario where Id = {0}", usuario.Id));
            return respuesta;
        }
    }
}
