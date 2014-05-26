<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AnimalCare.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbar navbar-default" role="navigation">
        <div class="container">
            <ul class="nav navbar-nav">
                <div class="navbar-header">
                    <a class="navbar-brand" href="/">AnimalCare</a>
                </div>
            </ul>
            <asp:Panel ID="pnlLogin" runat="server">
                <ul class="nav navbar-nav navbar-right">
                    <li><a id="loginLink" href="Account/Login.aspx">Iniciar Sessão</a></li>
                    <li><a id="registerLink" href="Account/Register.aspx">Registar</a></li>
                </ul>
            </asp:Panel>
            <asp:Panel ID="pnlLoggedIn" runat="server">
                <ul class="nav navbar-nav navbar-right">
                    <li><a runat="server" id="profileId"><asp:Literal ID="Lit1" runat="server"></asp:Literal></a></li>
                    <li><a id="logoutLink" href="Account/Logout.aspx">Terminar Sessão</a></li>
                </ul>
            </asp:Panel>
        </div>
    </div>
    <div class="container">
        <h1>Lorem Ipsum</h1>
        Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
        tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam,
        quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo
        consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse
        cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
        proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
    </div>
</asp:Content>
