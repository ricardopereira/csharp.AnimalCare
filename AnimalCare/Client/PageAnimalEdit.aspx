<%@ Page Title="" Language="C#" MasterPageFile="~/Client/MasterPageClient.Master" AutoEventWireup="true" CodeBehind="PageAnimalEdit.aspx.cs" Inherits="AnimalCare.Client.PageAnimalEdit" %>
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
            <!-- Avatar -->
            <div class="col-md-3">
                <img runat="server" id="animalImage" data-src="holder.js/200x200" class="img-thumbnail" alt="animal image" style="width: 200px; height: 200px;">
            </div>
            <!-- Info -->
            <div class="col-md-9">
                <h2><asp:Label ID="animalName" runat="server"></asp:Label></h2>
                <span class="label label-danger">Modo edição</span>
                <br />
            </div>
        </div>

        <div class="row">
            <br /><br />
            <!-- Campos -->
            <div class="col-md-2"></div>
            <div class="col-md-8">

                <div class="panel panel-default">
                    <asp:Panel ID="pnlErrorDate" runat="server" Visible="false">
                        <div class="alert alert-danger fade in">
                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                            <h4>Erro com as datas</h4>
                            <asp:Label ID="firstMsg" runat="server" Visible="false"><p>Ao especificar a data de falecimento, deve especificar também a de nascimento.</p></asp:Label>
                            <asp:Label ID="secondMsg" runat="server" Visible="false"><p>A data de nascimento não pode ser superior à de falecimento.</p></asp:Label>
                         </div>
                    </asp:Panel>
                    <div class="panel-heading">
                        <h3 class="panel-title">Dados</h3>
                    </div>
                    <div class="panel-body">
                        <p>
                        <asp:Label ID="lblName" runat="server" Text="Nome: "></asp:Label>
                        <asp:TextBox ID="boxName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="boxName"
                        CssClass="field-validation-error text-danger" ErrorMessage="Especifique o nome do animal." />
                        </p>

                        <p>                        
                            <asp:Label ID="Label1" runat="server" Text="Local: "></asp:Label>
                            <asp:DropDownList ID="ddlLocals" runat="server">
                        </asp:DropDownList>
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
                        </p>

                        <p>
                            <asp:Label ID="lblSpecies" runat="server" Text="Espécie: "></asp:Label>                        
                            <asp:DropDownList ID="ddlSpecies" runat="server" DataSourceID="Species" DataTextField="Name" DataValueField="AnimalSpecieID" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecies_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="Species" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [AnimalSpecieID], [Name] FROM [AnimalSpecies]"></asp:SqlDataSource>
                        </p>

                        <p>
                            <asp:Label ID="lblRaces" runat="server" Text="Raça: "></asp:Label>                        
                            <asp:DropDownList ID="ddlRaces" runat="server"></asp:DropDownList>
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
                        <div class="col-md-6">
                            <strong>Data Falecimento:</strong><br />
                            <asp:Label ID="lblDecease" runat="server" Text="Faleceu: "></asp:Label>                        
                            <asp:CheckBox ID="chkDeceased" runat="server" OnCheckedChanged="chkDeceased_CheckedChanged" AutoPostBack="true" />
                            <asp:Calendar ID="CalendarDeath" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="16px" NextPrevFormat="FullMonth" Width="237px" Visible="False">
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
                <!-- Relativos a imagem do animal -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Imagem do Animal</h3>
                    </div>
                    <div class="panel-body">
                        <asp:FileUpload ID="FileUpload" runat="server" />
                        <br />
                        <asp:Button ID="btnUpload" CssClass="btn btn-sm btn-default" runat="server" Text="Carregar Foto Animal" OnClick="btnUpload_Click"></asp:Button>
                        <asp:Literal ID="uploadMessage" runat="server"></asp:Literal>
                    </div>
                </div>
                <!-- Painel com Botões -->
                <div class="panel panel-default">
                    <div class="panel-body">
                        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Gravar" OnClick="btnSave_Click"></asp:Button>
                        <asp:Button ID="btnCancel" CausesValidation="false" CssClass="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancel_Click"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>

</asp:Content>
