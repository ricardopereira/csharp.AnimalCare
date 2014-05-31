<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalDiaryEdit.aspx.cs" Inherits="AnimalCare.Client.PageAnimalDiaryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br />
    <br />
    <!-- Cabecalho -->
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> feedback do serviço</small></h1>
            </div>
        </div>

        <div class="row">

            <div class="col-md-4 well span2">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx?" role="button"><span class="glyphicon glyphicon-user"></span>Ver perfil</a></p>
                <br />
                <!-- Animal -->
                <h4>Animal seleccionado</h4>
                <p class="text-muted">
                    <asp:Label runat="server" ID="lblAnimalName"></asp:Label>
                    <a class="btn btn-default btn-xs" href="PageAnimal.aspx" role="button"><span class="glyphicon glyphicon-user"></span>Ver perfil</a>
                </p>
                <p>
                    Espécie:
                    <asp:Label runat="server" ID="lblAnimalSpecie"></asp:Label>
                </p>
                <p>
                    Raça:
                    <asp:Label runat="server" ID="lblAnimalRace"></asp:Label>
                </p>
            </div>

            <div class="col-md-8">

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Dados</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <p class="text-primary">Tipo:</p>
                                <p class="text-primary">Data Inicio:</p>
                                <p class="text-primary">Data Fim:</p>
                                <p class="text-primary">Valor:</p>

                            </div>
                            <div class="col-md-6">
                                <p>
                                    <asp:Label ID="lblDiaryType" runat="server" Text=""></asp:Label></p>
                                <p>
                                    <asp:Label ID="lblDateDiaryStart" runat="server"></asp:Label></p>
                                <p>
                                    <asp:Label ID="lblDateDiaryEnd" runat="server"></asp:Label></p>
                                <p>
                                    <asp:Label ID="lblValue" runat="server" Text="Valor: "></asp:Label></p>

                            </div>
                            <div class="col-md-4">
                                <img id="itemImage" runat="server" data-src="holder.js/200x200" class="img-thumbnail" alt="sem imagem" style="width: 200px; height: 200px;">
                                <p><a runat="server" id="linkImage" visible="false">Imagem em tamanho original</a></p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>


        <div class="row">

            <div class="col-lg-12">
                <!--Filtro -->
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Feedback</h3>
                    </div>
                    <div class="panel-body">

                        <p>
                        <asp:Label ID="lblObs" runat="server" Text="Observações: "></asp:Label>
                        <asp:TextBox ID="boxObs" runat="server" class="form-control" MaxLength="45"></asp:TextBox>
                        </p>

                        <div class="alert alert-info">
                        <p>
                          <strong>Comentário do profissional de saúde:</strong>
                        </p>
                        <p><asp:Label ID="boxComment" runat="server" Text="--"></asp:Label></p>
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-lg-12">
                <br />
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <!-- DADOS -->
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Gravar" OnClick="btnSave_Click"></asp:Button>
                                <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancel_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>



    </div>

</asp:Content>
