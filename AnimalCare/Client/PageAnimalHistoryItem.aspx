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
                <br />
                <!-- Serviço -->
                <h4>Serviço seleccionado</h4>
                <p class="text-muted">Cirurgia ao olho <span class="label label-primary">Cirurgia</span></p>
                <p class="text-danger">Data: 04-04-2014</p>
                <h5><b>Observações</b> <small>(editado em 05-04-2014)</small></h5>
                <p>At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus.</p>
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
                        <div class="panel-heading">Relatório do serviço</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <p class="text-muted">Opções da grelha</p>
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <a class="btn btn-success" href="#" role="button">Nova informação</a>
                                </div>
                            </div>
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Data</th>
                                    <th>Informação</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>05-04-2014</td>
                                    <td>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
