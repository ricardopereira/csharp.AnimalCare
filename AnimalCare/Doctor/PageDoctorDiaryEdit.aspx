<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/MasterPageDoctor.Master" AutoEventWireup="true" CodeBehind="PageDoctorDiaryEdit.aspx.cs" Inherits="AnimalCare.Doctor.PageDoctorDiaryEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Serviço<small> intervenção do proprietário</small></h1>
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
            <div class="col-md-4 well span2">
                <!-- CLIENTE -->
                <h4>Proprietário</h4>
                
                <p class="text-muted">
                    <asp:Label ID="lblOwner" runat="server" Text=""></asp:Label>
                    <a class="btn btn-default btn-xs" href="#" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a>
                </p>

                <!-- Animal -->
                <br />
                <h4>Animal</h4>
                <p class="text-muted">
                    <asp:Label ID="lblAnimal" runat="server" Text=""></asp:Label>
                    <a class="btn btn-default btn-xs" href="#" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a>
                </p>
                <p><strong>Espécie:</strong> <asp:Label ID="lblSpecie" runat="server" Text="sem dado"></asp:Label></p>
                <p><strong>Raça:</strong> <asp:Label ID="lblRace" runat="server" Text="sem dado"></asp:Label></p>

                <br />
                <h3><asp:Label ID="lblDone" CssClass="label label-success" runat="server" Text="Concluído" Visible="false"></asp:Label></h3>
            </div>

        </div>


        <div class="row">

            <div class="col-lg-12">
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Diário</h3>
                    </div>
                    <div class="panel-body">

                        <p>
                        <asp:Label ID="lblComment" runat="server" Text="Comentário: "></asp:Label>
                        <asp:TextBox ID="boxComment" runat="server" class="form-control" MaxLength="150"></asp:TextBox>
                        </p>

                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-lg-12">
                <br />
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <!-- DADOS -->
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Gravar"></asp:Button>
                                <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancelar" PostBackUrl="PageDoctorDashboard.aspx" CausesValidation="false"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
      </div>

</asp:Content>
