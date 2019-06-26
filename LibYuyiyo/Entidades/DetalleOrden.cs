using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class DetalleOrden
    {
        private int id;
        private int cantidad;
        private int producto_id;
        private int orden_producto_id;

        public DetalleOrden(int id)
        {
            this.Id = id;
        }

        public DetalleOrden(int cantidad, int producto_id, int orden_producto_id)
        {
            this.Cantidad = cantidad;
            this.Producto_id = producto_id;
            this.Orden_producto_id = orden_producto_id;
        }

        public DetalleOrden(int id, int cantidad, int producto_id, int orden_producto_id)
        {
            this.Id = id;
            this.Cantidad = cantidad;
            this.Producto_id = producto_id;
            this.Orden_producto_id = orden_producto_id;
        }

        public int Id { get => id; set => id = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Producto_id { get => producto_id; set => producto_id = value; }
        public int Orden_producto_id { get => orden_producto_id; set => orden_producto_id = value; }
    }
}
