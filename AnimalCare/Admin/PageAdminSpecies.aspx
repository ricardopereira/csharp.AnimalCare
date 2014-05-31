<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="PageAdminSpecies.aspx.cs" Inherits="AnimalCare.Admin.PageAdminSpecies" %>
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
                <h2>Espécies</h2>
                <span class="label label-danger">Modo manutenção</span>
                <br />
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Espécies</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-8">
                            <strong>Gerir</strong><br />

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AnimalSpecieID" DataSourceID="Species">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="AnimalSpecieID" HeaderText="AnimalSpecieID" InsertVisible="False" ReadOnly="True" SortExpression="AnimalSpecieID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Species" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [AnimalSpecies] WHERE [AnimalSpecieID] = @AnimalSpecieID" InsertCommand="INSERT INTO [AnimalSpecies] ([Name]) VALUES (@Name)" SelectCommand="SELECT * FROM [AnimalSpecies]" UpdateCommand="UPDATE [AnimalSpecies] SET [Name] = @Name WHERE [AnimalSpecieID] = @AnimalSpecieID">
                                <DeleteParameters>
                                    <asp:Parameter Name="AnimalSpecieID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Name" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Name" Type="String" />
                                    <asp:Parameter Name="AnimalSpecieID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>

                            <br />
                        </div>
                        <div class="col-md-4">
                            <strong>Inserir</strong><br />
                            <p>Nome Espécie:<asp:TextBox CssClass="form-control" ID="boxSpecieName" runat="server"></asp:TextBox></p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="boxSpecieName"
                            CssClass="label label-danger" ErrorMessage="Especifique a Espécie." />
                            <p><asp:Button ID="btnInsert" CssClass="btn btn-primary" runat="server" text="Inserir" OnClick="insert" /></p>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>