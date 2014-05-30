<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/MasterPageDoctor.Master" AutoEventWireup="true" CodeBehind="PageDoctorServiceAnimal.aspx.cs" Inherits="AnimalCare.Doctor.PageDoctorServiceAnimal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Serviço<small> escolha do animal</small></h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <!-- PROFISSIONAL -->
                <h4>Profissional de Saúde</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageDoctor.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
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
                                <div class="panel-heading">Animais</div>

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
                                                    <a class="btn btn-success btn-xs" href="PageDoctorServiceNew.aspx?AnimalID=<%# Eval("AnimalID")%>&OwnerID=<%# Eval("OwnerID")%>" role="button"><span class="glyphicon glyphicon-ok"></span></a>
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
                                <asp:Button ID="btnVoltar" CssClass="btn btn-primary" runat="server" Text="Voltar" PostBackUrl="~/Doctor/PageDoctorServiceOwner.aspx"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
         </div>

      </div>

</asp:Content>