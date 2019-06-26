<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="nuevoUsuario.aspx.cs" Inherits="AlmaYuyito.nuevoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Producto</h1>
    <section>
       <ul>
           <li>
               <asp:Label ID="lblErrUsu" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Usuario:</p>
               <asp:TextBox id="txtUsuario" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrCont" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Contraseña:</p>
               <asp:TextBox id="txtContra" runat="server" />
               
           </li>

           <li>
               <asp:Label ID="lblErrCorr" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Correo:</p>
               <asp:TextBox id="txtCorreo" runat="server" />

           </li>

           <li>
               <asp:Label ID="lblErrNom" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Nombres:</p>
               <asp:TextBox id="txtNombre" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrApe" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Apellidos:</p>
               <asp:TextBox id="txtApellido" runat="server" />
           </li>
           <li>
               <asp:Label ID="lblErrFN" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Fecha de Nacimiento:</p>
               <asp:TextBox id="txtFechaN" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrTiU" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Tipo de Usuario:</p>
               <asp:DropDownList id="ddTipoUsuario" runat="server"></asp:DropDownList>
           </li>
       </ul>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
