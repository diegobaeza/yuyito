using LibYuyiyo.Entidades;
using LibYuyiyo.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmaYuyito
{
    public partial class autenticacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length < 1)
            {
                lblErrUsu.Text = "Debe ingresar un nombre de usuario.";
                lblErrUsu.Visible = true;
                return;
            }
            lblErrUsu.Visible = false;

            if (txtContraseña.Text.Length < 1)
            {
                lblErrCon.Text = "Debe ingresar una contraseña.";
                lblErrCon.Visible = true;
                return;
            }

            lblErrCon.Visible = false;


            Usuario usuario = new Usuario(txtUsuario.Text, txtContraseña.Text);

            Usuario reuser = NegUsuario.buscarUsuario(usuario);

            if (reuser.Id > 0)
            {
                if (usuario.Nombre_user.Equals(reuser.Nombre_user))
                {
                    if (usuario.Contrasena.Equals(reuser.Contrasena))
                    {
                        Session["Id"] = reuser.Id;
                        Session["Nombre_user"] = reuser.Nombre_user;
                        Session["Contrasena"] = reuser.Contrasena;
                        Session["Correo"] = reuser.Correo;
                        Session["Nombre"] = reuser.Nombre;
                        Session["Apellido"] = reuser.Apellido;
                        Session["Fecha_nacimiento"] = reuser.Fecha_nacimiento;
                        Session["Activo"] = reuser.Activo;
                        Session["Tipo_usuario_id"] = reuser.Tipo_usuario_id;

                        Response.Redirect("~/default.aspx");
                        
                        return;
                    }
                    else
                    {
                        lblErrUsu.Text = "Nombre de usuario o contraseña incorrectos.";
                        lblErrUsu.Visible = true;
                        return;
                    }


                }
                else
                {
                    lblErrUsu.Text = "Nombre de usuario o contraseña incorrectos.";
                    lblErrUsu.Visible = true;
                    return;
                }

            }
            else
            {
                lblErrUsu.Text = "Nombre de usuario o contraseña incorrectos.";
                lblErrUsu.Visible = true;
                return;
            }

        }
    }
}