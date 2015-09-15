<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOffers.aspx.cs" Inherits="IT_Proekt.MyOffers" %>

<%@ Register TagPrefix="myOffer" TagName="myOffer" Src="myOffer.ascx" %>
<%@ Register TagPrefix="myOfferHalf" TagName="myOfferHalf" Src="myOfferHalf.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
    
        <title>Мои Понуди</title>
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
                        <asp:LinkButton CssClass="navbar-brand" runat="server" href="HomePage.aspx" Text="ИТ Проект"></asp:LinkButton>
                    </div>

                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li><asp:LinkButton href="HomePage.aspx" runat="server" Text="Дома"></asp:LinkButton></li>
                            <li><asp:LinkButton href="Album.aspx" runat="server" Text="Албум"></asp:LinkButton></li>
                            <li class="active"><asp:LinkButton href="MyOffers.aspx" runat="server" Text="Мои Понуди" ></asp:LinkButton></li>                                 
                            <li><asp:LinkButton href="Transakcii.aspx" runat="server" Text="Транскации"></asp:LinkButton></li>                                                            
                            <li><asp:LinkButton href="Statistiki.aspx" runat="server" Text="Статистики"></asp:LinkButton></li>           
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li><asp:LinkButton href="ProfilePage.aspx" runat="server" Text="Мои Информации"></asp:LinkButton></li>
                            <li><asp:LinkButton runat="server" Text="Одлогирај се" ID="LogOut" OnClick="LogOut_Click"></asp:LinkButton></li>
                        </ul>
                    </div><!--/.nav-collapse -->
                </div>
            </nav>

            <div class="container">
              
                <div id="newOfferButtonContainer" class="container" style="padding-top:15px;">
                    <div class="col-xs-2 col-sm-offset-5">
                        <button class="btn btn-primary" type="button" id="btnNewOffer">Нова Понуда</button>
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

                <div id="newOfferContainer" class="container offer" style="width:1000px;">  <!-- Функционира само над 768px -->
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>                        
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-sm-6 ">
                                            <asp:DropDownList ID="ddAlbumName" CommandName="ddAlbumName" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" runat="server" width="70%" OnSelectedIndexChanged="ddAlbumName_SelectedIndexChanged"></asp:DropDownList>
                                        </div>   
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddAlbumYear" CommandName="ddAlbumYear" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" runat="server" width="70%" OnSelectedIndexChanged="ddAlbumYear_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>   
                            
                                    <div class="row" style="padding-top:15px">
                                        <div class="col-xs-6">
                                            <asp:Image ID="imgNewOfferPreview" runat="server" height="200px" Width="155px"/>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="row">
                                                <h4>Опции:</h4>
                                            </div>
                                            <div class="row" style="padding-top:50%">
                                                <div class="col-sm-8" style="padding-left:0px">
                                                    <p>Замена</p>
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:CheckBox runat="server" ID="chkNewOfferExchange" Checked="false" />
                                                </div>
                                            </div>
                                        </div>      
                                    </div>  
                                    <div class="row" style="padding-top:15px">
                                        <div class="col-sm-12">
                                            <asp:Button ID="btnImagePreview" runat="server" CssClass="btn btn-default" Text="Preview" OnClick="btnImagePreview_Click"/> 
                                        </div>
                                    </div>  
                                </div>
                                <div class="col-sm-4">
                                    <div class="row">
                                        <div class="col-sm-9">
                                            <asp:DropDownList ID="ddPictureNumber" runat="server" Width="40%" CssClass="btn btn-default dropdown-toggle"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:Button ID="btnNewOfferClear" runat="server" CssClass="btn btn-danger" Text="Избриши" OnClick="btnOfferClear_Click" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <h4>Опис:</h4>
                                            <asp:TextBox runat="server" ID="txbNewOfferDescription" CssClass="widthTextBox" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row " style="padding-top:10px">
                                        <div class="col-sm-2 " >
                                            <p>Цена:</p>
                                        </div>
                                        <div class="col-sm-7">
                                            <asp:TextBox runat="server" ID="txbNewOfferPrice" style="width:50px;"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 " style ="padding-top:20%">
                                            <asp:Button runat="server" id="btnNewOfferSubmit" CssClass="btn btn-success" Text="Потврди" OnClick="btnNewOfferSubmit_Click"/>
                                        </div>    
                                    </div>
                                </div>
                            </div>           
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger  ControlID="ddAlbumName" EventName="SelectedIndexChanged"/>
                            <asp:AsyncPostBackTrigger ControlID="ddAlbumYear" EventName="SelectedIndexChanged"/>
                            

                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                
                <div id="OfferContainer" class="">  <!-- Функционира само над 500px -->
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                                
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div><!--end offerContainer-->

                <asp:Repeater runat="server" ID="repeaterMyOffers">
                    <ItemTemplate>

                    </ItemTemplate>
                </asp:Repeater>
                           
           </div>

            <footer class="footer">
            <div class="row" style="padding-bottom:1%;padding-top:1%">
                <div class="col-lg-8">
                    All copyrights &copy; reserved 2015 It Project 
                </div>
                <div class="col-lg-4">
                    <asp:Button runat="server" ID="kontakt" CssClass="btn-link" Text="Контакт"/>
                    <asp:Button runat="server" ID="Button1" CssClass="btn-link" Text="За нас"/>
                    <asp:Button runat="server" ID="Button2" CssClass="btn-link" Text="Маркетинг"/>
                </div>
            </div>
        </footer>


        </form>
    </body>

    
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js" ></script>
    <script src="Scripts/bootstrap.min.js"></script>    
    <script src="Scripts/HomePage.js"></script>
</html>
