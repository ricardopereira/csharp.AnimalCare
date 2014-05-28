<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalDiary.aspx.cs" Inherits="AnimalCare.Client.PageAnimalDiary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> diário</small></h1>
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
            <div class="col-lg-12">
                <!-- Diário -->
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
                        </p>

                        <p>
                        <asp:Label ID="lblType" runat="server" Text="Tipo: "></asp:Label>
                        <asp:DropDownList ID="listType" runat="server" Width="200px" DataSourceID="TiposDS" DataTextField="Description" DataValueField="AnimalDiaryTypeID"></asp:DropDownList>
                            <asp:SqlDataSource ID="TiposDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalDiaryTypes]"></asp:SqlDataSource>
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
                                <div class="btn-group">
                                    <!-- Novo registo -->
                                    <a class="btn btn-success" href="#" data-toggle="modal" data-target="#DiaryModal" role="button">Novo registo</a>
                                </div>

                                <!-- Modal -->
                                <div class="modal fade" id="DiaryModal" tabindex="-1" role="dialog" aria-labelledby="DiaryModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title" id="DiaryModalLabel">Registo do diário</h4>
                                            </div>
                                            <div class="modal-body">
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
                                            <div class="modal-footer">
                                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Gravar" OnClick="btnSave_Click"></asp:Button>
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- /btn-group -->
                                <div class="btn-group dropdown">
                                    <button type="button" class="btn btn-primary">Ordenação</button>
                                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
                                        <span class="caret"></span>
                                        <span class="sr-only">Ordenação</span>
                                    </button>
                                    <ul class="dropdown-menu pull-right" role="menu">
                                        <li><a href="#">Ascendente</a></li>
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
                                    <th>Data</th>
                                    <th>Tipo</th>
                                    <th>Valor</th>
                                    <th>Obs</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <!-- Opcoes de linha -->
                                        <a class="btn btn-primary btn-xs" href="PageAnimalDiaryItem.aspx" role="button"><span class="glyphicon glyphicon-info-sign"></span></a>
                                    </td>
                                    <td>1</td>
                                    <td>12/04/2014</td>
                                    <td>Temperatura</td>
                                    <td>31,34</td>
                                    <td>Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>


</asp:Content>
