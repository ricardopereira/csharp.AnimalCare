﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/MasterPageEmployee.Master" AutoEventWireup="true" CodeBehind="PageEmployeeDashboard.aspx.cs" Inherits="AnimalCare.Employee.PageEmployeeDashboard" %>
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
            <div class="col-lg-12">
                <h4>Funcionário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageEmployee.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>

        <div class="row">
            <!-- MARCACOES -->
            <div class="col-lg-12">
                <!-- Tabela com as marcacoes -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading"><strong>Pedido de marcações</strong></div>

                        <div class="panel-body">
                            Todas as marcações de clientes em espera de uma resposta:
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Data</th>
                                    <th>Proprietário</th>
                                    <th>Animal</th>
                                    <th>Descrição</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tblAppointments" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a class="btn btn-primary btn-xs" href="PageEmployeeAppointments.aspx?AppointmentID=<%# Eval("AppointmentID")%>" role="button"><span class="glyphicon glyphicon-info-sign"></span></a>

                                            <asp:Label ID="lblUrgent" CssClass="label label-danger" runat="server" Text="Urgente"
                                                Visible='<%# Convert.ToBoolean(Eval("Urgent")) %>'></asp:Label>
                                        </td>
                                        <td><asp:Label Text='<%# Eval("DateAppointment") %>' runat="server" Font-Strikeout='<%# Convert.ToInt32(Eval("State")) == (int)AnimalCare.AppointmentState.astCanceled %>'></asp:Label></td>
                                        <td><%# Eval("Owner") %></td>
                                        <td><%# Eval("Animal") %></td>
                                        <td><%# Eval("Detail") %></td>
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

        <div class="row">
            <!-- MARCACOES -->
            <div class="col-lg-12">
                <!-- Tabela com as marcacoes -->
                <div class="table-responsive">
                    <div class="panel panel-warning">
                        <!-- Default panel contents -->
                        <div class="panel-heading"><strong>Agenda</strong></div>

                        <div class="panel-body">
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <a class="btn btn-success" href="PageEmployeeScheduleNew.aspx" role="button">Novo evento</a>
                                </div>
                            </div>
                        </div>

                        <div class="panel-body">
                            Eventos associados a cada profissional de saúde:
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Data</th>
                                    <th>Profissional</th>
                                    <th>Proprietário</th>
                                    <th>Animal</th>
                                    <th>Descrição</th>
                                    <th>Serviço</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tblSchedule" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a class="btn btn-warning btn-xs" href="PageEmployeeScheduleEdit.aspx?ScheduleID=<%# Eval("ScheduleID")%>" role="button"><span class="glyphicon glyphicon-edit"></span></a>
                                        </td>
                                        <td><%# Eval("DateEvent") %></td>
                                        <td><%# Eval("Professional") %></td>
                                        <td><%# Eval("Owner") %></td>
                                        <td><%# Eval("Animal") %></td>
                                        <td><%# Eval("Description") %></td>
                                        <td><%# Eval("ServiceKind") %></td>
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