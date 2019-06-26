<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="autenticacion.aspx.cs" Inherits="AlmaYuyito.autenticacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">

    <link rel="stylesheet" type="text/css" runat="server" href="~/css/Chart.min.css" />
    <link rel="stylesheet" type="text/css" runat="server" href="~/css/autenticacion.css" />

</head>

<body>
    <form id="form1" runat="server">
        <div id="contenido">
            <img src="img/logo.png" alt="Logo" />
            <ul>
                <li>
                   <asp:Label ID="lblErrUsu" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
                   
                   <asp:TextBox id="txtUsuario" runat="server" placeholder="Usuario"/>
               </li>

               <li>

                   <asp:Label ID="lblErrCon" CssClass="lblerror" Text="" runat="server" Visible="False" ForeColor="Red" />
                   
                   <asp:TextBox id="txtContraseña" runat="server" TextMode="Password" placeholder="Contraseña"/>
               
               </li>

                <li>
                    <div>
                        <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                    </div>
                </li>
            </ul>
            
        </div>
    </form>
</body>
</html>
