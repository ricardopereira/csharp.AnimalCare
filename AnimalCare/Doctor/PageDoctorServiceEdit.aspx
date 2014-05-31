<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/MasterPageDoctor.Master" AutoEventWireup="true" CodeBehind="PageDoctorServiceEdit.aspx.cs" Inherits="AnimalCare.Doctor.PageDoctorServiceEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Serviço<small> informação</small></h1>
                <p><span class="label label-success">modo edição</span></p>
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

            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Data</h3>
                    </div>
                    <div class="panel-body">
                        <asp:Calendar ID="calDateService" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="16px" NextPrevFormat="FullMonth" Width="237px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                        <br />
                        <p>
                            Hora:<asp:DropDownList ID="listHourService" runat="server"></asp:DropDownList>
                            :<asp:DropDownList ID="listMinutesService" runat="server"></asp:DropDownList>(HH:MM)
                        </p>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Serviço</h3>
                    </div>
                    <div class="panel-body">

                        <p>
                        <asp:Label ID="lblDescription" runat="server" Text="Descrição: "></asp:Label>
                        <asp:TextBox ID="boxDescription" runat="server" class="form-control" MaxLength="100" Wrap="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="boxDescription"
                            CssClass="field-validation-error text-danger" ErrorMessage="Especifique a descrição do evento." />
                        </p>

                        <p>
                        <asp:Label ID="lblServiceKind" runat="server" Text="Tipo de serviço: "></asp:Label>
                        <asp:DropDownList ID="listServiceKind" class="form-control" runat="server" DataSourceID="ServiceKindDS" DataTextField="Description" DataValueField="ServiceKindID">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="ServiceKindDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ServiceKindID], [Description] FROM [ServiceKinds]"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorServiceKind" runat="server" ControlToValidate="listServiceKind"
                            CssClass="field-validation-error text-danger" ErrorMessage="Especifique o tipo de serviço." />
                        </p>

                        <p>
                        <asp:Label ID="lblClinic" runat="server" Text="Clínica responsável: "></asp:Label>
                        <asp:DropDownList ID="listClinic" class="form-control"  runat="server" DataSourceID="ClinicDS" DataTextField="Name" DataValueField="ClinicID">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="ClinicDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ClinicID], [Name] FROM [Clinics]"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorClinic" runat="server" ControlToValidate="listClinic"
                            CssClass="field-validation-error text-danger" ErrorMessage="Especifique a clínica responsável." />
                        </p>

                    </div>
                </div>
            </div>

        </div>


        <div class="row">

            <div class="col-lg-12">
                <!--Filtro -->
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Relatório</h3>
                    </div>
                    <div class="panel-body">

                        <p>
                        <asp:Label ID="lblObs" runat="server" Text="Observações: "></asp:Label>
                        <asp:TextBox ID="boxObs" runat="server" class="form-control" MaxLength="150" Height="200" Wrap="true" TextMode="MultiLine"></asp:TextBox>
                        </p>

                    </div>
                </div>
            </div>

        </div>

        <div class="row">

            <div class="col-lg-12">
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Feedback</h3>
                    </div>

                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th></th>
                                <th>#</th>
                                <th>Início</th>
                                <th>Fim</th>
                                <th>Registo do <asp:Label ID="lblFeedback" runat="server" Text="Proprietário"/></th>
                                <th>Comentário</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="tblDiary" runat="server">
                                <ItemTemplate>
                                <tr>
                                    <td>
                                        <a class="btn btn-warning btn-xs" href="PageDoctorDiaryEdit.aspx?AnimalDiaryID=<%# Eval("AnimalDiaryID")%>" role="button"><span class="glyphicon glyphicon-comment"></span> comentar</a>
                                    </td>
                                    <td><%# Eval("AnimalDiaryID") %></td>
                                    <td><%# Eval("DateDiaryStart") %></td>
                                    <td><%# Eval("DateDiaryEnd") %></td>
                                    <td><%# Eval("Observation") %></td>
                                    <td><%# Eval("Comment") %></td>
                                </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

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
                                <asp:Button ID="btnFinish" CssClass="btn btn-warning" runat="server" Text="Gravar e concluír serviço" OnClick="btnFinish_Click"></asp:Button>
                                <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancelar" PostBackUrl="PageDoctorDashboard.aspx" CausesValidation="false"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
      </div>

</asp:Content>
