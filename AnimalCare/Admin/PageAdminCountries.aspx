<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="PageAdminCountries.aspx.cs" Inherits="AnimalCare.Admin.PageAdminCountries" %>
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
                <h2>Países</h2>
                <span class="label label-danger">Modo manutenção</span>
                <br />
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Países</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-8">
                            <strong>Gerir</strong><br />

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CountryID" DataSourceID="Countries">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="CountryID" HeaderText="CountryID" InsertVisible="False" ReadOnly="True" SortExpression="CountryID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="ISO3166" HeaderText="ISO3166" SortExpression="ISO3166" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Countries" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [Countries] WHERE [CountryID] = @CountryID" InsertCommand="INSERT INTO [Countries] ([Name], [ISO3166]) VALUES (@Name, @ISO3166)" SelectCommand="SELECT * FROM [Countries]" UpdateCommand="UPDATE [Countries] SET [Name] = @Name, [ISO3166] = @ISO3166 WHERE [CountryID] = @CountryID">
                                <DeleteParameters>
                                    <asp:Parameter Name="CountryID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Name" Type="String" />
                                    <asp:Parameter Name="ISO3166" Type="Int32" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Name" Type="String" />
                                    <asp:Parameter Name="ISO3166" Type="Int32" />
                                    <asp:Parameter Name="CountryID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>

                            <br />
                        </div>
                        <div class="col-md-4">
                            <strong>Inserir</strong><br />
                            <p>Nome País:<asp:TextBox CssClass="form-control" ID="boxCountryName" runat="server"></asp:TextBox></p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="boxCountryName"
                            CssClass="label label-danger" ErrorMessage="Especifique o país." />
                            <asp:SqlDataSource ID="Species" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalSpecies]"></asp:SqlDataSource>
                            <p><asp:Button ID="btnInsert" CssClass="btn btn-primary" runat="server" text="Inserir" OnClick="insert" /></p>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

