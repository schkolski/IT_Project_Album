<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IT_Proekt.HomePage" %>


<%@ Register TagPrefix="offer" TagName="offer" Src="offer.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Дома</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/homePage.css" rel="stylesheet" />
    <style>
        #strani li {
            display: inline;
        }

        .pageNav {
            margin: 30px 0 0 0;
            padding: 30px 20px;
            clear: both;
            font-size: 24px;
            font-weight: bold;
            overflow: hidden;
            color: #d9d9d9;
        }

        .page-numbers {
            padding: 0 10px;
            height: 46px;
            line-height: 46px;
            cursor: pointer;
            display: block;
            float: left;
            margin: 0;
            color: #d9d9d9;
            text-align: center;
            text-decoration: none;
        }
    </style>
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
                    <asp:LinkButton CssClass="navbar-brand" href="HomePage.aspx" runat="server" Text="ИТ Проект"></asp:LinkButton>
                </div>

                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li class="active">
                            <asp:LinkButton href="HomePage.aspx" runat="server" Text="Дома"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="Album.aspx" runat="server" Text="Албум"></asp:LinkButton></li>
                        
                        <li>
                            <asp:LinkButton href="MyOffers.aspx" runat="server" Text="Мои Понуди"></asp:LinkButton></li>
                        <li><asp:LinkButton href="Transakcii.aspx" runat="server" Text="Транскации"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="Statistiki.aspx" runat="server" Text="Статистики"></asp:LinkButton></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <asp:LinkButton href="ProfilePage.aspx" runat="server" Text="Мои Информации"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LogOut" runat="server" Text="Одлогирај се" OnClick="LogOut_Click" /></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>

        <div class="container">
            <div id="searchContainer">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="input-group">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Пребарај слики, албуми..."></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="btnSearch" runat="server" Text="Барај" CssClass="btn btn-default"></asp:Button>
                            </span>
                        </div>
                        <!-- /input-group -->
                    </div>
                </div>
            </div>

            <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
            <asp:UpdatePanel ID="primer1" runat="server">
                <ContentTemplate>
                    <asp:Repeater runat="server" ID="repeaterHomepage">
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
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
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/HomePage.js"></script>
</html>
