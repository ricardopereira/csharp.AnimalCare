<%@ Page Language="C#" MasterPageFile="~/Admin/MasterPageAdmin.Master" AutoEventWireup="true" CodeBehind="PageAdminAnimalDiaryType.aspx.cs" Inherits="AnimalCare.Admin.PageAdminAnimalDiaryType" %>
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
                <h2>Tipo de Leitura</h2>
                <span class="label label-danger">Modo manutenção</span>
                <br />
            </div>
        </div>
        <div class="row">
            <br /><br />
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Tipo de Leitura</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-8">
                            <strong>Gerir</strong><br />

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="AnimalDiaryTypeID" DataSourceID="DiaryTypes">
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                    <asp:BoundField DataField="AnimalDiaryTypeID" HeaderText="AnimalDiaryTypeID" InsertVisible="False" ReadOnly="True" SortExpression="AnimalDiaryTypeID" />
                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="DiaryTypes" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [AnimalDiaryTypes] WHERE [AnimalDiaryTypeID] = @AnimalDiaryTypeID" InsertCommand="INSERT INTO [AnimalDiaryTypes] ([Description]) VALUES (@Description)" SelectCommand="SELECT * FROM [AnimalDiaryTypes]" UpdateCommand="UPDATE [AnimalDiaryTypes] SET [Description] = @Description WHERE [AnimalDiaryTypeID] = @AnimalDiaryTypeID">
                                <DeleteParameters>
                                    <asp:Parameter Name="AnimalDiaryTypeID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Description" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Description" Type="String" />
                                    <asp:Parameter Name="AnimalDiaryTypeID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>

                            <br />
                        </div>
                        <div class="col-md-4">
                            <strong>Inserir</strong><br />
                            <p>Tipo de Leitura:<asp:TextBox CssClass="form-control" ID="boxDiaryType" runat="server"></asp:TextBox></p>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="boxDiaryType"
                            CssClass="label label-danger" ErrorMessage="Especifique o Tipo de Leitura." />
                            <p><asp:Button ID="btnInsert" CssClass="btn btn-primary" runat="server" text="Inserir" OnClick="insert" /></p>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
