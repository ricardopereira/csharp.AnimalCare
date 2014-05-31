<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/MasterPageAdmin.Master" CodeBehind="PageAdminRaces.aspx.cs" Inherits="AnimalCare.Admin.PageAdminRaces" %>
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
                <h2>Raças</h2>
                <span class="label label-danger">Modo manutenção</span>
                <br />
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Raças</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-8">
                            <strong>Gerir</strong><br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AnimalRaceID" DataSourceID="Raças" AllowSorting="True">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="AnimalRaceID" HeaderText="AnimalRaceID" InsertVisible="False" ReadOnly="True" SortExpression="AnimalRaceID" />
                                    <asp:BoundField DataField="AnimalSpecieID" HeaderText="AnimalSpecieID" SortExpression="AnimalSpecieID" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                    <asp:BoundField DataField="AspecName" HeaderText="SpecieDesc" SortExpression="SpecieDesc" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Raças" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [AnimalRaces] WHERE [AnimalRaceID] = @AnimalRaceID" SelectCommand="SELECT a.*, aspec.Name as AspecName FROM [AnimalRaces] a INNER JOIN AnimalSpecies aspec ON aspec.AnimalSpecieID = a.AnimalSpecieID" UpdateCommand="UPDATE [AnimalRaces] SET [AnimalSpecieID] = @AnimalSpecieID, [Name] = @Name WHERE [AnimalRaceID] = @AnimalRaceID">
                                <DeleteParameters>
                                    <asp:Parameter Name="AnimalRaceID" Type="Int32" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="AnimalSpecieID" Type="Int32" />
                                    <asp:Parameter Name="Name" Type="String" />
                                    <asp:Parameter Name="AnimalRaceID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <br />
                        </div>
                        <div class="col-md-4">
                            <strong>Inserir</strong><br />
                            <p>Espécie:<asp:DropDownList CssClass="form-control" ID="ddlSpecies" runat="server" DataSourceID="Species" DataTextField="Name" DataValueField="AnimalSpecieID"></asp:DropDownList></p>
                            <p>Nome:<asp:TextBox CssClass="form-control" ID="boxSpecieName" runat="server"></asp:TextBox></p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="boxSpecieName"
                            CssClass="label label-danger" ErrorMessage="Especifique a raça." />
                            <asp:SqlDataSource ID="Species" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalSpecies]"></asp:SqlDataSource>
                            <p><asp:Button ID="btnInsert" CssClass="btn btn-primary" runat="server" text="Inserir" OnClick="insert" /></p>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>