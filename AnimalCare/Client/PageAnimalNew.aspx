<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalNew.aspx.cs" Inherits="AnimalCare.Client.PageAnimalNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <br /><br />
    <!-- Cabecalho -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Animais<small> perfil</small></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <!-- Cliente -->
                <h4>Proprietário</h4>
                <p class="text-muted"><%: Ctrl.Bf.Name %> <a class="btn btn-default btn-xs" href="PageClient.aspx" role="button"><span class="glyphicon glyphicon-user"></span> Ver perfil</a></p>
                <br />
            </div>
        </div>
        <div class="row">
            <!-- Info -->
            <div class="col-md-9">
                <h2>Novo animal</h2>
                <span class="label label-success">Modo inserção</span>
                <br />
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
                        <asp:TextBox ID="boxName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="boxName"
                        CssClass="label label-danger" ErrorMessage="Especifique o nome do animal." />
                        </p>

                        <p>
                        <asp:Label ID="lblIdentity" runat="server" Text="Núm. Identidade: "></asp:Label>
                        <asp:TextBox ID="boxIdentity" runat="server" MaxLength="50"></asp:TextBox>
                        </p>

                        <p>                        
                        <asp:Label ID="lblSex" runat="server" Text="Sexo: "></asp:Label>
                        <asp:DropDownList ID="ddlSex" runat="server">
                            <asp:ListItem Value="1">Masculino</asp:ListItem>
                            <asp:ListItem Value="2">Feminino</asp:ListItem>
                        </asp:DropDownList>
                        </p>

                        <p>                        
                        <asp:Label ID="lblGroup" runat="server" Text="Grupo: "></asp:Label>
                        <asp:CheckBox ID="chkGroup" runat="server" OnCheckedChanged="chkGroup_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                        <asp:Label ID="lblNGroup" Text="Número de Animais:" runat="server" Visible="False"></asp:Label>
                        <asp:TextBox ID="boxNumberAnimals" runat="server" Visible="False" Width="36px"></asp:TextBox>
                        <asp:RegularExpressionValidator CssClass="label label-danger" ID="RegularExpressionValidator1" ValidationExpression="\d+" runat="server" ControlToValidate="boxNumberAnimals" ErrorMessage="Valor numérico inteiro" Display="Dynamic"></asp:RegularExpressionValidator>
                        </p>

                        <p>
                            <asp:Label ID="lblLocals" runat="server" Text="Locais: "></asp:Label>                        
                            <asp:DropDownList ID="ddlLocals" runat="server">
                            </asp:DropDownList>
                        </p>

                        <p>
                            <asp:Label ID="lblSpecies" runat="server" Text="Espécie: "></asp:Label>                        
                            <asp:DropDownList ID="ddlSpecies" runat="server" DataSourceID="Species" DataTextField="Name" DataValueField="AnimalSpecieID" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="Species" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [AnimalSpecieID], [Name] FROM [AnimalSpecies]"></asp:SqlDataSource>
                        </p>

                        <p>
                            <asp:Label ID="lblRaces" runat="server" Text="Raça: "></asp:Label>                        
                            <asp:DropDownList ID="ddlRaces" runat="server" DataSourceID="Races" DataTextField="Name" DataValueField="AnimalRaceID"></asp:DropDownList>
                            <asp:SqlDataSource ID="Races" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalRaces] WHERE ([AnimalSpecieID] = @AnimalSpecieID)">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlSpecies" Name="AnimalSpecieID" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </p>

                        <p>
                            <asp:Label ID="lblHabitat" runat="server" Text="Habitat: "></asp:Label>                        
                            <asp:DropDownList ID="ddlHabitat" runat="server" DataSourceID="Habitat" DataTextField="Description" DataValueField="AnimalHabitatID">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="Habitat" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalHabitats]"></asp:SqlDataSource>
                        </p>

                        <p>
                            <asp:Label ID="lblCondition" runat="server" Text="Condição: "></asp:Label>                        

                            <asp:DropDownList ID="ddlCondition" runat="server" DataSourceID="Condition" DataTextField="Description" DataValueField="AnimalConditionID">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="Condition" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [AnimalConditions]"></asp:SqlDataSource>

                        </p>
                    </div>
                </div>
                <!-- Painel com Calendário Datas -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Datas</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                        <div class="col-md-6">
                            <strong>Data Nascimento:</strong><br /><br />
                            <asp:Calendar ID="CalendarBirth" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="16px" NextPrevFormat="FullMonth" Width="237px">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                        </div>
                        </div>
                    </div>
                </div>
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Inserir Animal" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancel_Click"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
</asp:Content>

