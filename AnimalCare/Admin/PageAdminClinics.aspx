<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="PageAdminClinics.aspx.cs" Inherits="AnimalCare.Admin.PageAdminClinics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Administração<small> gestão</small></h1>
            </div>
        </div>
        <div class="row">
            <!-- Info -->
            <div class="col-md-9">
                <h2>Clinicas</h2>
                <span class="label label-danger">Modo manutenção</span>
                <br />
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Clinicas</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                            <strong>Gerir</strong><br /><br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ClinicID" DataSourceID="Clinics">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="ClinicID" HeaderText="ClinicID" InsertVisible="False" ReadOnly="True" SortExpression="ClinicID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="KinD" HeaderText="KinD" SortExpression="KinD" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                    <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
                                    <asp:BoundField DataField="GPS" HeaderText="GPS" SortExpression="GPS" />
                                    <asp:BoundField DataField="CityID" HeaderText="CityID" SortExpression="CityID" />
                                    <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                                    <asp:BoundField DataField="FaxNumber" HeaderText="FaxNumber" SortExpression="FaxNumber" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Clinics" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Clinics] WHERE [ClinicID] = @ClinicID" InsertCommand="INSERT INTO [Clinics] ([Name], [KinD], [Address], [ZipCode], [GPS], [CityID], [PhoneNumber], [FaxNumber], [Email]) VALUES (@Name, @KinD, @Address, @ZipCode, @GPS, @CityID, @PhoneNumber, @FaxNumber, @Email)" SelectCommand="SELECT * FROM [Clinics]" UpdateCommand="UPDATE [Clinics] SET [Name] = @Name, [KinD] = @KinD, [Address] = @Address, [ZipCode] = @ZipCode, [GPS] = @GPS, [CityID] = @CityID, [PhoneNumber] = @PhoneNumber, [FaxNumber] = @FaxNumber, [Email] = @Email WHERE [ClinicID] = @ClinicID">
                                <DeleteParameters>
                                    <asp:Parameter Name="ClinicID" Type="Int32" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Name" Type="String" />
                                    <asp:Parameter Name="KinD" Type="Int16" />
                                    <asp:Parameter Name="Address" Type="String" />
                                    <asp:Parameter Name="ZipCode" Type="String" />
                                    <asp:Parameter Name="GPS" Type="String" />
                                    <asp:Parameter Name="CityID" Type="Int32" />
                                    <asp:Parameter Name="PhoneNumber" Type="String" />
                                    <asp:Parameter Name="FaxNumber" Type="String" />
                                    <asp:Parameter Name="Email" Type="String" />
                                    <asp:Parameter Name="ClinicID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <br />
                        </div>
                            </div>
                    </div>
                 </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Clinicas</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <strong>Adicionar</strong><br /><br />
                                    <p>Nome:<asp:TextBox CssClass="form-control" ID="boxName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="boxName"
                                    CssClass="label label-danger" ErrorMessage="Especifique o nome" /></p>
                                    <p>Tipo:<asp:TextBox CssClass="form-control" ID="boxKind" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="boxKind"
                                    CssClass="label label-danger" ErrorMessage="Especifique o Tipo" />
                                    <asp:RegularExpressionValidator CssClass="label label-danger" ID="RegularExpressionValidator1" ValidationExpression="\d+" runat="server" ControlToValidate="boxKind" ErrorMessage="Valor numérico inteiro" Display="Dynamic"></asp:RegularExpressionValidator></p>
                                    <p>Morada:<asp:TextBox CssClass="form-control" ID="boxAddress" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="boxAddress"
                                    CssClass="label label-danger" ErrorMessage="Especifique o Tipo" /></p>
                                    <p>Código Postal:<asp:TextBox CssClass="form-control" ID="boxZipCode" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="boxZipCode"
                                    CssClass="label label-danger" ErrorMessage="Especifique o Cód Postal" /></p>
                                    <p>GPS:<asp:TextBox CssClass="form-control" ID="boxGPS" runat="server"></asp:TextBox></p>
                                    <p>Cidade:<asp:DropDownList CssClass="form-control" ID="ddlCities" runat="server" DataSourceID="Cities" DataTextField="Name" DataValueField="CityID"></asp:DropDownList>
                                        <asp:SqlDataSource ID="Cities" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Cities]"></asp:SqlDataSource>
                                    </p>
                                    <p>Telefone:<asp:TextBox CssClass="form-control" ID="boxPhone" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="boxPhone"
                                    CssClass="label label-danger" ErrorMessage="Especifique o Telefone" /></p>
                                    <p>Fax:<asp:TextBox CssClass="form-control" ID="boxFax" runat="server"></asp:TextBox></p>
                                    <p>Mail:<asp:TextBox CssClass="form-control" ID="boxMail" runat="server"></asp:TextBox></p>
                            <p><asp:Button ID="btnInsert" CssClass="btn btn-primary" runat="server" text="Inserir" OnClick="insert" /></p>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
</asp:Content>
