<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalDiaryItem.aspx.cs" Inherits="AnimalCare.Client.PageAnimalDiaryItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> registo do diário</small></h1>
            </div>
        </div>
        <div class="row well span2">
            <div class="col-lg-12">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
                <!-- Animal -->
                <h4>Animal seleccionado</h4>
                <p class="text-muted">Quinzé <a class="btn btn-default btn-xs" href="PageAnimal.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <p>Espécie: Cão</p>
                <p>Raça: Dogue Alemão</p>
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
                        <asp:Label ID="lblDiaryType" runat="server" Text="Tipo: "></asp:Label>
                        <asp:DropDownList ID="listDiaryType" runat="server" Width="200px" DataSourceID="TiposDiarioDS" DataTextField="Description" DataValueField="AnimalDiaryTypeID"></asp:DropDownList>
                            <asp:SqlDataSource ID="TiposDiarioDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalDiaryTypes]"></asp:SqlDataSource>
                        </p>

                        <p>
                        <asp:Label ID="lblDateDiaryTo" runat="server" Text="Data de: "></asp:Label>
                        <asp:TextBox ID="boxDateDiaryTo" runat="server"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblDateDiaryFrom" runat="server" Text="Data até: "></asp:Label>
                        <asp:TextBox ID="boxDateDiaryFrom" runat="server"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblDiaryValue" runat="server" Text="Valor: "></asp:Label>
                        <asp:TextBox ID="boxDiaryValue" runat="server"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblDiaryObs" runat="server" Text="Observações: "></asp:Label>
                        <asp:TextBox ID="boxDiaryObs" runat="server"></asp:TextBox>
                        </p>

                        <button type="button" class="btn btn-default btn-xs" data-dismiss="modal">Carregar imagem</button>
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
