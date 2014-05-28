<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/MasterPageEmployee.Master" AutoEventWireup="true" CodeBehind="PageEmployeeDashboard.aspx.cs" Inherits="AnimalCare.Employee.PageEmployeeDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">


    <br /><br />
    <!-- Cabecalho -->
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Funcionário<small> dashboard</small></h1>

                <% if (Ctrl.hasWaitingAppointments())
                   {
                %>
                <div class="alert alert-warning">
                    <strong>Aviso!</strong> Existem marcações em espera.
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                </div>
                <% } %>

            </div>
        </div>

        <div class="row">
            <!-- PERFIL -->
            <div class="col-md-4">
                <p class="lead"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-sm" href="PageEmployee.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
            </div>

            <!-- MARCACOES -->
            <div class="col-md-8">
                <!-- Tabela com as marcacoes -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Pedido de marcações</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <div class="btn-group">
                                <a class="btn btn-success" href="PageEmployeeAppointments.aspx" role="button">Nova marcação</a>
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

                                        </td>
                                        <td><%# Eval("DateAppointment") %></td>
                                        <td><%# Eval("Reason") %></td>
                                        <td><%# Eval("StateStr") %></td>
                                    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div><!-- ROW -->

</asp:Content>