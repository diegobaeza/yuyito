<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agregarProveedor.aspx.cs" Inherits="AlmaYuyito.agregarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Proveedor</h1>
    <section>
       <ul>
           <li>
               <p>Nombre:</p>
               <asp:TextBox id="txtNombre" runat="server" />
           </li>

           <li>
               <p>Direccion:</p>
               <asp:TextBox id="txtDireccion" runat="server" />
           </li>

           <li>
               <p>Telefono:</p>
               <asp:TextBox id="txtTelefono" runat="server" />
           </li>

           <li>
               <p>Rubro:</p>
               <asp:DropDownList id="ddRubro" runat="server"></asp:DropDownList>
           </li>
       </ul>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </section>
</asp:Content>
