<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageClientDashboard.aspx.cs" Inherits="AnimalCare.Client.PageClientDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cliente<small> dashboard</small></h1>
                <div class="alert alert-warning">
                    <strong>Aviso!</strong> Existem serviços pendentes.
                </div>
            </div>
        </div>

        <div class="row">
            <!-- PERFIL -->
            <div class="col-md-6">
                <p class="lead"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-sm" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed diam eget risus varius blandit sit amet non magna. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Cras mattis consectetur purus sit amet fermentum. Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Aenean lacinia bibendum nulla sed consectetur.</p>
            </div>

            <!-- MARCACOES -->
            <div class="col-md-6">
                <!-- Tabela com as marcacoes -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Pedido de marcações</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <div class="btn-group">
                                <a class="btn btn-success" href="#" role="button">Nova marcação</a>
                            </div>
                        </div>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Data</th>
                                    <th>Descrição</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tblAppointments" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <!-- Opcoes de linha -->
                                            <a class="btn btn-warning btn-xs" href="#" role="button"><span class="glyphicon glyphicon-edit"></span></a>
                                        </td>
                                        <td><%# Eval("DateAppointment")%></td>
                                        <td><%# Eval("Reason")%></td>
                                        <td>Em espera</td>
                                    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div><!-- ROW -->

        <div class="row">
            <!-- MARCACOES -->
            <div class="col-md-12">
                <!-- Tabela com as marcacoes -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Agenda</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            Próximas consultas e tratamentos
                        </div>
                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Data</th>
                                    <th>Descrição</th>
                                    <th>Serviço</th>
                                    <th>Animal</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tblSchedule" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <!-- Opcoes de linha -->
                                            <a class="btn btn-warning btn-xs" href="#" role="button"><span class="glyphicon glyphicon-edit"></span></a>
                                        </td>
                                        <td><%# Eval("DateAppointment")%></td>
                                        <td><%# Eval("Description")%></td>
                                        <td><%# Eval("ServiceKind")%></td>
                                        <td><%# Eval("Animal")%></td>
                                    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div><!-- ROW -->

    </div>

</asp:Content>