<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IT_Proekt.HomePage" %>


<%@ Register TagPrefix="offer" TagName="offer" Src="offer.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
    
        <title>Home Page</title>
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <link href="Content/homePage.css" rel="stylesheet" />
        <style>
            #strani li{
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

            .page-numbers
            {
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
                        <asp:LinkButton CssClass="navbar-brand" href="#" runat="server" Text="ИТ Проект"></asp:LinkButton>
                    </div>

                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li class="active"><asp:LinkButton href="#Doma" runat="server" Text="Дома"></asp:LinkButton></li>
                            <li><asp:LinkButton href="#Album" runat="server" Text="Албум"></asp:LinkButton></li>
                            <li><asp:LinkButton href="#MyOffers" runat="server" Text="Мои Понуди"></asp:LinkButton></li>                                 
                            <li><asp:LinkButton href="#Stats" runat="server" Text="Статистики"></asp:LinkButton></li>           
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li><asp:LinkButton href="#MyInfo" runat="server" Text="Мои Информации"></asp:LinkButton></li>
                            <li><asp:LinkButton ID="LogOut" runat="server" Text="Одлогирај се" OnClick="LogOut_Click"/></li>
                        </ul>
                    </div><!--/.nav-collapse -->
                </div>
            </nav>

            <div class="container">
                <div id="searchContainer">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="input-group">
                                <asp:TextBox id="txtSearch" runat="server" CssClass="form-control" placeholder="Пребарај слики, албуми..."></asp:TextBox>
                                <span class="input-group-btn">
                                <asp:Button ID="btnSearch" runat="server" Text="Барај" CssClass="btn btn-default"></asp:Button>
                                </span>
                            </div><!-- /input-group -->
                        </div>
                        <div class="col-md-1 hidden-sm hidden-xs">
                            <asp:CheckBox ID="chkbID" runat="server" Text=" ID"/>
                        </div>
                        <div class="col-md-1 hidden-sm hidden-xs">
                            <asp:CheckBox ID="chkbName" runat="server" Text=" Име"/>
                        </div>
                        <div class="col-md-2 hidden-sm hidden-xs">
                            <asp:CheckBox ID="chkbAlbum" runat="server" Text=" Албум"/>
                        </div>
                        <div class="col-md-3 col-lg-2 col-md-offset-5 col-lg-offset-6">
                            <button ID="toggleAdvancedSearch" class="btn btn-link" type="button">Опции за пребарување</button>                      
                        </div>                 
                    </div>
                </div>

                <div id="advancedSearchContainer" class="container offer">
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label id="lblName" runat="server" >Име:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbName"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblUser" runat="server">Понудил:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbUser"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblAlbum" runat="server">Албум:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbAlbum"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblYear" runat="server">Година:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbYear"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblPrice" runat="server">Цена:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbPrice"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblOfferType" runat="server">Тип на понуда:</asp:Label>
                        </div>
                        <div class="col-xs-2">
                            <asp:CheckBox runat="server" ID="chkBuy" Text="Buy"></asp:CheckBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:CheckBox runat="server" ID="chkExchange" Text="Exchange"></asp:CheckBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:CheckBox runat="server" ID="chkRequest" Text="Request"></asp:CheckBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-6 col-sm-offset-2">
                            <asp:Button ID="btnAdvancedSearch" runat="server" CssClass="btn btn-default" Text="Пребарај" />
                        </div>
                    </div>
                   
                </div>

                <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

                <asp:Repeater runat="server" ID="repeaterHomepage">
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
