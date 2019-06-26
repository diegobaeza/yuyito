using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class Producto
    {
        private int id;
        private String descripcion;
		private DateTime fecha_vencimiento;
		private int precio;
		private int stock;
		private int tipo_producto_id;

        

        public Producto(int id)
        {
            this.Id = id;

        }

        public Producto(int id, string descripcion, DateTime fecha_vencimiento, int precio, int stock, int tipo_producto_id)
        {
            this.Id = id;
            this.Descripcion = descripcion;
			this.Fecha_vencimiento = fecha_vencimiento;
			this.Precio = precio;
			this.Stock = stock;
			this.Tipo_producto_id = tipo_producto_id;
			
        }

        public Producto(string descripcion, DateTime fecha_vencimiento, int precio, int stock, int tipo_producto_id)
        {
            this.Descripcion = descripcion;
            this.Fecha_vencimiento = fecha_vencimiento;
            this.Precio = precio;
            this.Stock = stock;
            this.Tipo_producto_id = tipo_producto_id;

        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
        public int Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Tipo_producto_id { get => tipo_producto_id; set => tipo_producto_id = value; }

    }
}