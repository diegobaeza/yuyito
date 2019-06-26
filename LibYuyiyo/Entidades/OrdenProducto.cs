using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class OrdenProducto
    {
        private int id;
        private DateTime fecha_recepcion;
		private DateTime fecha_emision;
		private char estado;
		private int total;
        private int usuario_id;
        private int proveedor_id;

        public OrdenProducto(int id)
        {
            this.Id = id;

        }

        public OrdenProducto(int id, DateTime fecha_recepcion, DateTime fecha_emision, char estado, int total, int usuario_id, int proveedor_id)
        {
            this.Id = id;
            this.Fecha_recepcion = fecha_emision;
			this.Fecha_emision = fecha_emision;
			this.Estado = estado;
			this.Total = total;
			this.Usuario_id = usuario_id;
			this.Proveedor_id = proveedor_id;
        }

        public OrdenProducto( DateTime fecha_recepcion, DateTime fecha_emision, char estado, int total, int usuario_id, int proveedor_id)
        {
            this.Fecha_recepcion = fecha_emision;
            this.Fecha_emision = fecha_emision;
            this.Estado = estado;
            this.Total = total;
            this.Usuario_id = usuario_id;
            this.Proveedor_id = proveedor_id;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Fecha_recepcion { get => fecha_recepcion; set => fecha_recepcion = value; }
        public DateTime Fecha_emision { get => fecha_emision; set => fecha_emision = value; }
        public char Estado { get => estado; set => estado = value; }
        public int Total { get => total; set => total = value; }
        public int Usuario_id { get => usuario_id; set => usuario_id = value; }
        public int Proveedor_id { get => proveedor_id; set => proveedor_id = value; }
    }
}