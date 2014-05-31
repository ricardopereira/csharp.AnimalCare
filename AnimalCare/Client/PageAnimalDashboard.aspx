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

                        <!-- BOTOES -->
                        <div class="panel-body">
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <a class="btn btn-success" href="PageAnimalNew.aspx" role="button">Novo animal</a>
                                </div>
                            </div>
                        </div>

                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <p class="text-muted">Opções da grelha</p>
                            <div class="btn-toolbar" role="toolbar">

                                <div class="input-group">
                                    <asp:TextBox ID="boxFilter" class="form-control" runat="server" type="text"></asp:TextBox>

                                    <!-- PESQUISAR -->
                                    <span class="input-group-btn">
                                        <asp:Button ID="btnSearch" CssClass="btn btn-primary" Text="Pesquisar" runat="server" type="button" OnClick="btnSearch_Click"></asp:Button>
                                    </span>
                                </div>

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
                                            <td style="width: 280px;">
                                            <!-- Opcoes de linha -->
                                                <a class="btn btn-primary btn-xs" href="PageAnimal.aspx?AnimalID=<%# Eval("AnimalID")%>" role="button"><span class="glyphicon glyphicon-info-sign"></span></a>
                                                <a class="btn btn-warning btn-xs" href="PageAnimalEdit.aspx?AnimalID=<%# Eval("AnimalID")%>" role="button"><span class="glyphicon glyphicon-edit"></span> Editar</a>
                                                <a class="btn btn-info btn-xs" href="PageAnimalHistory.aspx?AnimalID=<%# Eval("AnimalID")%>" role="button"><span class="glyphicon glyphicon-file"></span> Histórico</a>
                                                <a class="btn btn-success btn-xs" href="PageAnimalDiary.aspx?AnimalID=<%# Eval("AnimalID")%>" role="button"><span class="glyphicon glyphicon-paperclip"></span> Diário</a>
                                            </td>
                                            <td>
                                                <%# Eval("AnimalID")%>
                                            </td>
                                            <td>
                                                <%# Eval("Name")%>
                                            </td>
                                            <td style="width: 120px;"><%# Eval("Race")%></td>
                                            <td style="width: 120px;"><%# Eval("Specie")%></td>
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