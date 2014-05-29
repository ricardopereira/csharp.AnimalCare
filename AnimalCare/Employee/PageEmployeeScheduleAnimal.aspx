<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/MasterPageEmployee.Master" AutoEventWireup="true" CodeBehind="PageEmployeeScheduleAnimal.aspx.cs" Inherits="AnimalCare.Employee.PageEmployeeScheduleAnimal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agenda<small> escolha do animal</small></h1>
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
                        <p><strong>Proprietário:</strong> <asp:Label ID="lblOwner" runat="server" Text=""></asp:Label></p>
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
                                            <th>Espécie</th>
                                            <th>Raça</th>
                                            <th>Habitat</th>
                                            <th>Tipo</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="tblAnimals" runat="server">
                                            <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <a class="btn btn-success btn-xs" href="PageEmployeeScheduleNew.aspx?AnimalID=<%# Eval("AnimalID")%>" role="button"><span class="glyphicon glyphicon-ok"></span></a>
                                                </td>
                                                <td><%# Eval("Name") %></td>
                                                <td><%# Eval("Specie") %></td>
                                                <td><%# Eval("Race") %></td>
                                                <td><%# Eval("Habitat") %></td>
                                                <td><%# Eval("Condition") %></td>
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
