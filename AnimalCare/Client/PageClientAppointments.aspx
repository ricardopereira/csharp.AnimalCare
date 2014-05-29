<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageClientAppointments.aspx.cs" Inherits="AnimalCare.Client.PageClientAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

   <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Marcação<small> pedido de marcação</small></h1>
            </div>
        </div>
        <div class="row well span2">
            <div class="col-lg-12">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <br />
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Calendário</h3>
                    </div>
                    <div class="panel-body">
                        <!-- DADOS -->
                        <div class="row">
                            <div class="col-md-4">
                                <p><asp:Calendar ID="calDateAppointment" runat="server"></asp:Calendar></p>
                                <p>
                                    Hora:<asp:DropDownList ID="listHour" runat="server"></asp:DropDownList>
                                    :<asp:DropDownList ID="listMinutes" runat="server"></asp:DropDownList>(HH:MM)
                                </p>
                            </div>
                            <div class="col-md-8">
                                <p>
                                <asp:Label ID="lblDetail" runat="server" Text="Motivo: "></asp:Label>
                                <asp:TextBox ID="boxDetail" runat="server" class="form-control" MaxLength="45"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorReason" runat="server" ControlToValidate="boxDetail"
                                    CssClass="field-validation-error text-danger" ErrorMessage="Especifique algum detalhe da marcação." />
                                </p>

                                <asp:Label ID="lblAppointmentTypes" runat="server" Text="Tipo de marcação: "></asp:Label>
                                <asp:DropDownList ID="listAppointmentTypes" runat="server" DataSourceID="AppointmentTypesDS" DataTextField="Description" DataValueField="AppointmentTypeID">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="AppointmentTypesDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AppointmentTypes]"></asp:SqlDataSource>

                                <p>
                                <asp:Label ID="lblUrgent" runat="server" Text="Urgente: "></asp:Label>
                                <asp:CheckBox ID="chkUrgent" runat="server" OnCheckedChanged="chkUrgent_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                </p>

                                <br /><br />
                                
                                <asp:Label ID="lblAnimais" runat="server" Text="Animais:"></asp:Label>
                                <asp:CheckBoxList ID="chkAnimais" runat="server" DataSourceID="AnimaisDS" DataTextField="Name" DataValueField="AnimalID">
                                </asp:CheckBoxList>
                                <asp:SqlDataSource ID="AnimaisDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Name], [AnimalID] FROM [Animals]">
                                </asp:SqlDataSource>
                                <br />

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <!-- Espaço em branco -->
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Solicitar pedido" OnClick="btnSave_Click"></asp:Button>
                                <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancelar" CausesValidation="false" OnClick="btnCancel_Click"></asp:Button>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
         </div>
      </div>

</asp:Content>
