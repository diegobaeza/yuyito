<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="AlmaYuyito.AgregarCliente" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar Cliente</h1>
    <section>
        <ul>
            <li>
                <asp:Label ID="lblErrNom" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />
                <p>Nombre: </p>
                <asp:TextBox ID="TxtNombre" runat="server" />
            </li>
            <li>
                <asp:Label ID="lblErrApe" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />
                <p>Apellido: </p>
                <asp:TextBox ID="TxtApellido" runat="server" />
            </li>
            <li>
                <asp:Label ID="lblErrRut" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />
                <p>Rut: </p>
                <asp:TextBox ID="TxtRut" runat="server" />
            </li>
            <li>
                <asp:Label ID="lblErrEst" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />
                <p>Estado: </p>
                <asp:TextBox ID="TxtEstado" runat="server" />
            </li>

        </ul>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </section>
</asp:Content>
