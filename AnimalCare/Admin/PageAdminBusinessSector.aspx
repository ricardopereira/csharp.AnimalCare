<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="PageAdminBusinessSector.aspx.cs" Inherits="AnimalCare.Admin.PageAdminBusinessSector" %>

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
                <h2>Sector de Negócio</h2>
                <span class="label label-danger">Modo manutenção</span>
                <br />
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Sector de Negócio</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-8">
                            <strong>Gerir</strong><br />

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="BusinessSectorID" DataSourceID="BizSector">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="BusinessSectorID" HeaderText="BusinessSectorID" InsertVisible="False" ReadOnly="True" SortExpression="BusinessSectorID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="BizSector" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [BusinessSector] WHERE [BusinessSectorID] = @BusinessSectorID" InsertCommand="INSERT INTO [BusinessSector] ([Name]) VALUES (@Name)" SelectCommand="SELECT * FROM [BusinessSector]" UpdateCommand="UPDATE [BusinessSector] SET [Name] = @Name WHERE [BusinessSectorID] = @BusinessSectorID">
                                <DeleteParameters>
                                    <asp:Parameter Name="BusinessSectorID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Name" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Name" Type="String" />
                                    <asp:Parameter Name="BusinessSectorID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>

                            <br />
                        </div>
                        <div class="col-md-4">
                            <strong>Inserir</strong><br />
                            <p>Sector de Negócio:<asp:TextBox CssClass="form-control" ID="boxBusinessSector" runat="server"></asp:TextBox></p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="boxBusinessSector"
                            CssClass="label label-danger" ErrorMessage="Especifique o Sector de Negócio." />
                            <p><asp:Button ID="btnInsert" CssClass="btn btn-primary" runat="server" text="Inserir" OnClick="insert" /></p>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>