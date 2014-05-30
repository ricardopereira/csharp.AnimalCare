<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Client/MasterPageClient.Master" CodeBehind="PageAnimalDiaryNew.aspx.cs" Inherits="AnimalCare.Client.PageAnimalDiaryNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Anotações<small> novas</small> 
                </h1>
            </div>
                            <span class="label label-success">Modo inserção</span>
        </div>
        <div class="row well span2">
            <div class="col-lg-12">
                <!-- Animal -->
                <h4>Animal seleccionado</h4>
                <br />
                <p class="text-muted"><asp:Label runat="server" ID="lblAnimalName"></asp:Label></p>
                <p>Espécie: <asp:Label runat="server" ID="lblAnimalSpecie"></asp:Label></p>
                <p>Raça: <asp:Label runat="server" ID="lblAnimalRace"></asp:Label></p>
            </div>
        </div>
            <!-- Campos -->
            <div class="col-md-2"></div>
            <div class="col-md-8">
                                    <asp:Panel ID="pnlError" visible="false" runat="server">
                 <div class="alert alert-danger fade in">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <h4>Erro na Inserção da Anotação</h4>
                    <p>Problema com as datas. Devem ser seleccionadas ambas as datas e a data inicial não pode ser superior à final.</p>
                  </div>
                </asp:Panel>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Dados</h3>
                    </div>
                    <div class="panel-body">
                                                <p>
                                                <asp:Label ID="lblDiaryType" runat="server" Text="Tipo: "></asp:Label>
                                                <asp:DropDownList ID="ddlDiaryType" runat="server" Width="200px" DataSourceID="TiposDiarioDS" DataTextField="Description" DataValueField="AnimalDiaryTypeID"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="TiposDiarioDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalDiaryTypes]"></asp:SqlDataSource>
                                                </p>

                                                <p>
                                                <asp:Label ID="lblDateDiary" runat="server" Text="Data de: "></asp:Label>
                                                <asp:Calendar ID="calendarDateDiaryStart" runat="server"></asp:Calendar>
                                                </p>

                                                <p>
                                                <asp:Label ID="lblDateDiaryEnd" runat="server" Text="Data até: "></asp:Label>
                                                <asp:Calendar ID="calendarDateDiaryEnd" runat="server"></asp:Calendar>
                                                </p>

                                                <p>
                                                <asp:Label ID="lblDiaryValue" runat="server" Text="Valor: "></asp:Label>
                                                <asp:TextBox ID="boxDiaryValue" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="boxDiaryValue"
                                                CssClass="field-validation-error text-danger" ErrorMessage="Especifique o valor"></asp:RequiredFieldValidator>
                                                </p>

                                                <p>
                                                <asp:Label ID="lblDiaryObs" runat="server" Text="Observações: "></asp:Label>
                                                <asp:TextBox ID="boxDiaryObs" runat="server"></asp:TextBox>
                                                </p>
                                                <p>
                                                <asp:Label ID="lblUpload" Text="Anexar ficheiro:" runat="server"></asp:Label>
                                                <asp:FileUpload ID="FileUpload" runat="server" />
                                                </p>
                    </div>
            </div>

                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Inserir" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnCancel"  CausesValidation="false"  CssClass="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancel_Click"></asp:Button>
                    </div>
                </div>
            <div class="col-md-2"></div>
        </div>
</asp:Content>

