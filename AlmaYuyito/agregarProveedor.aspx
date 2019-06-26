<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agregarProveedor.aspx.cs" Inherits="AlmaYuyito.agregarProveedor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Proveedor</h1>
    <section>
       <ul>
           <li>
               <asp:Label ID="lblErrNom" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Nombre:</p>
               <asp:TextBox id="txtNombre" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrDir" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Direccion:</p>
               <asp:TextBox id="txtDireccion" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrTel" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Telefono:</p>
               <asp:TextBox id="txtTelefono" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrRubr" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Rubro:</p>
               <asp:DropDownList id="ddRubro" runat="server"></asp:DropDownList>
           </li>
       </ul>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </section>
</asp:Content>
