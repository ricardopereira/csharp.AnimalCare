<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalHistoryItem.aspx.cs" Inherits="AnimalCare.Client.PageClientHistoryItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> registo do histórico clínico</small></h1>
            </div>
        </div>
        <div class="row well span2">

            <div class="col-md-4">
                <!-- Animal -->
                <h4>Animal</h4>
                <p class="text-muted"><strong>Nome: </strong><asp:Label runat="server" ID="lblAnimalName"></asp:Label></p>
                <p><strong>Espécie: </strong><asp:Label runat="server" ID="lblAnimalSpecie"></asp:Label></p>
                <p><strong>Raça: </strong><asp:Label runat="server" ID="lblAnimalRace"></asp:Label></p>
            </div>

            <div class="col-md-4">
                <!-- Serviço -->
                <h4>Serviço</h4>
                <p class="text-muted"><strong>Descrição: </strong><asp:Label runat="server" ID="lblServiceDescription"></asp:Label> <span class="label label-primary"><asp:Label runat="server" ID="lblServiceKind"></asp:Label></span></p>
                <p class="text-warning"><strong>Data: </strong><asp:Label runat="server" ID="lblDateService"></asp:Label></p>
                <p class="text-warning"><strong>Concluído: </strong><asp:Label runat="server" ID="lblDateConclusion"></asp:Label></p>
                <h5><b>Observações:</b></h5>
                <p><asp:Label runat="server" ID="lblObservation"></asp:Label></p>
            </div>

            <div class="col-md-4">
                <!-- Medico/Clinica -->
                <h4>Responsável</h4>
                <p class="text-muted"><strong>Profissional de saúde: </strong><asp:Label runat="server" ID="lblProfessional"></asp:Label></p>
                <p class="text-muted"><strong>Clínica: </strong><asp:Label runat="server" ID="lblClinic"></asp:Label></p>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <!-- Serviço -->
                <br />

                <!-- Tabela com os animais -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Feedback do Serviço</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <p class="text-muted">Opções da grelha</p>
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <a runat="server" class="btn btn-success" id="linkDiary" href="#" role="button">Novo Registo</a>
                                </div>
                            </div>
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>#</th>
                                    <th>Inicio</th>
                                    <th>Fim</th>
                                    <th>Obs</th>
                                </tr>
                            </thead>
                            <tbody>
                               <asp:Repeater ID="tblDiary" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                    <td>
                                        <!-- Opcoes de linha -->
                                        <a class="btn btn-primary btn-xs" href="PageAnimalDiaryEdit.aspx?DiaryItem=<%# Eval("AnimalDiaryID") %>" role="button"><span class="glyphicon glyphicon-info-sign"></span></a>
                                    </td>
                                        <td><%# Eval("AnimalDiaryID") %></td>
                                        <td><%# Eval("DateDiaryStart") %></td>
                                        <td><%# Eval("DateDiaryEnd") %></td>
                                        <td><%# Eval("Observation") %></td>
                                    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
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
                                <asp:Button ID="btnBack" CssClass="btn btn-primary" runat="server" Text="Voltar" OnClick="btnBack_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>

    </div>

</asp:Content>
