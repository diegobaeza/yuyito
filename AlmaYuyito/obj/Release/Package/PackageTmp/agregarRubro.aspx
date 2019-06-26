<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agregarRubro.aspx.cs" Inherits="AlmaYuyito.agregarRubro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Agregar Rubro</h1>
    <section>
       <ul>
           <li>
               <p>Nombre:</p>
               <asp:TextBox id="txtNombre" runat="server" />
           </li>
       </ul>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </section>
</asp:Content>
