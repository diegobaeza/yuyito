<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listarProveedores.aspx.cs" Inherits="AlmaYuyito.listarProveedores" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
        <h1>Lista de Proveedores</h1>

        
            <asp:gridview id="gvProveedores" 
               autogeneratecolumns="False"
               runat="server" 
               OnRowDeleting="btnEliminar_Click" 
               BackColor="#65ADF8" 
               CellPadding="10" 
               EnableTheming="True" 
               Font-Size="25px" 
               ForeColor="White" 
               GridLines="None"
               OnRowEditing="btnEditar_Click">
                
                 <Columns>
                     <asp:CommandField ShowEditButton="True" EditText="" ControlStyle-CssClass="fas fa-edit" />
                     <asp:CommandField ShowDeleteButton="True" DeleteText="" ControlStyle-CssClass="fas fa-trash-alt"/>
                     <asp:BoundField DataField="Id" 
                         HeaderText="Identificador" 
                         InsertVisible="False" ReadOnly="True" 
                         SortExpression="Identificador" />
                     <asp:BoundField DataField="Nombre" 
                         HeaderText="Nombre" 
                         SortExpression="Nombre" />
                     <asp:BoundField DataField="Direccion" 
                         HeaderText="Direccion" 
                         SortExpression="Direccion" />
                     <asp:BoundField DataField="Telefono" 
                         HeaderText="Telefono" 
                         SortExpression="Telefono" />
                     <asp:BoundField DataField="Activo" 
                         HeaderText="Activo" 
                         SortExpression="Activo" />
                     <asp:BoundField DataField="Descripcion" 
                         HeaderText="Rubro" 
                         SortExpression="Rubro" />
                 </Columns>
               
                 <HeaderStyle BackColor="#1c86f5" />
               
               <selectedrowstyle backcolor="LightCyan"
                 forecolor="DarkBlue"
                 font-bold="true"/>  
                
             </asp:gridview>
        
        
</asp:Content>
