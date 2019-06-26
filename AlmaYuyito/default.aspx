<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AlmaYuyito._default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <article id="contenido">

    <asp:Literal ID="litTitulo"  runat="server" ClientIDMode="Static" />

        <section id="chartLineContent">

            <h3></h3>
            <div>
                <canvas id='chLine'></canvas>
                <canvas id='chBar'></canvas>
                <canvas id='chPie'></canvas>
            </div>
            
        </section>

    </article>
    
    

    
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/Chart.bundle.min.js") %>"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/Chart.min.js") %>"></script>
    
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/script.js") %>"></script>
</asp:Content>

