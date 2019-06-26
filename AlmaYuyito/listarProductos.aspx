<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listarProductos.aspx.cs" Inherits="AlmaYuyito.listarProductos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista de Productos</h1>

        
            <asp:gridview id="gvProductos" 
               autogeneratecolumns="False"
               runat="server" BackColor="#65ADF8" CellPadding="10" Font-Size="25px" ForeColor="White" GridLines="None" OnRowDeleting="btnEliminar_Click" OnRowEditing="btnEditar_Click">
                
                 <Columns>
                     
                     <asp:CommandField ShowEditButton="True" EditText="" ControlStyle-CssClass="fas fa-edit" />
                     <asp:CommandField ShowDeleteButton="True" DeleteText="" ControlStyle-CssClass="fas fa-trash-alt"/>
                      <asp:BoundField DataField="Id"
                         HeaderText="Identificador" 
                         InsertVisible="False" ReadOnly="True" 
                         SortExpression="Identificador" />
                     <asp:BoundField DataField="Descripcion" 
                         HeaderText="Descripcion" 
                         SortExpression="Descripcion" />
                     <asp:BoundField DataField="Fecha_vencimiento" 
                         HeaderText="Fecha Vencimiento" 
                         SortExpression="FechaVencimiento" />
                     <asp:BoundField DataField="Precio" 
                         HeaderText="Precio" 
                         SortExpression="Precio" />
                     <asp:BoundField DataField="Stock" 
                         HeaderText="Stock" 
                         SortExpression="Stock" />
                     <asp:BoundField DataField="nombre_tipo" 
                         HeaderText="Tipo Producto" 
                         SortExpression="TipoProducto" />

                     
                 </Columns>
               
                 <EditRowStyle CssClass="fas fa-edit" />
                 <HeaderStyle BackColor="#1c86f5" />
               
               <selectedrowstyle backcolor="LightCyan"
                 forecolor="DarkBlue"
                 font-bold="true"/>  
                
             </asp:gridview>
</asp:Content>
