<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageClientLocals.aspx.cs" Inherits="AnimalCare.Client.PageClientLocals" %>
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
                <p class="lead"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-sm" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
                <!-- Tabela com os locais -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Mensagem Erro -->
                        <asp:Panel ID="pnlError" runat="server" Visible="false">
                            <div class="alert alert-danger fade in">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                <h4>Erro na Inserção de um Novo Animal</h4>
                                <p>Foi automaticamente encaminhado para esta página, por ter tentado inserir um novo animal</p>
                                <p>sem que previamente tenha definido o(s) seu(s) locai(s).</p>
                            </div>
                        </asp:Panel>
                        <!-- Default panel contents -->
                        <div class="panel-heading">Locais</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <p class="text-muted">Opções da grelha</p>
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <a class="btn btn-success" href="PageClientLocalEdit.aspx" role="button">Novo local</a>
                                </div>
                                <!-- Selecção -->
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
                                <!-- Ordenação -->
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
                            </div>
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>#</th>
                                    <th>Nome</th>
                                    <th>Morada</th>
                                    <th>Postal</th>
                                    <th>Cidade</th>
                                    <th>País</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tblLocals" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <!-- Opcoes de linha -->
                                            <a class="btn btn-warning btn-xs" href="PageClientLocalEdit.aspx?OwnerLocalID=<%# Eval("OwnerLocalID")%>" role="button"><span class="glyphicon glyphicon-edit"></span></a>
                                        
                                            <a class="btn btn-danger btn-xs" data-ownerlocalid='<%# Eval("OwnerLocalID")%>' onserverclick="linkDelete_ServerClick" runat="server" href="#" role="button"><span class="glyphicon glyphicon-remove"></span></a>
                                        </td>
                                        <td>
                                            <%# Eval("OwnerLocalID")%>
                                        </td>
                                        <td>
                                            <%# Eval("Name")%>
                                        </td>
                                        <td><%# Eval("Address")%></td>
                                        <td><%# Eval("ZipCode")%></td>
                                        <td><%# Eval("City")%></td>
                                        <td><%# Eval("Country")%></td>
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
