<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalHistory.aspx.cs" Inherits="AnimalCare.Client.PageAnimalHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> histórico clínico</small></h1>
            </div>
        </div>
        <div class="row well span2">
            <div class="col-lg-12">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: User.Identity.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
                <!-- Animal -->
                <h4>Animal seleccionado</h4>
                <p class="text-muted">Quinzé <a class="btn btn-default btn-xs" href="PageAnimal.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <p>Espécie: Cão</p>
                <p>Raça: Dogue Alemão</p>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <!-- Histórico clínico -->
                <br />
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Filtro</h3>
                    </div>
                    <div class="panel-body">
                        <p>
                        <asp:Label ID="lblDateFrom" runat="server" Text="Data: "></asp:Label>
                        <asp:TextBox ID="boxDateFrom" runat="server"></asp:TextBox>
                        <asp:Calendar ID="calDateFrom" runat="server"></asp:Calendar>
                        </p>
                    </div>
                </div>

                <!-- Tabela com os animais -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Dados</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <p class="text-muted">Opções da grelha</p>
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group dropdown">
                                    <button type="button" class="btn btn-default">Selecção</button>
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                        <span class="caret"></span>
                                        <span class="sr-only">Selecção</span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">
                                        <li><a href="#">Seleccionar tudo</a></li>
                                        <li><a href="#">Inverter selecção</a></li>
                                        <li><a href="#">Retirar selecção</a></li>
                                    </ul>
                                </div>
                                <!-- /btn-group -->
                                <div class="btn-group dropdown">
                                    <button type="button" class="btn btn-primary">Ordenação</button>
                                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
                                        <span class="caret"></span>
                                        <span class="sr-only">Ordenação</span>
                                    </button>
                                    <ul class="dropdown-menu pull-right" role="menu">
                                        <li><a href="#">Ascedente</a></li>
                                        <li><a href="#">Decrescente</a></li>
                                    </ul>
                                </div>
                                <!-- /btn-group -->
                            </div>
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>#</th>
                                    <th>Serviço</th>
                                    <th>Data</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <!-- Opcoes de linha -->
                                        <a class="btn btn-primary btn-xs" href="PageAnimalHistoryItem.aspx" role="button"><span class="glyphicon glyphicon-info-sign"></span></a>
                                    </td>
                                    <td>1</td>
                                    <td>Lorem</td>
                                    <td>ipsum</td>
                                    <td>dolor</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
