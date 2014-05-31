<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="PageAdminUsers.aspx.cs" Inherits="AnimalCare.Admin.PageAdminUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Utilizadores<small> área</small></h1>
            </div>
        </div>
        <div class="row">
            <!-- Info -->
            <div class="col-md-9">
                <h2>Novo utilizador</h2>
                <span class="label label-success">Modo inserção</span>
                <br />
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Utilizadores</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-6">
                            <strong>Inserir Utilizadores:</strong><br />
                                <asp:Button ID="btnAddDoctor" CssClass="btn btn-primary" runat="server" Text="Inserir Médico" OnClick="btnAddDoctor_Click"></asp:Button>
                                <asp:Button ID="btnAddEmployee" CssClass="btn btn-success" runat="server" Text="Inserir Funcionário" OnClick="btnAddEmployee_Click"></asp:Button>
                                <asp:Button ID="btnAddAdmin" CssClass="btn btn-warning" runat="server" Text="Inserir Administrador" OnClick="btnAddAdmin_Click"></asp:Button>
                            <br />
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

