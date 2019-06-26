using LibYuyiyo.DAO;
using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Neg
{
    public class NegUsuario
    {

        public static bool CrearUsuario(Usuario usuario)
        {
            int respuesta = 0;

            if (DaoUsuario.sqlExiste(usuario))
            {

                respuesta = DaoUsuario.sqlActualizar(usuario);

            }
            else
            {
                respuesta = DaoUsuario.sqlAgregar(usuario);
            }


            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool ActualizarUsuario(Usuario usuario)
        {
            int respuesta = 0;

            respuesta = DaoUsuario.sqlActualizar(usuario);


            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static System.Data.DataTable listarTodos()
        {
            return DaoUsuario.sqlLeerTodos();
        }

        public static Usuario buscarUsuario(Usuario usuario)
        {
            DataTable dt = DaoUsuario.sqlLeer(usuario);
            Usuario pv = new Usuario();
            if (dt.Rows.Count > 0)
            {
                pv = new Usuario(int.Parse(dt.Rows[0]["Id"].ToString()),
                                     dt.Rows[0]["Nombre_user"].ToString(),
                                     dt.Rows[0]["Contrasena"].ToString(),
                                     dt.Rows[0]["Correo"].ToString(),
                                     dt.Rows[0]["Nombre"].ToString(),
                                     dt.Rows[0]["Apellido"].ToString(),
                                     DateTime.Parse(dt.Rows[0]["Fecha_nacimiento"].ToString()),
                                     char.Parse(dt.Rows[0]["Activo"].ToString()),
                                     int.Parse(dt.Rows[0]["Tipo_usuario_id"].ToString()));
            }

            return pv;

        }


        public static DataTable listarTipoUsuario()
        {
            DataTable dt = DaoTipoUsuario.sqlLeerTodos();
            

            return dt;

        }

        public static DataTable listarUsuario()
        {
            return DaoUsuario.sqlLeerConTipo();

        }

        public static bool EliminarUsuario(Usuario usuario)
        {
            int respuesta = 0;

            if (DaoUsuario.sqlExiste(usuario))
            {

                respuesta = DaoUsuario.sqlEliminar(usuario);

            }



            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
