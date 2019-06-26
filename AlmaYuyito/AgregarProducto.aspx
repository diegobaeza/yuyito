<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="AlmaYuyito.AgregarProducto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Producto</h1>
    <section>
       <ul>
           <li>
               <asp:Label ID="lblErrDes" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Descripcion:</p>
               <asp:TextBox id="txtDescripcion" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrFec" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Fecha_vencimiento:</p>
               <asp:TextBox id="txtFechaV" runat="server" />
               
           </li>

           <li>
               <asp:Label ID="lblErrPre" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Precio:</p>
               <asp:TextBox id="txtPrecio" runat="server" />

           </li>

           <li>
               <asp:Label ID="lblErrSto" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Stock:</p>
               <asp:TextBox id="txtStock" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrTiP" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Tipo de Producto:</p>
               <asp:DropDownList id="ddTipoProducto" runat="server"></asp:DropDownList>
           </li>
       </ul>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </section>
</asp:Content>
