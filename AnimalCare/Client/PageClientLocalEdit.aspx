<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageClientLocalEdit.aspx.cs" Inherits="AnimalCare.Client.PageClientLocalEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cliente<small> locais</small></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <p class="lead">Andreia Pessoa <a class="btn btn-default btn-sm" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
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
                        <asp:Label ID="lblNome" runat="server" Text="Nome do Local: "></asp:Label>
                        <asp:TextBox ID="boxNome" runat="server"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblAddress" runat="server" Text="Morada: "></asp:Label>
                        <asp:TextBox ID="boxAddress" runat="server" Width="90%"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblZipCode" runat="server" Text="Código postal: "></asp:Label>
                        <asp:TextBox ID="boxZipCode" runat="server"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblGPS" runat="server" Text="GPS: "></asp:Label>
                        <asp:TextBox ID="boxGPS" runat="server"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblCity" runat="server" Text="Cidade: "></asp:Label>
                        <asp:DropDownList ID="listCity" runat="server" Width="200px" DataSourceID="CitiesDS" DataTextField="Name" DataValueField="CityID"></asp:DropDownList>
                            <asp:SqlDataSource ID="CitiesDS" runat="server" ConnectionString="<%$ ConnectionStrings:AnimalCare %>" SelectCommand="SELECT * FROM [Cities]"></asp:SqlDataSource>
                        </p>

                        <p>
                        <asp:Label ID="lblCountry" runat="server" Text="País: "></asp:Label>
                        <asp:DropDownList ID="listCountry" runat="server" Width="200px" DataSourceID="CountriesDS" DataTextField="Name" DataValueField="CountryID"></asp:DropDownList>
                            <asp:SqlDataSource ID="CountriesDS" runat="server" ConnectionString="<%$ ConnectionStrings:AnimalCare %>" SelectCommand="SELECT [CountryID], [Name] FROM [Countries]"></asp:SqlDataSource>
                        </p>

                        <p>
                        <asp:Label ID="lblMain" runat="server" Text="Local principal: "></asp:Label>
                        <asp:CheckBox ID="chkIsMain" runat="server"></asp:CheckBox>
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
