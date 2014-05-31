<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="PageAdminHabitats.aspx.cs" Inherits="AnimalCare.Admin.PageAdminHabitat" %>
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
                <h2>Habitats</h2>
                <span class="label label-danger">Modo manutenção</span>
                <br />
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Habitats</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-8">
                            <strong>Gerir</strong><br />

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AnimalHabitatID" DataSourceID="Habitats">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="AnimalHabitatID" HeaderText="AnimalHabitatID" InsertVisible="False" ReadOnly="True" SortExpression="AnimalHabitatID" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Habitats" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [AnimalHabitats] WHERE [AnimalHabitatID] = @AnimalHabitatID" InsertCommand="INSERT INTO [AnimalHabitats] ([Description]) VALUES (@Description)" SelectCommand="SELECT * FROM [AnimalHabitats]" UpdateCommand="UPDATE [AnimalHabitats] SET [Description] = @Description WHERE [AnimalHabitatID] = @AnimalHabitatID">
                                <DeleteParameters>
                                    <asp:Parameter Name="AnimalHabitatID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Description" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Description" Type="String" />
                                    <asp:Parameter Name="AnimalHabitatID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>

                            <br />
                        </div>
                        <div class="col-md-4">
                            <strong>Inserir</strong><br />
                            <p>Nome Habitat:<asp:TextBox CssClass="form-control" ID="boxHabitatName" runat="server"></asp:TextBox></p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="boxHabitatName"
                            CssClass="label label-danger" ErrorMessage="Especifique o Habitat." />
                            <p><asp:Button ID="btnInsert" CssClass="btn btn-primary" runat="server" text="Inserir" OnClick="insert" /></p>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
