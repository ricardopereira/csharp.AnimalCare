<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageClientAppointments.aspx.cs" Inherits="AnimalCare.Client.PageClientAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

   <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Marcação<small> consultas</small></h1>
            </div>
        </div>
        <div class="row well span2">
            <div class="col-lg-12">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: User.Identity.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <!-- Histórico clínico -->
                <br />
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Calendário</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <p><asp:Calendar ID="calDateFrom" runat="server"></asp:Calendar></p>
                            </div>
                            <div class="col-md-8">
                                Especialidade: <asp:DropDownList runat="server" DataSourceID="TiposEspecialidadesDS" DataTextField="Description" DataValueField="AppointmentTypeID">
                                </asp:DropDownList>                            
                                <asp:SqlDataSource ID="TiposEspecialidadesDS" runat="server" ConnectionString="<%$ ConnectionStrings:AnimalCare %>" SelectCommand="SELECT * FROM [AppointmentTypes]"></asp:SqlDataSource>

                                <br /><br />
                                Animais:
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="Animais" DataTextField="Name" DataValueField="AnimalID">
                                </asp:CheckBoxList>
                                <asp:SqlDataSource ID="Animais" runat="server" ConnectionString="<%$ ConnectionStrings:AnimalCare %>" SelectCommand="SELECT [Name], [AnimalID], [OwnerLocalID] FROM [Animals] WHERE ([OwnerLocalID] = @OwnerLocalID)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="OwnerLocalID" SessionField="userId" Type="Int32" DefaultValue="1" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <br />
                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Solicitar consulta"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>
      </div>
</asp:Content>
