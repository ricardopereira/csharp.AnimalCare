<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalDashboard.aspx.cs" Inherits="AnimalCare.Client.PageAnimalDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> dashboard</small></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <h4>Proprietário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
                <!-- Tabela com os animais -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Animais</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <p class="text-muted">Opções da grelha</p>
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <a class="btn btn-success" href="PageAnimalNew.aspx" role="button">Novo animal</a>
                                </div>
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
                                    <button type="button" class="btn btn-default">Ordenação</button>
                                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
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
                                    <th>Nome</th>
                                    <th>Espécie</th>
                                    <th>Raça</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tabelaAnimais" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <!-- Opcoes de linha -->
                                            <a class="btn btn-primary btn-xs" href="PageAnimal.aspx?AnimalID=<%# Eval("AnimalID")%>" role="button"><span class="glyphicon glyphicon-info-sign"></span></a>
                                            <a class="btn btn-warning btn-xs" href="PageAnimalEdit.aspx?AnimalID=<%# Eval("AnimalID")%>" role="button"><span class="glyphicon glyphicon-edit"></span></a>
                                        </td>
                                        <td>
                                            <%# Eval("AnimalID")%>
                                        </td>
                                        <td>
                                            <%# Eval("Name")%>
                                        </td>
                                        <td><%# Eval("Race")%></td>
                                        <td><%# Eval("Specie")%></td>
                                    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>

                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>