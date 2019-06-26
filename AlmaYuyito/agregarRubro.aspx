<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="agregarRubro.aspx.cs" Inherits="AlmaYuyito.agregarRubro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Agregar Rubro</h1>
    <section>
       <ul>
           <li>
                
               <asp:Label ID="lblErrNom" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
               <%--<asp:Label ID="lblErrDL" CssClass="lblerror" Text="Nombre demaciado largo." runat="server"  Visible="False" ForeColor="Red"/>
               <asp:Label ID="lblErrCN" CssClass="lblerror" Text="El nombre no puede contener numeros." runat="server" Visible="False" ForeColor="Red" />
              --%> <p>Nombre:</p>
               
               <asp:TextBox id="txtNombre" runat="server" />
           </li>
       </ul>

        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </section>
</asp:Content>
