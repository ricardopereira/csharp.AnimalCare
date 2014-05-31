<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/MasterPageDoctor.Master" AutoEventWireup="true" CodeBehind="PageDoctorDashboard.aspx.cs" Inherits="AnimalCare.Doctor.PageDoctorDashboard" %>
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
                <p class="lead"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-sm" href="PageDoctor.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
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
                                    <th>Descrição</th>
                                    <th>Proprietário</th>
                                    <th>Animal</th>
                                    <th>Tipo</th>
                                    <th>Clínica</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="tblLastServices" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a class="btn btn-warning btn-xs" href="PageDoctorServiceEdit.aspx?ServiceID=<%# Eval("ServiceID")%>" role="button"><span class="glyphicon glyphicon-edit"></span></a>
                                            
                                            <asp:Label CssClass="label label-success" runat="server" Text="concluído" Visible='<%# Convert.ToBoolean(Eval("Done")) %>'></asp:Label>
                                        </td>
                                        <td><%# Eval("DateService") %></td>
                                        <td><%# Eval("Description") %></td>
                                        <td><%# Eval("Owner") %></td>
                                        <td><%# Eval("Animal") %></td>
                                        <td><%# Eval("ServiceKind") %></td>
                                        <td><%# Eval("Clinic") %></td>
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
                                <asp:Button ID="btnAll" runat="server" CssClass="btn" Text="Todos" OnClick="btnAll_Click" />
                            </div>
                        </div>

                        <div class="panel-body">
                            Eventos agendados: <asp:Label ID="lblSelected" runat="server" CssClass="label label-info" Text=""></asp:Label>
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
                                            <a class="btn btn-success btn-xs" href="PageDoctorServiceNew.aspx?ScheduleID=<%# Eval("ScheduleID")%>&OwnerID=<%# Eval("OwnerID")%>&AnimalID=<%# Eval("AnimalID")%>" 
                                                role="button">Criar serviço</span></a>
                                        </td>
                                        <td><%# Eval("DateEvent") %></td>
                                        <td><%# Eval("Owner") %></td>
                                        <td><%# Eval("Animal") %></td>
                                        <td><%# Eval("Description") %></td>
                                        <td><%# Eval("ServiceKind") %></td>
                                        <td>
                                            <%# Eval("Local") %>
                                            <a href="#" class="popover-appointments btn btn-primary btn-xs" data-toggle="popover"
                                                data-content='Código-postal: <%# Eval("Local") %> - GPS <%# Eval("LocalGPS") %>' role="button"
                                                data-original-title='<%# Eval("LocalName") %>'><span class="glyphicon glyphicon-info-sign"></span></a>
                                        </td>
                                    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div><!-- ROW -->

<script type="text/javascript">
    $(document).ready(function () {
        $(".popover-appointments").popover({ placement: 'left' });
    });
</script>

</asp:Content>
