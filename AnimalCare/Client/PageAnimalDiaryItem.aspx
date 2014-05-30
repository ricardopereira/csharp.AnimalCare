<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalDiaryItem.aspx.cs" Inherits="AnimalCare.Client.PageAnimalDiaryItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> anotação do diário</small></h1>
            </div>
        </div>
        <div class="row well span2">
            <div class="col-lg-12">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx?" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
                <!-- Animal -->
                <h4>Animal seleccionado</h4>
                <p class="text-muted"><asp:Label runat="server" ID="lblAnimalName"></asp:Label> <a class="btn btn-default btn-xs" href="PageAnimal.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <p>Espécie: <asp:Label runat="server" ID="lblAnimalSpecie"></asp:Label></p>
                <p>Raça: <asp:Label runat="server" ID="lblAnimalRace"></asp:Label></p>
            </div>
        </div>
        <div class="row">
            <br /><br />
            <!-- Campos -->
            <div class="col-md-2"></div>
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Dados</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <p>Tipo:</p>
                                <p>Data Inicio:</p>
                                <p>Data Fim:</p>
                                <p>Inserido em:</p>
                                <p>Valor:</p>
                                <p>Observações:</p>
                            </div>
                            <div class="col-md-6">
                                <p><asp:Label ID="lblDiaryType" runat="server" Text=""></asp:Label></p>
                                <p><asp:Label ID="lblDateDiaryStart" runat="server"></asp:Label></p>
                                <p><asp:Label ID="lblDateDiaryEnd" runat="server"></asp:Label></p>
                                <p><asp:Label ID="lblCreated" runat="server"></asp:Label></p>
                                <p><asp:Label ID="lblValue" runat="server" Text="Valor: "></asp:Label></p>
                                <p><asp:Label ID="lblDiaryObs" runat="server"></asp:Label></p>
                            </div>
                            <div class="col-md-4">
                                <img id="itemImage" runat="server" data-src="holder.js/200x200" class="img-thumbnail" alt="animal image" style="width: 200px; height: 200px;">
                                <p><a runat="server" id="linkImage" visible="false">Imagem em tamanho original</a></p>
                            </div>
                    </div>
                </div>
             </div>
             <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Button ID="btnDash" CssClass="btn btn-primary" runat="server" Text="Voltar ao Dashboard" OnClick="btnDash_Click"></asp:Button>
                        <asp:Button ID="btnBack"   CssClass="btn btn-default" runat="server" Text="Voltar Atrás" OnClick="btnBack_Click"></asp:Button>
                    </div>
                </div>
    </div>

</asp:Content>
