<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="realizarVenta.aspx.cs" Inherits="AlmaYuyito.realizarVenta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Nueva Venta</h1>
    
    <section>
        
        <div id="panel-superior-ventas">
            <ul>
                <h1>Añade Productos</h1>
                <li>
                    <asp:Label ID="lblErrId" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />
                    
                    <asp:TextBox ID="TxtId" runat="server" type="number" placeholder="Ingrese un id"/>
                
                </li>
                <li>
                    <asp:Label ID="lblErrProd" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />
                    <p>o Seleccione un producto: </p>
                    <asp:DropDownList id="ddProductos" runat="server"></asp:DropDownList>
                </li>
                <li>
                    <asp:Label ID="lblErrCant" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />
                    
                    <asp:TextBox ID="txtCantidad" runat="server" type="number" placeholder="Ingrese la cantidad" />
                </li>
                <asp:Button ID="btnAgregarProducto" type="button" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="BtnAgregarProducto_Click"/>
            </ul>

            <div>
                <div id="fiado">
                    <asp:CheckBox ID="chbFiado" Text="¿Fiado?" runat="server" AutoPostBack="true" Enabled = "true" Checked="false"/>
            
                    <div id="listaClientes">
                        <p>Selecciona un Cliente: </p>
                        <asp:DropDownList id="ddClientes" runat="server"></asp:DropDownList>
                    </div>
                </div>
                
                <asp:Label ID="lblErrRut" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />

                <asp:TextBox ID="txtRut" runat="server" placeholder="Ingrese rut cliente"/>

                <div id="total">
                    <p>Total:</p>
                    <p id="sign">$</p>
                    <asp:TextBox ID="txtTotal" Text="000000" runat="server" Enabled="False" EnableTheming="False" />
                </div>
                <div>
                    <asp:Button ID="btnAgregarVenta" type="button" CssClass="btn btn-primary" runat="server" Text="Finalizar Venta" OnClick="btnAgregarVenta_Click"/>
                </div>
            </div>
        </div>
        <asp:Label ID="lblErrGv" CssClass="lblerror" Text="" runat="server" Visible="false" ForeColor="Red" />

        <asp:gridview id="gvProductos" 
               autogeneratecolumns="False"
               runat="server" 
               BackColor="#65ADF8"
               CellPadding="10"
               Font-Size="25px"
               ForeColor="White"
               GridLines="None"
               PageSize="5"
               OnRowDeleting="BtnEliminarProducto_Click"
               ShowHeaderWhenEmpty="true"
               EmptyDataText="No se han agregado productos."
               style="text-align:center;">
                
              <Columns>
                     
                    
                     <asp:CommandField ShowDeleteButton="True" DeleteText="" ControlStyle-CssClass="fas fa-trash-alt"/>
                      <asp:BoundField DataField="Id"
                         HeaderText="Identificador" 
                         InsertVisible="False" ReadOnly="True" 
                         SortExpression="Identificador" />
                     <asp:BoundField DataField="Descripcion" 
                         HeaderText="Descripcion" 
                         SortExpression="Descripcion" />
                     <asp:BoundField DataField="Cantidad" 
                         HeaderText="Cantidad" 
                         SortExpression="Cantidad" />
                     <asp:BoundField DataField="Precio" 
                         HeaderText="Precio" 
                         SortExpression="Precio" />
            </Columns>
               
            <EditRowStyle CssClass="fas fa-edit" />
            <HeaderStyle BackColor="#1c86f5" />
               
            <selectedrowstyle backcolor="LightCyan" forecolor="DarkBlue" font-bold="true"/>  
                
        </asp:gridview>
        

        
    </section>
</asp:Content>

