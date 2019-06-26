using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class Boleta
    {
        private int id;
        private DateTime fecha;
        private int total;
        private String direccion;
        private int telefono;
        private char fiado;
        private int usuario_id;
        private int cliente_id;


        public Boleta(int id)
        {
            this.Id = id;
        }

        public Boleta(DateTime fecha, int total, string direccion, int telefono, char fiado, int usuario_id, int cliente_id)
        {
            this.Fecha = fecha;
            this.Total = total;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Fiado = fiado;
            this.Usuario_id = usuario_id;
            this.Cliente_id = cliente_id;
        }

        public Boleta(int id, DateTime fecha, int total, string direccion, int telefono, char fiado, int usuario_id, int cliente_id)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.Total = total;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Fiado = fiado;
            this.Usuario_id = usuario_id;
            this.Cliente_id = cliente_id;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Total { get => total; set => total = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public char Fiado { get => fiado; set => fiado = value; }
        public int Usuario_id { get => usuario_id; set => usuario_id = value; }
        public int Cliente_id { get => cliente_id; set => cliente_id = value; }
    }
}
