﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalDiary.aspx.cs" Inherits="AnimalCare.Client.PageAnimalDiary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> diário</small></h1>
            </div>
        </div>
        <div class="row well span2">
            <div class="col-lg-12">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx?" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
                <!-- Animal -->
                <h4>Animal seleccionado</h4>
                <p class="text-muted"><asp:Label runat="server" ID="lblAnimalName"></asp:Label></p>
                <p>Espécie: <asp:Label runat="server" ID="lblAnimalSpecie"></asp:Label></p>
                <p>Raça: <asp:Label runat="server" ID="lblAnimalRace"></asp:Label></p>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                        <!-- Mensagem Erro -->
                        <asp:Panel ID="pnlError" runat="server" Visible="false">
                            <div class="alert alert-danger fade in">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                <h4>Erro nas datas</h4>
                                <p>A data inicial não pode ser superior à inferior.</p>
                            </div>
                        </asp:Panel>
                <!-- Diário -->
                <br />
                <!--Filtro -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Filtro</h3>
                    </div>
                    <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblDateStart" runat="server" Text="Data Inicial: "></asp:Label><br /><br />
                                    <asp:Calendar ID="calendarDateStart" runat="server"></asp:Calendar>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblDateEnd" runat="server" Text="Data Final: "></asp:Label><br /><br />
                                    <asp:Calendar ID="calendarDateEnd" runat="server"></asp:Calendar>
                                </div>
                            </div>
                        <br />
                        <div class ="row">
                            <div class="col-md-4">
                                <asp:Label ID="lblType" runat="server" Text="Tipo: "></asp:Label><br />
                                <asp:CheckBox ID="chkType" runat="server" />  
                                <asp:DropDownList ID="ddlListType" CssClass="form-control" runat="server" Width="200px" DataSourceID="TiposDS" DataTextField="Description" DataValueField="AnimalDiaryTypeID"></asp:DropDownList>
                                    <asp:SqlDataSource ID="TiposDS" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalDiaryTypes]"></asp:SqlDataSource>
                            </div>
                            <div class="col-md-6">
                                <br /><br />
                                <asp:Button ID="btnFind" runat="server" CssClass="btn btn-primary" Text="Pesquisar" OnClick="btnFind_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Tabela com os animais -->
                <div class="table-responsive">
                    <div class="panel panel-default">
                        <!-- Default panel contents -->
                        <div class="panel-heading">Dados</div>
                        <div class="panel-body">
                            <!-- Conteudo para o painel: Talvez colocar os botões -->
                            <p class="text-muted">Opções da grelha</p>
                            <div class="btn-toolbar" role="toolbar">
                                <div class="btn-group">
                                    <!-- Novo registo -->
                                    <a class="btn btn-success" id="reg" runat="server">Novo registo</a>
                                </div>
                            </div>
                        </div>

                        <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>#</th>
                                    <th>Data Inicio</th>
                                    <th>Data Fim</th>
                                    <th>Tipo</th>
                                    <th>Valor</th>
                                    <th>Obs</th>
                                </tr>
                            </thead>
                            <tbody>
                               <asp:Repeater ID="tblDiary" runat="server">
                                    <ItemTemplate>
                                    <tr>
                                    <td>
                                        <!-- Opcoes de linha -->
                                        <a class="btn btn-primary btn-xs" href="PageAnimalDiaryItem.aspx?DiaryItem=<%# Eval("AnimalDiaryID") %>" role="button"><span class="glyphicon glyphicon-info-sign"></span></a>
                                    </td>
                                        <td><%# Eval("AnimalDiaryID") %></td>
                                        <td><%# Eval("DateDiaryStart") %></td>
                                        <td><%# Eval("DateDiaryEnd") %></td>
                                        <td><%# Eval("Description") %></td>
                                        <td><%# Eval("Value") %></td>
                                        <td><%# Eval("Observation") %></td>
                                    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>
    </div>


</asp:Content>
