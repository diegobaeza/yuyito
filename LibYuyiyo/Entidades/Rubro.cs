using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class Rubro
    {
        private int id;
        private String descripcion;

        public Rubro(int id)
        {
            this.Id = id;
        }
        public Rubro(string descripcion)
        {
            this.Descripcion = descripcion;
        }
        public Rubro(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }


        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
