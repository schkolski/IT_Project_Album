<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transakcii.aspx.cs" Inherits="IT_Proekt.Transakcii" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Трансакции</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/homePage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <asp:LinkButton  href="HomePage.aspx" CssClass="navbar-brand" runat="server" Text="ИТ Проект"></asp:LinkButton>
                </div>

                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li>
                            <asp:LinkButton href="HomePage.aspx" runat="server" Text="Дома"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="Album.aspx" runat="server" Text="Албум"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="MyOffers.aspx" runat="server" Text="Мои Понуди"></asp:LinkButton></li>
                        <li class="active">
                            <asp:LinkButton href="Transakcii.aspx" runat="server" Text="Транскации"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="Statistiki.aspx" runat="server" Text="Статистики"></asp:LinkButton></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <asp:LinkButton href="ProfilePage.aspx" runat="server" Text="Мои Информации"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton runat="server" Text="Одлогирај се" ID="LogOut" OnClick="LogOut_Click"></asp:LinkButton></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>
        <!-- end navbar -->

        <div class="container">
            <div id="transakciiButtonsContainer" class="container">
                <!-- funkcionira do 500px -->
                <div class="row">
                    <div class="col-sm-8 col-sm-offset-2">
                        <div class="row">
                            <ul class="nav nav-tabs">
                                <li id="liTabKupuvam" runat="server" role="presentation" class="active">
                                    <asp:LinkButton runat="server" ID="btnTabKupuvam" Text="Купувам" OnClick="btnTabKupuvam_Click"></asp:LinkButton></li>
                                <li id="liTabProdavam" runat="server" role="presentation">
                                    <asp:LinkButton runat="server" ID="btnTabProdavam" Text="Продавам" OnClick="btnTabProdavam_Click"></asp:LinkButton></li>
                                <li id="liTabIstorija" runat="server" role="presentation">
                                    <asp:LinkButton runat="server" ID="btnTabIstorija" Text="Историја" OnClick="btnTabIstorija_Click"></asp:LinkButton></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

            <asp:UpdatePanel runat="server" ID="pnlErrorInput" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="errorInputContainer">
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Label runat="server" ID="lblErrorInput" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            

            <asp:UpdatePanel runat="server" ID="upInfo">
                <ContentTemplate>
                    <asp:Repeater runat="server" ID="repeaterTransakcii">
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>

        </div>

        <footer class="footer">
            <div class="container">
                <p>Place sticky footer content here.</p>
            </div>
        </footer>


    </form>
</body>


<script src="Scripts/jquery-1.10.2.min.js"></script>
<script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/HomePage.js"></script>
</html>
