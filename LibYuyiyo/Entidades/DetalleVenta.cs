using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class DetalleVenta
    {

        private int id;
        private int cantidad;
        private int boleta_id;
        private int producto_id;

        public DetalleVenta(int id)
        {
            this.Id = id;
        }
        public DetalleVenta(int cantidad, int boleta_id, int producto_id)
        {
            this.Cantidad = cantidad;
            this.Boleta_id = boleta_id;
            this.Producto_id = producto_id;
        }

        public DetalleVenta(int id, int cantidad, int boleta_id, int producto_id)
        {
            this.Id = id;
            this.Cantidad = cantidad;
            this.Boleta_id = boleta_id;
            this.Producto_id = producto_id;
        }

        public int Id { get => id; set => id = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Boleta_id { get => boleta_id; set => boleta_id = value; }
        public int Producto_id { get => producto_id; set => producto_id = value; }
    }
}
