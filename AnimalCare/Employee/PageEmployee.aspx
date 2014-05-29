<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/MasterPageEmployee.Master" AutoEventWireup="true" CodeBehind="PageEmployee.aspx.cs" Inherits="AnimalCare.Employee.PageEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Funcionário<small> perfil</small></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <img id="profileImage" runat="server" data-src="holder.js/200x200" class="img-thumbnail" alt="200x200" style="width: 200px; height: 200px;" />
            </div>
            <div class="col-md-9">
                <h2><%: Ctrl.Bf.Name %></h2>
                <a class="btn btn-default btn-sm" href="PageEmployeeEdit.aspx" role="button"><span class="glyphicon glyphicon-pencil"></span> Editar</a>
                <br />
                <br />
                <br />
                <p>User: <%: User.Identity.Name %></p>
                <p>Nome: <%: Ctrl.Bf.Name %></p>
                <p>Email: <%: Ctrl.Bf.Email %></p>
                <p>Cédula: <%: Ctrl.Bf.CodeWorker %></p>
                <p>Número Tel. Trabalho: <%: Ctrl.Bf.WorkNumber %></p>
                <p>Número Tel. Pessoal: <%: Ctrl.Bf.PersonalNumber %></p>
                <p></p>
            </div>
        </div>
    </div>
</asp:Content>
