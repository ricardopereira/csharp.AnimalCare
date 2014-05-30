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
                <img id="profileImage" runat="server" data-src="holder.js/200x200" class="img-thumbnail" alt="200x200" src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=" style="width: 200px; height: 200px;">
            </div>
            <!-- Info -->
            <div class="col-md-9">
                <h2><%: Ctrl.Bf.Name %></h2>
                <span class="label label-danger">Modo edição</span>
                <br />
                <br />
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed diam eget risus varius blandit sit amet non magna.</p>
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
                        <asp:Label ID="lblName" runat="server" Text="Nome: "></asp:Label>
                        <asp:TextBox ID="boxName" CssClass="form-control" runat="server" MaxLength="45"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="boxName"
                        CssClass="label label-danger" ErrorMessage="Especifique o utilizador." />
                        </p>

                        <p>
                        <asp:Label ID="lblTaxNumber" runat="server" Text="NIF: "></asp:Label>
                        <asp:TextBox ID="boxTaxNumber" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="boxTaxNumber"
                        CssClass="label label-danger" ErrorMessage="Especifique o NIF." />
                        </p>

                        <p>
                        <asp:Label ID="lblCountry" runat="server" Text="País: "></asp:Label>
                        <asp:DropDownList ID="listCountry" CssClass="form-control" runat="server" Width="200px" DataSourceID="Countries" DataTextField="Name" DataValueField="CountryID"></asp:DropDownList>
                            <asp:SqlDataSource ID="Countries" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name], [CountryID] FROM [Countries]"></asp:SqlDataSource>
                        </p>

                        <p>
                        <asp:Label ID="lblBusiness" runat="server" Text="Empresa: "></asp:Label>
                        <asp:CheckBox ID="chkBusiness" runat="server" OnCheckedChanged="chkBusiness_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                        </p>

                        <p>
                        <asp:Label ID="lblBusinessSector" runat="server" Text="Sector da empresa: "></asp:Label>
                        <asp:DropDownList CssClass="form-control" ID="listBusinessSector" runat="server" Width="200px" DataSourceID="BusinessSectorID" DataTextField="Name" DataValueField="BusinessSectorID"></asp:DropDownList>
                            <asp:SqlDataSource ID="BusinessSectorID" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [BusinessSectorID], [Name] FROM [BusinessSector]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
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
                        <asp:TextBox CssClass="form-control" ID="boxMobileNumber" runat="server" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="boxMobileNumber"
                        CssClass="label label-danger" ErrorMessage="Especifique o número de contacto." />
                        </p>

                        <p>
                        <asp:Label ID="lblFaxNumber" runat="server" Text="Fax: "></asp:Label>
                        <asp:TextBox CssClass="form-control" ID="boxFaxNumber" runat="server" MaxLength="20"></asp:TextBox>
                        </p>
                    </div>
                </div>

                <!-- Relativos a imagem perfil -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Imagem de Perfil</h3>
                    </div>
                    <div class="panel-body">
                        <asp:FileUpload ID="FileUpload" runat="server" />
                        <br />
                        <asp:Button ID="btnUpload" CssClass="btn btn-sm btn-default" runat="server" Text="Carregar Foto" OnClick="btnUpload_Click"></asp:Button>
                        <asp:Literal ID="uploadMessage" runat="server"></asp:Literal>
                    </div>
                </div>

                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Gravar" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancel_Click"></asp:Button>
                    </div>
                </div>
            <div class="col-md-2"></div>
        </div>
    </div>

</asp:Content>
