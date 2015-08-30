<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="IT_Proekt.Album1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
    
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
                        <asp:LinkButton CssClass="navbar-brand" runat="server" Text="ИТ Проект"></asp:LinkButton>
                    </div>

                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li><asp:LinkButton href="#Doma" runat="server" Text="Дома"></asp:LinkButton></li>
                            <li class="active"><asp:LinkButton href="#Album" runat="server" Text="Албум"></asp:LinkButton></li>
                            <li><asp:LinkButton href="#MyOffers" runat="server" Text="Мои Понуди" ></asp:LinkButton></li>                                 
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
                <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

                <div id="chooseAlbumContainer" class="container offer">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txbChooseAlbumName" runat="server" placeholder="Внеси име на албум..." width="70%"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txbChooseAlbumYear" runat="server" placeholder="Внеси година..." width="70%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>                                
                                <div class="col-sm-6" style="padding-left:15px">
                                    <div class="row">
                                        <div class="col-sm-3 col-sm-offset-9">
                                            <asp:Button runat="server" ID="btnChooseAlbum" CssClass="btn btn-primary" Text="Избери"/>
                                        </div>
                                    </div>                                    
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>                    
                </div>

                <div id="albumContainer" class="">  <!-- Функционира само над 768px -->
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>                        
                            <div class="row">

                                <div class="col-sm-6" id="albumElementContainer1">
                                    <div class="offer" style="margin-right:7px">
                                        <div class="row">
                                            <div class="col-sm-4 col-sm-offset-1">
                                                <asp:Label runat="server" ID="lblAlbumElementID" Text="ID"></asp:Label>
                                            </div>   
                                            <div class="col-sm-4">
                                                <asp:Label runat="server" ID="lblAlbumElementName" Text="Album"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label runat="server" ID="lblAlbumElementGodina" Text="Year"></asp:Label>
                                             </div>
                                        </div>  
                                    
                                        <div class="row" style="padding-top:15px">
                                            <div class="col-xs-6">
                                                <asp:Image ID="imgAlbumElementPreview" runat="server" height="130px" Width="100%"/>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="row">
                                                    <h4>Опции:</h4>
                                                </div>            
                                                <div class="row">
                                                    <div class="col-sm-6" style="padding-left:0px">
                                                        <p>Замена</p>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <asp:CheckBox runat="server" ID="chkAlbumElementExchange" Checked="false" />
                                                    </div>
                                                </div>                                    
                                                <div class="row">
                                                    <div class="col-sm-6" style="padding-left:0px">
                                                        <p>Број на слики</p>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox runat="server" ID="txbAlbumElementNumber" Width="30px">1</asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-sm-offset-6" style="padding-top:15px">
                                                        <asp:Button ID="btnAlbumElementAdd" runat="server" CssClass="btn btn-success" Text="Додај" /> 
                                                    </div>
                                                </div>
                                            </div>      
                                        </div>                                          
                                    </div>
                                </div> <!-- end albumElementContainer1 -->

                                <div class="col-sm-6" id="albumElementContainer2">
                                    <div class="offer" style="margin-right:7px">
                                        <div class="row">
                                            <div class="col-sm-4 col-sm-offset-1">
                                                <asp:Label runat="server" ID="Label1" Text="ID"></asp:Label>
                                            </div>   
                                            <div class="col-sm-4">
                                                <asp:Label runat="server" ID="Label2" Text="Album"></asp:Label>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label runat="server" ID="Label3" Text="Year"></asp:Label>
                                             </div>
                                        </div>  
                                    
                                        <div class="row" style="padding-top:15px">
                                            <div class="col-xs-6">
                                                <asp:Image ID="Image1" runat="server" height="130px" Width="100%"/>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="row">
                                                    <h4>Опции:</h4>
                                                </div>            
                                                <div class="row">
                                                    <div class="col-sm-6" style="padding-left:0px">
                                                        <p>Замена</p>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <asp:CheckBox runat="server" ID="CheckBox1" Checked="false" />
                                                    </div>
                                                </div>                                    
                                                <div class="row">
                                                    <div class="col-sm-6" style="padding-left:0px">
                                                        <p>Број на слики</p>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <asp:TextBox runat="server" ID="TextBox1" Width="30px">1</asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-sm-offset-6" style="padding-top:15px">
                                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Додај" /> 
                                                    </div>
                                                </div>
                                            </div>      
                                        </div>                                          
                                    </div>
                                </div> <!-- end albumElementContainer2 -->

                            </div> <!-- end row -->
                                 
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div> <!-- end albumContainer -->

                
                           
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
