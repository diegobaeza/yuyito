using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.DAO
{ 
    public class DaoRubro
    {
        public static DataTable sqlLeerTodos()
        {
            String sql = String.Format("select * from Rubro");
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static DataTable sqlLeer(Rubro rubro)
        {
            String sql = String.Format("select Id, Descripcion from Rubro where Id = '{0}'", rubro.Id);
            return BD.BD.getInstance().sqlLeer(sql);
        }
        public static bool sqlDepende(Rubro rubro)
        {
            String sql = "";

            if (rubro.Id > 0)
            {
                sql = String.Format("SELECT * FROM Proveedor p JOIN Rubro r ON (p.Rubro_id = r.Id) WHERE p.Rubro_id = '{0}'", rubro.Id);
            }

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static bool sqlExiste(Rubro rubro)
        {
            String sql = "";

            if (rubro.Id > 0)
            {
                sql = String.Format("SELECT * FROM Rubro WHERE Id = '{0}'", rubro.Id);
            }
            else if(rubro.Descripcion.Length > 0)
            {
                sql = String.Format("SELECT * FROM Rubro WHERE Descripcion = '{0}'", rubro.Descripcion);
            }
            

            DataTable respuesta = BD.BD.getInstance().sqlLeer(sql);

            if (respuesta.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static int sqlAgregar(Rubro rubro)
        {
            String sql = string.Format("Insert into Rubro (Descripcion) values('{0}')",
                                                            rubro.Descripcion
															);
            int respuesta = BD.BD.getInstance().sqlEjecutar(sql);
            return respuesta;
        }
        public static int sqlActualizar(Rubro rubro)
        { 
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("update Rubro set Descripcion = '{1}' where Id= '{0}'",
                                                            rubro.Id,
                                                            rubro.Descripcion));
            return respuesta;
        }

        public static int sqlEliminar(Rubro rubro)
        {
            int respuesta = BD.BD.getInstance().sqlEjecutar(String.Format("delete from Rubro where Id = {0}", rubro.Id));
            return respuesta;
        }
    }
}
