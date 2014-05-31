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

          <div class="inner cover">
            <h1 class="cover-heading">Bem-vindo</h1>
            <p class="lead">AnimalCare é um serviço móvel de assistência veterinária - consultas, tratamentos de rotina, casos de urgência – permitindo assim reduzir as restrições de horário, ou de mobilidade, pois o transporte de animais é, em geral, uma tarefa difícil, por vezes angustiante para o próprio animal, e que exige a existência, ou a disponibilidade, de meios adequados.</p>
            <p class="lead">
              <a href="Account/Register.aspx" class="btn btn-lg btn-default">Crie aqui o seu registo</a>
            </p>
          </div>

          <div class="mastfoot">
            <div class="inner">
              <p>Desenvolvido por <a href="#">Ricardo Pereira</a> e por <a href="#">Mário Silva</a>.</p>
            </div>
          </div>

    </div>
</asp:Content>
