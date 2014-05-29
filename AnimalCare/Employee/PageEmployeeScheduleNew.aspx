<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/MasterPageEmployee.Master" AutoEventWireup="true" CodeBehind="PageEmployeeScheduleNew.aspx.cs" Inherits="AnimalCare.Employee.PageEmployeeScheduleNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Agenda<small> criação de um evento</small></h1>
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
                    <asp:Label ID="lblOwner" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblOwnerID" runat="server" Text="" Visible="false"></asp:Label>
                    <a class="btn btn-default btn-xs" href="#" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a>
                </p>

                <!-- Animal -->
                <br />
                <h4>Animal</h4>
                <p class="text-muted">
                    <asp:Label ID="lblAnimal" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblAnimalID" runat="server" Text="" Visible="false"></asp:Label>
                    <a class="btn btn-default btn-xs" href="#" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a>
                </p>
                <p><strong>Espécie:</strong> <asp:Label ID="lblSpecie" runat="server" Text="sem dado"></asp:Label></p>
                <p><strong>Raça:</strong> <asp:Label ID="lblRace" runat="server" Text="sem dado"></asp:Label></p>

                <!-- Appointment -->
                <asp:Panel ID="pnlAppointment" runat="server" Visible="false">
                    <br />
                    <h4>Marcação</h4>
                    <p><strong>Pedido:</strong> <asp:Label CssClass="label label-default" ID="lblAppointmentType" runat="server" Text="sem dado"></asp:Label></p>
                    <p><strong>Data do pedido:</strong> <asp:Label ID="lblDate" runat="server" Text="sem dado"></asp:Label></p>
                    <p><strong>Detalhe:</strong> <asp:Label ID="lblDetail" runat="server" Text="sem dado"></asp:Label></p>
                    <h3><asp:Label ID="lblUrgent" CssClass="label label-danger" runat="server" Text="Urgente"></asp:Label></h3>
                    <asp:Label ID="lblAppointmentID" runat="server" Text="" Visible="false"></asp:Label>
                </asp:Panel>

            </div>

            <div class="col-md-4">

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Data</h3>
                    </div>
                    <div class="panel-body">
                        <asp:Calendar ID="calDateEvent" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="16px" NextPrevFormat="FullMonth" Width="237px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Evento</h3>
                    </div>
                    <div class="panel-body">

                        <p>
                        <asp:Label ID="lblDescription" runat="server" Text="Descrição: "></asp:Label>
                        <asp:TextBox ID="boxDescription" runat="server" class="form-control" MaxLength="50" Wrap="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server" ControlToValidate="boxDescription"
                            CssClass="field-validation-error text-danger" ErrorMessage="Especifique a descrição do evento." />
                        </p>

                        <p>
                        <asp:Label ID="lblServiceKind" runat="server" Text="Tipo de serviço: "></asp:Label>
                        <asp:DropDownList ID="listServiceKind" runat="server" DataSourceID="ServiceKindDS" DataTextField="Description" DataValueField="ServiceKindID">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="ServiceKindDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ServiceKindID], [Description] FROM [ServiceKinds]"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorServiceKind" runat="server" ControlToValidate="listServiceKind"
                            CssClass="field-validation-error text-danger" ErrorMessage="Especifique o tipo de serviço." />
                        </p>

                        <p>
                        <asp:Label ID="lblProfessional" runat="server" Text="Profissional: "></asp:Label>
                        <asp:DropDownList ID="listProfessional" runat="server" DataSourceID="ProfessionalDS" DataTextField="Name" DataValueField="ProfessionalID">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="ProfessionalDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ProfessionalID], [Name] FROM [Professionals]"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorProfessional" runat="server" ControlToValidate="listProfessional"
                            CssClass="field-validation-error text-danger" ErrorMessage="Especifique o profissional de saúde." />
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
                                <asp:Button ID="btnCreate" CssClass="btn btn-primary" runat="server" Text="Criar evento" OnClick="btnCreate_Click"></asp:Button>
                                <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancelar" PostBackUrl="PageEmployeeDashboard.aspx"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
      </div>

</asp:Content>
