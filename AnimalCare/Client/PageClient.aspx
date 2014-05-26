<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageClient.aspx.cs" Inherits="AnimalCare.PageOwner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cliente<small> perfil</small></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <img data-src="holder.js/200x200" class="img-thumbnail" alt="200x200" src="data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIyMDAiIGhlaWdodD0iMjAwIj48cmVjdCB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgZmlsbD0iI2VlZSI+PC9yZWN0Pjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIHg9IjEwMCIgeT0iMTAwIiBzdHlsZT0iZmlsbDojYWFhO2ZvbnQtd2VpZ2h0OmJvbGQ7Zm9udC1zaXplOjEzcHg7Zm9udC1mYW1pbHk6QXJpYWwsSGVsdmV0aWNhLHNhbnMtc2VyaWY7ZG9taW5hbnQtYmFzZWxpbmU6Y2VudHJhbCI+MjAweDIwMDwvdGV4dD48L3N2Zz4=" style="width: 200px; height: 200px;">
            </div>
            <div class="col-md-9">
                <h2><%: User.Identity.Name %></h2>
                <a class="btn btn-default btn-sm" href="PageClientEdit.aspx" role="button"><span class="glyphicon glyphicon-pencil"></span> Editar</a>
                <br />
                <br />
                <br />
                <p>Nome: <asp:Literal runat="server" ID="clientName"></asp:Literal></p>
                <p>Email: <asp:Literal runat="server" ID="clientEmail"></asp:Literal></p>
                <p>País: <asp:Literal runat="server" ID="clientCountry"></asp:Literal></p>
                <p>Telefone: <asp:Literal runat="server" ID="clientPhoneNumber"></asp:Literal></p>
            </div>
        </div>
    </div>

</asp:Content>