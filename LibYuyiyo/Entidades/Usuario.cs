using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibYuyiyo.Entidades
{
    public class Usuario
    {
        private int id;
        private String nombre_user;
        private String contrasena;
        private String correo;
        private String nombre;
        private String apellido;
        private DateTime fecha_nacimiento;
        private char activo;
        private int tipo_usuario_id;


        public Usuario()
        {
        }

        public Usuario(int id)
        {
            this.Id = id;
        }
        public Usuario(string nombre_user, string contrasena)
        {
            this.Nombre_user = nombre_user;
            this.Contrasena = contrasena;
        }

        public Usuario(string nombre_user, string contrasena, string correo, string nombre, string apellido, DateTime fecha_nacimiento, char activo, int tipo_usuario_id)
        {
            this.Nombre_user = nombre_user;
            this.Contrasena = contrasena;
            this.Correo = correo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Activo = activo;
            this.Tipo_usuario_id = tipo_usuario_id;
        }

        public Usuario(int id, string nombre_user, string contrasena, string correo, string nombre, string apellido, DateTime fecha_nacimiento, char activo, int tipo_usuario_id)
        {
            this.Id = id;
            this.Nombre_user = nombre_user;
            this.Contrasena = contrasena;
            this.Correo = correo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Activo = activo;
            this.Tipo_usuario_id = tipo_usuario_id;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre_user { get => nombre_user; set => nombre_user = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public char Activo { get => activo; set => activo = value; }
        public int Tipo_usuario_id { get => tipo_usuario_id; set => tipo_usuario_id = value; }
    }
}
