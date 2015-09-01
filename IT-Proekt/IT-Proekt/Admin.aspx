<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="IT_Proekt.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
    
        <title>My Offers</title>
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
                            <li><asp:LinkButton href="#Doma" runat="server" Text="Kорисници"></asp:LinkButton></li>
                            <li><asp:LinkButton href="#Dodadi_Album" runat="server" Text="Додади Албум"></asp:LinkButton></li>
                            <li class="active"><asp:LinkButton href="#MyOffers" runat="server" Text="Понуди" ></asp:LinkButton></li>                                 
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
                <!-- <div id="searchContainer">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="input-group">
                                <asp:TextBox id="txtSearch" runat="server" CssClass="form-control" placeholder="Пребарај слики, албуми..."></asp:TextBox>
                                <span class="input-group-btn">
                                <asp:Button ID="btnSearch" runat="server" Text="Барај" CssClass="btn btn-default"></asp:Button>
                                </span>
                            </div><!-- /input-group -->
                       <!-- </div>
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
                </div> !-->

                <div id="advancedSearchContainer" class="container offer">
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label id="lblName" runat="server" >Име:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbAdvancedSearchName"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblUser" runat="server">Понудил:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbAdvancedSearchUser"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblAlbum" runat="server">Албум:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbAdvancedSearchAlbum"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblYear" runat="server">Година:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbAdvancedSearchYear"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblAdvancedSearchPrice" runat="server">Цена:</asp:Label>
                        </div>
                        <div class="col-xs-10">
                            <asp:TextBox runat="server" ID="txbAdvancedSearchPrice"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-2">
                            <asp:Label ID="lblAdvancedSearchOfferType" runat="server">Тип на понуда:</asp:Label>
                        </div>
                        <div class="col-xs-2">
                            <asp:CheckBox runat="server" ID="chkAdvancedSearchBuy" Text="Buy"></asp:CheckBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:CheckBox runat="server" ID="chkAdvancedSearchExchange" Text="Exchange"></asp:CheckBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:CheckBox runat="server" ID="chkAdvancedSearchRequest" Text="Request"></asp:CheckBox>
                        </div>
                    </div>
                    <div class="row paddingTopBottom">
                        <div class="col-xs-6 col-sm-offset-2">
                            <asp:Button ID="btnAdvancedSearch" runat="server" CssClass="btn btn-default" Text="Пребарај" />
                        </div>
                    </div>
                   
                </div>

                <!--<div id="newOfferButtonContainer" class="container">
                    <div class="col-xs-2 col-sm-offset-5">
                        <button class="btn btn-primary" type="button" id="btnNewOffer">Нова Понуда</button>
                    </div>
                </div> !-->

                <div id="newOfferContainer" class="container offer">  <!-- Функционира само над 768px -->
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="row">
                                <div class="col-sm-12 ">
                                    <asp:TextBox ID="txbNewOfferName" runat="server" placeholder="Внеси име на понуда..." Width="40%"></asp:TextBox>
                                </div>   
                            </div>            
                            <div class="row" style="padding-top:10px; margin-bottom:10px;">
                                <div class="col-xs-12">
                                    <input id="imageUpload" type="file" runat="server"/>
                                </div>
                            </div>                
                            <div class="row">
                                <div class="col-xs-7">
                                    <asp:Image ID="imagePreview" runat="server" height="150px" Width="100%"/>   
                                </div>
                                <div class="col-xs-5" style="height:150px">
                                    <asp:Button ID="btnImageUpload" runat="server" CssClass="btn btn-default alignBottomRight" Text="Upload" />
                                </div>
                            </div>  
                        </div>
                        <div class="col-sm-6">
                            <!-- <div class="row">
                                <div class="col-sm-3 col-sm-offset-9">
                                    <asp:Button ID="btnNewOfferRemove" runat="server" CssClass="btn btn-danger" Text="Remove" />
                                </div>
                            </div> !-->
                            <div class="row">
                                <div class="col-sm-12">
                                    <p>Опис</p>
                                    <asp:TextBox runat="server" ID="txbNewOfferDescription" CssClass="widthTextBox"></asp:TextBox>
                                </div>                                
                            </div>
                            <div class="row " style="padding-top:10px">
                                <div class="col-sm-2 " >
                                    <p>Цена:</p>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox runat="server" ID="txbNewOfferPrice" style="width:50px;"></asp:TextBox>
                                </div>
                                <div class="col-sm-3 " >
                                    <asp:Button runat="server" id="btnNewOfferSubmit" CssClass="btn btn-success" Text="Потврди"/>
                                </div>                                    
                            </div>
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
                            <div class="row">
                                <!--<div class="col-sm-3 ">
                                    <asp:LinkButton ID="btnOfferRefresh" runat="server" CssClass="btn btn-info" Text="Refresh" > <img src="/img/correct.png"/></asp:LinkButton>
                                </div>!-->
                                
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
                            </div>
                            <div class="row">
                                <div class="col-sm-3 col-sm-offset-6">
                                    <asp:LinkButton ID="btnOfferRemove" runat="server" CssClass="btn btn-danger"><img src="/img/wrong.png"/></asp:LinkButton>
                                </div>
                                <div class="col-sm-3 " >
                                    <asp:LinkButton runat="server" id="Button3" CssClass="btn btn-success"><img src="/img/rsz_correct.png" /></asp:LinkButton>
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