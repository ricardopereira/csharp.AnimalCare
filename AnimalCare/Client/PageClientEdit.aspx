<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageClientEdit.aspx.cs" Inherits="AnimalCare.Client.PageClientEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cliente<small> perfil</small></h1>
            </div>
        </div>
        <div class="row">
            <!-- Avatar -->
            <div class="col-md-3">
                <img data-src="holder.js/200x200" class="img-thumbnail" alt="200x200" src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=" style="width: 200px; height: 200px;">
            </div>
            <!-- Info -->
            <div class="col-md-9">
                <h2>Andreia Pessoa</h2>
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
                        <asp:Label ID="lblTaxNumber" runat="server" Text="NIF: "></asp:Label>
                        <asp:TextBox ID="boxTaxNumber" runat="server"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblCountry" runat="server" Text="País: "></asp:Label>
                        <asp:DropDownList ID="listCountry" runat="server" Width="200"></asp:DropDownList>
                        </p>

                        <p>
                        <asp:Label ID="lblBusiness" runat="server" Text="Empresa: "></asp:Label>
                        <asp:CheckBox ID="chkBusiness" runat="server" OnCheckedChanged="chkBusiness_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                        </p>

                        <p>
                        <asp:Label ID="lblBusinessSector" runat="server" Text="Sector da empresa: "></asp:Label>
                        <asp:DropDownList ID="listBusinessSector" runat="server" Width="200"></asp:DropDownList>
                        </p>
                    </div>
                </div>

                <!-- Relativos a uma empresa -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Contactos</h3>
                    </div>
                    <div class="panel-body">
                        <p>
                        <asp:Label ID="lblMobileNumber" runat="server" Text="Telemóvel: "></asp:Label>
                        <asp:TextBox ID="boxMobileNumber" runat="server"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblFaxNumber" runat="server" Text="Fax: "></asp:Label>
                        <asp:TextBox ID="boxFaxNumber" runat="server"></asp:TextBox>
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
