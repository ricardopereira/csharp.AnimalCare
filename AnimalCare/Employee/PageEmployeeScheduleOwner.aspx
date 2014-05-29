<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/MasterPageEmployee.Master" AutoEventWireup="true" CodeBehind="PageEmployeeScheduleOwner.aspx.cs" Inherits="AnimalCare.Employee.PageEmployeeScheduleOwner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agenda<small> escolha do proprietário</small></h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <!-- PROFISSIONAL -->
                <h4>Funcionário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageEmployee.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <br />

                <!--Filtro -->
                <div class="panel panel-default">

                    <div class="panel-heading">
                        <h3 class="panel-title">Pesquisa</h3>
                    </div>

                    <div class="panel-body">

                        <p class="text-muted">Filtro:</p>

                        <div class="input-group">
                            <asp:TextBox ID="boxFilter" class="form-control" runat="server" type="text"></asp:TextBox>

                            <!-- PESQUISAR -->
                            <span class="input-group-btn">
                                <asp:Button ID="btnSearch" CssClass="btn btn-success" Text="Pesquisar" runat="server" type="button" OnClick="btnSearch_Click"></asp:Button>
                            </span>
                        </div>
                        <br />

                        <!-- DADOS -->
                        <div class="table-responsive">
                            <div class="panel panel-primary">
                                <!-- Default panel contents -->
                                <div class="panel-heading">Resultado</div>

                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th></th>
                                            <th>Nome</th>
                                            <th>Tipo</th>
                                            <th>Sector</th>
                                            <th>País</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="tblOwners" runat="server">
                                            <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <a class="btn btn-success btn-xs" href="PageEmployeeScheduleAnimal.aspx?OwnerID=<%# Eval("OwnerID")%>" role="button"><span class="glyphicon glyphicon-ok"></span></a>
                                                </td>
                                                <td><%# Eval("Name") %></td>
                                                <td><%# Eval("Kind") %></td>
                                                <td><%# Eval("Sector") %></td>
                                                <td><%# Eval("Country") %></td>
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
                                <asp:Button ID="btnNext" CssClass="btn btn-primary" runat="server" Text="Próximo passo" OnClick="btnNext_Click"></asp:Button>
                                <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancel_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
         </div>

      </div>

</asp:Content>
