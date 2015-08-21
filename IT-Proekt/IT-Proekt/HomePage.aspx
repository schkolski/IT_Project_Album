<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IT_Proekt.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
    
        <title>Home Page</title>
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
                            <li><asp:LinkButton href="#LogOut" runat="server" Text="Одлогирај се"></asp:LinkButton></li>
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

                <div id="OfferContainer" class="container offer">  <!-- Функционира само над 768px -->
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-12" style="font-size:20px">
                                    <asp:Label ID="lblOfferName" runat="server">Име на понуда</asp:Label>
                                </div>   
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="row" style="font-size:20px">
                                <div class="col-sm-3 ">
                                    <asp:Label ID="lblOfferOwner" runat="server" >Понудил</asp:Label>
                                </div>
                                <div class="col-sm-3 col-sm-offset-6">
                                    <asp:Label ID="lblOfferTrustLevel" runat="server">Trust Level</asp:Label>
                                </div>
                            </div>
                            <div class="row" style="padding-top:10px">
                                <div class="col-sm-12">
                                    <p>Опис</p>
                                    <asp:Label ID="lblOfferDescription" runat="server">
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                                    </asp:Label>
                                </div>                                
                            </div>
                            <div class="row " style="padding-top:10px">
                                <div class="col-sm-2 " >
                                    <p>Цена:</p>
                                </div>
                                <div class="col-sm-7">
                                    <asp:Label ID="lblOfferPrice" runat="server">10$</asp:Label>
                                </div>
                                <div class="col-sm-3 " >
                                    <asp:Button runat="server" id="btnOfferBuy" CssClass="btn btn-success" Text="Купи"/>
                                </div>                                    
                            </div>
                        </div>
                    </div>                                        
                </div>     
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
