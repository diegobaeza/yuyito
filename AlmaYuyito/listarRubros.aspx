﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listarRubros.aspx.cs" Inherits="AlmaYuyito.listarRubros" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     
    
        <h1>Lista de Rubros</h1>

        
            <asp:gridview id="gvRubros" 
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
                         HeaderText="Nombre" 
                         SortExpression="Nombre" />
                     
                 </Columns>
               
                 <EditRowStyle CssClass="fas fa-edit" />
                 <HeaderStyle BackColor="#1c86f5" />
               
               <selectedrowstyle backcolor="LightCyan"
                 forecolor="DarkBlue"
                 font-bold="true"/>  
                
             </asp:gridview>
        
        
</asp:Content>
