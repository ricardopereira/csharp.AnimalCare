<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Doctor/MasterPageDoctor.Master" CodeBehind="PageDoctorEdit.aspx.cs" Inherits="AnimalCare.Doctor.PageDoctorEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Profissional de Saúde<small> perfil</small></h1>
            </div>
        </div>
        <div class="row">
            <!-- Avatar -->
            <div class="col-md-3">
                <img id="profileImage" runat="server" data-src="holder.js/200x200" class="img-thumbnail" alt="200x200" style="width: 200px; height: 200px;">
            </div>
            <!-- Info -->
            <div class="col-md-9">
                <h2><%: Ctrl.Bf.Name %></h2>
                <span class="label label-danger">Modo edição</span>
            </div>
        </div>
        <div class="row">
            <br /><br />
            <!-- Campos -->
            <div class="col-md-2"></div>
            <div class="col-md-8">

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Dados</h3>
                    </div>
                    <div class="panel-body">
                        <p>
                        <asp:Label ID="lblName" runat="server" Text="Nome: "></asp:Label>
                        <asp:TextBox ID="boxName" runat="server" MaxLength="45"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="boxName"
                        CssClass="field-validation-error text-danger" ErrorMessage="Especifique o utilizador." />
                        </p>

                        <p>
                        <asp:Label ID="lblCodeWorker" runat="server" Text="Cédula: "></asp:Label>
                        <asp:TextBox ID="boxCodeWorker" runat="server" MaxLength="15"></asp:TextBox>
                        </p>

                        <p>
                        <asp:Label ID="lblWorkNumber" runat="server" Text="Número Tel. Trabalho: "></asp:Label>
                        <asp:TextBox ID="boxWorkNumber" runat="server" MaxLength="45"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="boxWorkNumber"
                        CssClass="field-validation-error text-danger" ErrorMessage="Especifique o Núm. Tel. Trabalho" />
                        </p>

                        <p>
                        <asp:Label ID="lblPersonalNumber" runat="server" Text="Número Tel. Pessoal: "></asp:Label>
                        <asp:TextBox ID="boxPersonalNumber" runat="server" MaxLength="15"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="boxPersonalNumber"
                        CssClass="field-validation-error text-danger" ErrorMessage="Especifique o Núm. Pessoal" />
                        </p>
                    </div>
                </div>
                <!-- Relativos a imagem perfil -->
                <asp:Panel ID="uploadImage" runat="server" Visible="false">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Imagem de Perfil</h3>
                    </div>
                        <div class="panel-body">
                            <asp:FileUpload ID="FileUpload" runat="server" />
                            <br />
                            <asp:Button ID="btnUpload" CssClass="btn btn-sm btn-default" runat="server" Text="Carregar Foto" OnClick="btnUpload_Click"></asp:Button>
                            <asp:Literal ID="uploadMessage" runat="server"></asp:Literal>
                        </div>
                </div>
                </asp:Panel>

                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Gravar" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancel_Click"></asp:Button>
                    </div>
                </div>
            <div class="col-md-2"></div>
        </div>
    </div>
</asp:Content>
