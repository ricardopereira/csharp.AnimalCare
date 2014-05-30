<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/MasterPageDoctor.Master" AutoEventWireup="true" CodeBehind="PageDoctorServices.aspx.cs" Inherits="AnimalCare.Doctor.PageDoctorServices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Profissional de Saúde<small> serviços</small></h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <!-- PROFISSIONAL -->
                <p class="lead"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-sm" href="PageDoctor.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">

                <!--FILTRO -->
                <div class="panel panel-default">

                    <div class="panel-heading">
                        <h3 class="panel-title">Serviços</h3>
                    </div>

                    <div class="panel-body">
                        <div class="btn-toolbar" role="toolbar">
                            <div class="btn-group">
                                <a class="btn btn-success" href="PageDoctorServiceNew.aspx" role="button">Novo serviço</a>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">

                        <p class="text-muted">Filtro:</p>

                        <div class="input-group">
                            <asp:TextBox ID="boxFilter" class="form-control" runat="server" type="text"></asp:TextBox>

                            <!-- PESQUISAR -->
                            <span class="input-group-btn">
                                <asp:Button ID="btnSearch" CssClass="btn btn-success" Text="Pesquisar" runat="server" type="button"></asp:Button>
                            </span>
                        </div>
                        <br />

                        <!-- DADOS -->
                        <div class="table-responsive">
                            <div class="panel panel-primary">
                                <!-- Default panel contents -->
                                <div class="panel-heading">Lista de serviços efectuados</div>

                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th class="text-center">Concluído</th>
                                            <th>Data</th>
                                            <th>Proprietário</th>
                                            <th>Animal</th>
                                            <th>Tipo</th>
                                            <th>Clínica</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="tblServices" runat="server">
                                            <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <a class="btn btn-warning btn-xs" href="PageDoctorServiceEdit.aspx?ServiceID=<%# Eval("ServiceID")%>" role="button"><span class="glyphicon glyphicon-edit"></span></a>
                                                </td>
                                                <td class="text-center">
                                                    <asp:Panel runat="server" Visible='<%# Convert.ToBoolean(Eval("Done")) %>'>
                                                        <p class="label label-success"><span class="glyphicon glyphicon-ok"></span> sim</p>
                                                    </asp:Panel>
                                                </td>
                                                <td><%# Eval("DateService") %></td>
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
                </div>

            </div>
         </div>

        <div class="row">
            <div class="col-lg-12">

                <div class="panel panel-default">
                    <div class="panel-body">
                        <!-- BOTOES -->
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Button ID="btnCancel" CssClass="btn btn-primary" runat="server" Text="Voltar" PostBackUrl="~/Doctor/PageDoctorDashboard.aspx"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
         </div>

      </div>

</asp:Content>
