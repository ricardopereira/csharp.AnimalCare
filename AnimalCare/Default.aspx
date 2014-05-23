<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AnimalCare.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <ul class="nav navbar-nav">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">AnimalCare</a>
                </div>
            </ul>
            <asp:Panel ID="pnlLogin" runat="server">
                <ul class="nav navbar-nav navbar-right">
                    <li><a id="loginLink" href="Client/PageClientDashboard.aspx">Iniciar Sessão</a></li>
                    <li><a id="registerLink" href="Account/Register.aspx">Registar</a></li>
                </ul>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
