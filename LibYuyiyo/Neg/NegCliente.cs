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
    public class NegCliente
    {
        public static bool CrearCliente(Cliente cliente)
        {
            int respuesta = 0;
            if (DaoCliente.sqlExiste(cliente))
            {
                respuesta = DaoCliente.sqlActualizar(cliente);
            }
            else
            {
                respuesta = DaoCliente.sqlAgregar(cliente);
            }
            if(respuesta>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ActualizarCliente(Cliente cliente)
        {
            int respuesta = 0;
            respuesta = DaoCliente.sqlActualizar(cliente);
            if(respuesta > 0)
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
            return DaoCliente.sqlLeerTodos();
        }
        public static Cliente buscarCliente(Cliente cliente)
        {
            DataTable dt = DaoCliente.sqlLeer(cliente);
            Cliente pv = new Cliente(int.Parse(dt.Rows[0]["Id"].ToString()),
                dt.Rows[0]["Nombre"].ToString(),
                dt.Rows[0]["Apellido"].ToString(),
                dt.Rows[0]["Rut"].ToString(),
                '1');
            return pv;
        }
    }
}
