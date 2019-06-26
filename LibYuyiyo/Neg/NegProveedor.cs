using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibYuyiyo.Entidades;
using LibYuyiyo.DAO;
using System.Data;

namespace LibYuyiyo.Neg
{
    public static class NegProveedor
    {
        public static bool CrearProveedor(Proveedor proveedor)
        {
            int respuesta = 0;

            if (DaoProveedor.sqlExiste(proveedor))
            {

                respuesta = DaoProveedor.sqlActualizar(proveedor);

            }
            else
            {
                respuesta = DaoProveedor.sqlAgregar(proveedor);
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

        public static System.Data.DataTable listarTodos()
        {
            return DaoProveedor.sqlLeerTodos();
        }

        public static bool ActualizarProveedor(Proveedor proveedor )
        {
            int respuesta = 0;

            respuesta = DaoProveedor.sqlActualizar(proveedor);


            if (respuesta > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static Proveedor buscarProveedor(Proveedor proveedor)
        {
            DataTable dt = DaoProveedor.sqlLeer(proveedor);

            Proveedor pv = new Proveedor(int.Parse(dt.Rows[0]["Id"].ToString()),
                                        dt.Rows[0]["Nombre"].ToString(),
                                        dt.Rows[0]["Direccion"].ToString(),
                                        int.Parse(dt.Rows[0]["Telefono"].ToString()),
                                        dt.Rows[0]["Activo"].ToString()[0],
                                        int.Parse(dt.Rows[0]["Rubro_id"].ToString()));

            return pv;

        }

        public static DataTable listarProveedores()
        {
            return DaoProveedor.sqlLeerConRubro();

        }

        public static bool EliminarProveedor(Proveedor proveedor)
        {
            int respuesta = 0;

            if (DaoProveedor.sqlExiste(proveedor))
            {

                respuesta = DaoProveedor.sqlEliminar(proveedor);

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

