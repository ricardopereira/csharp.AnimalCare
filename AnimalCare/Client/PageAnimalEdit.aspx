<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalEdit.aspx.cs" Inherits="AnimalCare.Client.PageAnimalEdit" %>
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
                <p class="text-muted">Andreia Pessoa <a class="btn btn-default btn-xs" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>
        <div class="row">
            <!-- Avatar -->
            <div class="col-md-3">
                <img data-src="holder.js/200x200" class="img-thumbnail" alt="200x200" src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=" style="width: 200px; height: 200px;">
            </div>
            <!-- Info -->
            <div class="col-md-9">
                <h2>Quinzé</h2>
                <span class="label label-danger">Modo edição</span>
                <br />
                <br />
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed diam eget risus varius blandit sit amet non magna.</p>
                <button type="button" class="btn btn-sm btn-default">Carregar foto</button>
            </div>
        </div>

        <div class="row">
            <br /><br />
            <!-- Campos -->
            <div class="col-md-2"></div>
            <div class="col-md-8">

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Dados</h3>
                    </div>
                    <div class="panel-body">
                        <p>
                        <asp:Label ID="lblNome" runat="server" Text="Nome: "></asp:Label>
                        <asp:TextBox ID="boxNome" runat="server"></asp:TextBox>
                        </p>
                        <p>
                        <asp:Label ID="lblIdentity" runat="server" Text="Núm. Identidade: "></asp:Label>
                        <asp:TextBox ID="boxIdentity" runat="server"></asp:TextBox>
                        </p>
                        <p>
                        <asp:Label ID="lblDateBorn" runat="server" Text="Data Nascimento: "></asp:Label>
                        <asp:TextBox ID="boxDateBorn" runat="server"></asp:TextBox>
                        </p>
                        <p>
                        <asp:Label ID="lblSex" runat="server" Text="Sexo: "></asp:Label>
                        <asp:TextBox ID="boxSex" runat="server"></asp:TextBox>
                        </p>
                    </div>
                </div>

                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Gravar" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancel_Click"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>

</asp:Content>
