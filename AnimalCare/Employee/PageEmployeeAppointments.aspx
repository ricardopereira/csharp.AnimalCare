<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/MasterPageEmployee.Master" AutoEventWireup="true" CodeBehind="PageEmployeeAppointments.aspx.cs" Inherits="AnimalCare.Employee.PageEmployeeAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Marcação<small> revisão do pedido de marcação</small></h1>
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
            <div class="col-md-4 well span2">
                <!-- CLIENTE -->
                <h4>Proprietário</h4>
                
                <p class="text-muted">
                    <asp:Label ID="lblOwner" runat="server" Text="sem dado"></asp:Label>
                    <a class="btn btn-default btn-xs" href="#" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a>
                </p>

                <br />
                <!-- Animal -->
                <h4>Animal</h4>
                <p class="text-muted">
                    <asp:Label ID="lblAnimal" runat="server" Text="sem dado"></asp:Label>
                    <a class="btn btn-default btn-xs" href="#" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a>
                </p>

                <p><strong>Espécie:</strong> <asp:Label ID="lblSpecie" runat="server" Text="sem dado"></asp:Label></p>
                <p><strong>Raça:</strong> <asp:Label ID="lblRace" runat="server" Text="sem dado"></asp:Label></p>
                <p><strong>Pedido:</strong> <asp:Label CssClass="label label-default" ID="lblAppointmentType" runat="server" Text="sem dado"></asp:Label></p>
                <p><strong>Data pedida:</strong> <asp:Label ID="lblDate" runat="server" Text="sem dado"></asp:Label></p>
                <p><strong>Detalhe:</strong> <asp:Label ID="lblDetail" runat="server" Text="sem dado"></asp:Label></p>
                <h3><asp:Label ID="lblUrgent" CssClass="label label-danger" runat="server" Text="Urgente"></asp:Label></h3>
                <h3><asp:Label ID="lblCanceled" CssClass="label label-warning" runat="server" Text="Cancelado" Visible="false"></asp:Label></h3>
            </div>
            <div class="col-md-8">
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Revisão</h3>
                    </div>
                    <div class="panel-body">
                        
                        <!-- ESTADOS -->
                        <asp:RadioButtonList ID="rdbState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbState_SelectedIndexChanged">
                            <asp:ListItem Value="1">Aceitar</asp:ListItem>
                            <asp:ListItem Value="2">Rejeitar</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorState" runat="server" ControlToValidate="rdbState"
                            CssClass="field-validation-error text-danger" ErrorMessage="Especifique o estado." />

                        <!-- MOTIVO de rejeicao -->
                        <p>
                        <asp:Label ID="lblReason" runat="server" Text="Motivo: "></asp:Label>
                        <asp:TextBox ID="boxReason" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorReason" runat="server" ControlToValidate="boxReason"
                            CssClass="field-validation-error text-danger" ErrorMessage="Especifique o motivo." />
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
                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Gravar" OnClick="btnSave_Click"></asp:Button>
                                <asp:Button ID="btnCreateAndSave" CssClass="btn btn-success" runat="server" Text="Gravar e gerar evento" OnClick="btnCreateAndSave_Click"></asp:Button>
                                <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancelar" CausesValidation="false" OnClick="btnCancel_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
      </div>

</asp:Content>