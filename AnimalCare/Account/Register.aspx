<%@ Page Title="Register" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AnimalCare.Account.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <ul class="nav navbar-nav">
                <div class="navbar-header">
                    <a class="navbar-brand" href="/">AnimalCare</a>
                </div>
            </ul>
            <asp:Panel ID="pnlLogin" runat="server">
                <ul class="nav navbar-nav navbar-right">
                    <li><a id="registerLink" href="Login.aspx">Iniciar Sessão</a></li>
                </ul>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="position: absolute; margin-top: 7.5em;" class="container">
        <div class="form-signin text-center" role="form">    
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
        <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
                <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                    </p>

                    <fieldset>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">Username</asp:Label>
                        <asp:TextBox class="form-control" runat="server" ID="UserName" />
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="Email">Email address</asp:Label>
                        <asp:TextBox class="form-control" runat="server" ID="Email" />
                        <asp:Label ID="Label3" runat="server" AssociatedControlID="Password">Password</asp:Label>
                        <asp:TextBox class="form-control" runat="server" ID="Password" TextMode="Password" />
                        <asp:Label ID="Label4" runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                        <asp:TextBox class="form-control" runat="server" ID="ConfirmPassword" TextMode="Password" />
                        <asp:Button ID="Button1" runat="server"  class="btn btn-primary btn-lg btn-block" CommandName="MoveNext" Text="Register" />
                        <p class="validation-summary-errors">
                            <asp:Literal runat="server" ID="ErrorMessage" />
                        </p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="The email address field is required." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="The password field is required." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />

                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    </div>
    </div>
</asp:Content>