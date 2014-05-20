<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AnimalCare.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbar navbar-default navbar-fixed-top" role="navigation">
      <div class="container">
        <ul class="nav navbar-nav">
            <li><a href="#">AnimalCare</a></li>
          </ul>
              <asp:Panel ID="Panel1" runat="server">
                <ul class="nav navbar-nav navbar-right">
                    <li><a runat="server" id="dLink"><asp:Literal ID="Lit1" runat="server"></asp:Literal></a></li>
                    <li><a href="#">Terminar Sessão</a></li>
                </ul>
              </asp:Panel>
              <asp:Panel ID="Panel2" runat="server">
                  <ul class="nav navbar-nav navbar-right">
                    <li><a id="loginLink" href="Account/Login.aspx">Iniciar Sessão</a></li>
                    <li><a id="registerLink" href="Account/Register.aspx">Registar</a></li>
                  </ul>
              </asp:Panel>
        </div>
    </div>
</asp:Content>
