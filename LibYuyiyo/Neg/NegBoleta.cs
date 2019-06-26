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
    public class NegBoleta
    {
        public static bool CrearBoleta(Boleta boleta, DataTable productos)
        {
            int respuesta = 0;
            int idBoleta = 0;
            
            
            idBoleta = DaoBoleta.sqlAgregar(boleta);
            if (idBoleta > 0)
            {
                respuesta = 1;
            }
            foreach (DataRow row in productos.Rows)
            {
                DetalleVenta dv = new DetalleVenta(int.Parse(row["Cantidad"].ToString()),
                                                    idBoleta,
                                                    int.Parse(row["Id"].ToString()));

                DaoDetalleVenta.sqlAgregar(dv);
               
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
            return DaoBoleta.sqlLeerTodos();
        }

        public static Boleta buscarBoleta(Boleta boleta)
        {
            DataTable dt = DaoBoleta.sqlLeer(boleta);
            Boleta bo;
            if (dt.Rows.Count > 0)
            {
                
                bo = new Boleta(int.Parse(dt.Rows[0]["Id"].ToString()),
                                       DateTime.Parse(dt.Rows[0]["Fecha"].ToString()),
                                       int.Parse(dt.Rows[0]["Total"].ToString()),
                                       dt.Rows[0]["Direccion"].ToString(),
                                       int.Parse(dt.Rows[0]["Telefono"].ToString()),
                                       Char.Parse(dt.Rows[0]["Fiado"].ToString()),
                                       int.Parse(dt.Rows[0]["TUsuario_id"].ToString()),
                                       int.Parse(dt.Rows[0]["Cliente_id"].ToString()));
            }
            else
            {
                bo = null;
            }

            return bo;

        }



        public static bool EliminarBoleta(Boleta boleta)
        {
            int respuesta = 0;

            if (DaoBoleta.sqlExiste(boleta))
            {

                respuesta = DaoBoleta.sqlEliminar(boleta);

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
