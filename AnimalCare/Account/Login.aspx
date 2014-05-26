<%@ Page Title="Log in" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AnimalCare.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <div class="navbar navbar-default" role="navigation">
        <div class="container">
            <ul class="nav navbar-nav">
                <div class="navbar-header">
                    <a class="navbar-brand" href="/">AnimalCare</a>
                </div>
            </ul>
            <asp:Panel ID="pnlLogin" runat="server">
                <ul class="nav navbar-nav navbar-right">
                    <li><a id="registerLink" href="Register.aspx">Registar</a></li>
                </ul>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
    <section id="loginForm">
    <hgroup class="title">
        <h1 class="text-center">Iniciar Sessão</h1>
    </hgroup>
    <div class="container">
        <div class="form-signin text-center" role="form">
            <asp:Login ID="Login1" OnLoggedIn="Login_LoggedIn" runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
                <LayoutTemplate>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">Username</asp:Label>
                        <asp:TextBox class="form-control" runat="server" ID="UserName" />
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">Password</asp:Label>
                        <asp:TextBox class="form-control" runat="server" ID="Password" TextMode="Password" />
                        <asp:CheckBox runat="server" ID="RememberMe" />
                        <asp:Label style="padding-left:0;" ID="Label3" runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
                        <asp:Button class="btn btn-primary btn-lg btn-block"  runat="server" CommandName="Login" Text="Log in" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required."  />
                </LayoutTemplate>
            </asp:Login>
        </div>
    </div>
        <p class="text-center">
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>
    <section id="socialLoginForm">
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
    </section>
</asp:Content>
