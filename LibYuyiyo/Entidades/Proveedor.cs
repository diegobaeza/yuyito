using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{ 
    public class Proveedor
    {
        private int id;
        private String nombre;
		private String direccion;
		private int telefono;
		private char activo;
		private int rubro_id;

        

        public Proveedor(int id)
        {
            this.Id = id;
           
        }

        public Proveedor(int id, string nombre, string direccion, int telefono, char activo, int rubro_id)
        {
            this.Id = id;
            this.Nombre = nombre;
			this.Direccion = direccion;
			this.Telefono = telefono;
			this.Activo = activo;
            this.Rubro_id = rubro_id;
        }

        public Proveedor(string nombre, string direccion, int telefono, char activo, int rubro_id)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Activo = activo;
            this.Rubro_id = rubro_id;
        }


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public char Activo { get => activo; set => activo = value; }
        public int Rubro_id { get => rubro_id; set => rubro_id = value; }


    }
}
