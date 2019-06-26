<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarOrdenProducto.aspx.cs" Inherits="AlmaYuyito.AgregarOrdenProducto" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Orden de Producto</h1>
    <section>
       <ul>

           <li>
               <asp:Label ID="lblErrFecR" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Fecha_recepcion:</p>
               <asp:TextBox id="txtFechaR" runat="server" />
       
           </li>
             <li>
               <asp:Label ID="lblErrFecE" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Fecha_emision:</p>
               <asp:TextBox id="txtFechaE" runat="server" />
 
           </li>


           <li>
               <asp:Label ID="lblErrEst" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Estado:</p>
               <asp:TextBox id="txtEstado" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrTot" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Total:</p>
               <asp:TextBox id="txtTotal" runat="server" />
           </li>

           <li>
               <asp:Label ID="lblErrUsu" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Usuario:</p>
               <asp:DropDownList id="ddUsuario" runat="server"></asp:DropDownList>
           </li>
           <li>
               <asp:Label ID="lblErrPro" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <p>Proveedor:</p>
               <asp:DropDownList id="ddProveedor" runat="server"></asp:DropDownList>
           </li>
       </ul>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </section>
</asp:Content>
