using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class TipoUsuario
    {
        private int id;
        private String descripcion;


        public TipoUsuario(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
