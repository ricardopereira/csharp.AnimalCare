<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimal.aspx.cs" Inherits="AnimalCare.Client.PageAnimal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> perfil</small></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>
        <div class="row">
            <!-- Avatar -->
            <div class="col-md-3">
                <img id="animalImage" runat="server" data-src="holder.js/200x200" class="img-thumbnail" alt="animal image" style="width: 200px; height: 200px;">
            </div>
            <!-- Info -->
            <div class="col-md-9">
                <h2><asp:Label ID="lblMainName" runat="server"></asp:Label></h2>
                <a class="btn btn-default btn-sm" runat="server" id="editLink" role="button"><span class="glyphicon glyphicon-pencil"></span> Editar</a>
                <br />
                <br />
                <p>Nome: <asp:Label ID="lblName" runat="server"></asp:Label></p>
                <p>N. Identificação: <asp:Label ID="lblIdentityNumber" runat="server"></asp:Label></p>
                <p>Reside: <asp:Label ID="lblPlace" runat="server"></asp:Label></p>
                <p>Data Nasc.: <asp:Label ID="lblBornDate" runat="server"></asp:Label></p>
                <p>Sexo: <asp:Label ID="lblSex" class="animalName" runat="server"></asp:Label></p>
                <p>Espécie: <asp:Label ID="lblSpecie" runat="server"></asp:Label></p>
                <p>Raça: <asp:Label ID="lblRace" runat="server"></asp:Label></p>
                <p>Condição: <asp:Label ID="lblCondition" runat="server"></asp:Label></p>
            </div>
        </div>

    </div>

</asp:Content>
