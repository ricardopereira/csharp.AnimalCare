<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="PageAdminDashboard.aspx.cs" Inherits="AnimalCare.Admin.PageAdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Administração<small> área</small></h1>
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Geral</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-2">
                            <strong>Utilizadores:</strong><br /><a href="PageAdminUsers.aspx"><span class="label label-success">Gerir</span></a>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <strong>Clinicas:</strong><br /><a href="PageAdminClinics.aspx"><span class="label label-success">Gerir</span></a>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <strong>Países:</strong><br /><a href="PageAdminCountries.aspx"><span class="label label-success">Gerir</span></a>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <strong>Cidades:</strong><br /><a href="PageAdminCities.aspx"><span class="label label-success">Gerir</span></a>
                            <br />
                        </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Animais</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-2">
                            <strong>Raças:</strong><br /><a href="PageAdminRaces.aspx"><span class="label label-warning">Gerir</span></a>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <strong>Espécies:</strong><br /><a href="PageAdminSpecies.aspx"><span class="label label-warning">Gerir</span></a>
                            <br />
                        </div>
                         <div class="col-md-2">
                            <strong>Habitats:</strong><br /><a href="PageAdminHabitats.aspx"><span class="label label-warning">Gerir</span></a>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <strong>Comportamentos:</strong><br /><a href="PageAdminAnimalConditions.aspx"><span class="label label-warning">Gerir</span></a>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <strong>Leituras:</strong><br /><a href="PageAdminAnimalDiaryType.aspx"><span class="label label-warning">Gerir</span></a>
                            <br />
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Negócio</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-2">
                            <strong>Tipo de Serviços:</strong><br /><a href="PageAdminServiceKinds.aspx"><span class="label label-primary">Gerir</span></a>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <strong>Tipo de Tratamento</strong><br /><a href="PageAdminAppointmentTypes.aspx"><span class="label label-primary">Gerir</span></a>
                            <br />
                        </div>
                        <div class="col-md-2">
                            <strong>Sector de Negócio</strong><br /><a href="PageAdminBusinessSector.aspx"><span class="label label-primary">Gerir</span></a>
                            <br />
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>