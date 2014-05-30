﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/MasterPageDoctor.Master" AutoEventWireup="true" CodeBehind="PageDoctorDashboard.aspx.cs" Inherits="AnimalCare.Doctor.PageDoctorDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Profissional de Saúde<small> dashboard</small></h1>
            </div>
        </div>

        <div class="row">
            <!-- PERFIL -->
            <div class="col-lg-12">
                <h4>Profissional de Saúde</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageDoctor.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>

        <div class="row">
            <!-- ULTIMOS SERVICOS -->
            <div class="col-lg-12">
                <!-- Tabela com os ultimos serviços -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading"><strong>Últimos serviços</strong></div>

                        <div class="panel-body">
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <a class="btn btn-success" href="PageDoctorServiceNew.aspx" role="button">Novo serviço</a>
                                </div>
                            </div>
                        </div>

                        <div class="panel-body">
                            Últimos serviços efectuados:
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Data</th>
                                    <th>Animal</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tblLastServicos" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a class="btn btn-warning btn-xs" href="PageDoctorServiceEdit.aspx?ServiceID=<%# Eval("ServiceID")%>" role="button"><span class="glyphicon glyphicon-edit"></span></a>
                                        </td>
                                        <td><%# Eval("DataService") %></td>
                                        <td><%# Eval("Animal") %></td>
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
                                    <asp:Button ID="btnDay" runat="server" CssClass="btn" Text="Hoje" OnClick="btnDay_Click" />
                                    <asp:Button ID="btnWeek" runat="server" CssClass="btn" Text="Semana" OnClick="btnWeek_Click" />
                                    <asp:Button ID="btnMonth" runat="server" CssClass="btn" Text="Mês" OnClick="btnMonth_Click" />
                                </div>
                            </div>
                        </div>

                        <div class="panel-body">
                            Eventos agendados: <asp:Label ID="lblSelected" runat="server" Text=""></asp:Label>
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Data</th>
                                    <th>Proprietário</th>
                                    <th>Animal</th>
                                    <th>Descrição</th>
                                    <th>Serviço</th>
                                    <th>Local</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tblSchedule" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a class="btn btn-success btn-xs" href="PageDoctorServiceNew.aspx?ScheduleID=<%# Eval("ScheduleID")%>" role="button">Criar serviço</span></a>
                                        </td>
                                        <td><%# Eval("DateEvent") %></td>
                                        <td><%# Eval("Owner") %></td>
                                        <td><%# Eval("Animal") %></td>
                                        <td><%# Eval("Description") %></td>
                                        <td><%# Eval("ServiceKind") %></td>
                                        <td>GPS</td>
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
