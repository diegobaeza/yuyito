using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class Cliente
    {
        private int id;
        private String nombre;
        private String apellido;
        private String rut;
        private char estado;

        public Cliente(int id)
        {
            this.Id = id;
        }

        public Cliente(string nombre, string apellido, string rut, char estado)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Rut = rut;
            this.Estado = estado;
        }

        public Cliente(int id, string nombre, string apellido, string rut, char estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Rut = rut;
            this.Estado = estado;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Rut { get => rut; set => rut = value; }
        public char Estado { get => estado; set => estado = value; }
    }
}
