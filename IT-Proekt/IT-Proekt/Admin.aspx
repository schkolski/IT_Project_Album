<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="IT_Proekt.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Admin-Korisnici</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/homePage.css" rel="stylesheet" />
    <script src="Scripts/jquery-ui-1.11.4/jquery-ui.js"></script>
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
                    <asp:LinkButton CssClass="navbar-brand" href="#" runat="server" Text="ИТ Проект"></asp:LinkButton>
                </div>

                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li class="active">
                            <asp:LinkButton href="Admin.aspx" runat="server" Text="Kорисници"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="Dodadi_Album.aspx" runat="server" Text="Додади Албум"></asp:LinkButton></li>
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

        <div class="container">
            <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

            <div id="Admini" class="" style="width: 70%">
                <!-- Функционира само над 768px -->
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <ul class="nav" style="margin-left: 30%; margin-top:10%; background-color:gainsboro;border-radius: 25px;">
                                <li>
                                    <div class="col-lg-6">
                                        <asp:Label ID="tbName" runat="server" Text="Пример"></asp:Label>
                                    </div>
                                </li>
                                <li>
                                    <div class="col-lg-6">
                                        <asp:Button runat="server" ID="btPromeni" Text="Промени" />
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div id="Korisnici" class="" style="width: 70%">
                <!-- Функционира само над 768px -->
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <ul class="nav" style="margin-left: 30%; margin-top:1%; background-color:gainsboro;border-radius: 25px;">
                                <li>
                                    <div class="col-lg-6">
                                        <asp:Label ID="Label1" runat="server" Text="Пример"></asp:Label>
                                    </div>
                                </li>
                                <li>
                                    <div class="col-lg-6">
                                        <asp:Button runat="server" ID="Button1" Text="Промени" />
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <asp:Repeater runat="server" ID="repeaterTransakcii">
                <ItemTemplate>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <footer class="footer">
            <div class="container">
                <p>Place sticky footer content here.</p>
            </div>
        </footer>
    </form>
</body>


<script src="Scripts/jquery-1.10.2.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/HomePage.js"></script>
</html>
