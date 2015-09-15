<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistiki.aspx.cs" Inherits="IT_Proekt.Statistiki" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Статистики</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/homePage.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <style>
        .nevidlivo {
            display: none;
            visibility: hidden;
        }
    </style>
    <script>
        $(function () {
            var admin =<%=this.primer()%>;
            if(new String (admin).valueOf() ==new String("true").valueOf())
            {   
                $( ".primer" ).addClass( "nevidlivo" );
                $(".lbAddAlbum").attr({href:"AddAlbum.aspx"});
                $("#<%=lbAddAlbum.ClientID%>").text('Додади Албум');
               $("#<%=lbKorisnici.ClientID%>").text('Корисници');
               $(".lbKorisnici").attr({href:"Admin.aspx"});
               $("#<%=lbIt.ClientID%>").attr({href:"Admin.aspx"});
                $("li .primer").remove();
            }else
            {
                $("#<%=lbIt.ClientID%>").attr({href:"HomePage.aspx"});
           }
            
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-inverse navbar-fixed-top">
                <div class="container">
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <asp:LinkButton CssClass="navbar-brand" runat="server" ID="lbIt" Text="ИТ Проект"></asp:LinkButton>
                    </div>

                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li>
                                <asp:LinkButton href="HomePage.aspx" ID="lbKorisnici" runat="server" CssClass="lbKorisnici" Text="Дома"></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton href="Album.aspx" ID="lbAddAlbum" CssClass="lbAddAlbum" runat="server" Text="Албум"></asp:LinkButton></li>
                            <li class="primer">
                                <asp:LinkButton href="MyOffers.aspx" runat="server" CssClass="primer" Text="Мои Понуди"></asp:LinkButton></li>
                            <li class="primer">
                                <asp:LinkButton href="Transakcii.aspx" runat="server" CssClass="primer" Text="Транскации"></asp:LinkButton></li>
                            <li class="active">
                                <asp:LinkButton href="Statistiki.aspx" runat="server" Text="Статистики"></asp:LinkButton></li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li>
                                <asp:LinkButton href="ProfilePage.aspx" runat="server" Text="Мои Информации"></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="LogOut" runat="server" Text="Одлогирај се" OnClick="LogOut_Click"></asp:LinkButton></li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </nav>


            <!-- Marketing messaging and featurettes
        ================================================== -->
            <!-- Wrap the rest of the page in another container to center all the content. -->

            <div class="container marketing">

                <!-- Three columns of text below the carousel -->
                <div class="row">
                    <div class="col-lg-4">

                        <asp:Chart ID="Chart1" runat="server" Height="300px" Width="350px">
                            <Titles>
                                <asp:Title ShadowOffset="3" Name="Title1" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom"
                                    IsTextAutoFit="False" Name="Default"
                                    LegendStyle="Row" />
                            </Legends>
                            <Series>
                                <asp:Series Name="Default" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"
                                    BorderWidth="0" />
                            </ChartAreas>
                        </asp:Chart>

                        <h2>Денови со најголем број понуди</h2>
                        <p>
                            <asp:Label runat="server" ID="lblPie1"></asp:Label></p>

                    </div>
                    <!-- /.col-lg-4 -->
                    <div class="col-lg-4">
                        <asp:Chart ID="Chart2" runat="server" Height="300px" Width="350px">
                            <Titles>
                                <asp:Title ShadowOffset="3" Name="Title1" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom"
                                    IsTextAutoFit="False" Name="Default"
                                    LegendStyle="Row" />
                            </Legends>
                            <Series>
                                <asp:Series Name="Default" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"
                                    BorderWidth="0" />
                            </ChartAreas>
                        </asp:Chart>

                        <h2>Понудени сликички</h2>
                        <p>
                            <asp:Label runat="server" ID="lblPie2"></asp:Label></p>

                    </div>
                    <!-- /.col-lg-4 -->
                    <div class="col-lg-4">
                        <asp:Chart ID="Chart3" runat="server" Height="300px" Width="350px">
                            <Titles>
                                <asp:Title ShadowOffset="3" Name="Title1" />
                            </Titles>
                            <Legends>
                                <asp:Legend Alignment="Center" Docking="Bottom"
                                    IsTextAutoFit="False" Name="Default"
                                    LegendStyle="Row" />
                            </Legends>
                            <Series>
                                <asp:Series Name="Default" />
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"
                                    BorderWidth="0" />
                            </ChartAreas>
                        </asp:Chart>

                        <h2>Состојба на трансакции</h2>
                        <p>
                            <asp:Label runat="server" ID="lblPie3"></asp:Label></p>

                    </div>
                    <!-- /.col-lg-4 -->
                </div>
                <!-- /.row -->


                <!-- START THE FEATURETTES -->

                <hr class="featurette-divider">

                <div class="row featurette">
                    <div class="col-md-7">
                        <h2 class="featurette-heading">Најпродавана сликичка. <span class="text-muted">
                            <asp:Label runat="server" ID="lblNajprodavana"></asp:Label></span></h2>
                        <p class="lead">
                            <asp:Label runat="server" ID="lblNajprodavanaDescription" Text="Нема најпродавана сликичка во овој момент."></asp:Label></p>
                    </div>
                    <div class="col-md-5">
                        <asp:Image runat="server" ID="imgNajprodavana" CssClass="featurette-image img-responsive center-block" alt="Generic placeholder image" Width="155px" Height="200px" />
                    </div>
                </div>

                <hr class="featurette-divider">

                <div class="row featurette">
                    <div class="col-md-7 col-md-push-5">
                        <h2 class="featurette-heading">Најскапо продадена сликичка. <span class="text-muted">
                            <asp:Label runat="server" ID="lblNajskapa"></asp:Label></span></h2>
                        <p class="lead">
                            <asp:Label runat="server" ID="lblNajskapaDescription" Text="Нема најскапо продадена сликичка во овој момент."></asp:Label></p>
                    </div>
                    <div class="col-md-5 col-md-pull-7">
                        <asp:Image runat="server" ID="imgNajskapa" CssClass="featurette-image img-responsive center-block" alt="Generic placeholder image" Width="155px" Height="200px" />
                    </div>
                </div>

                <hr class="featurette-divider">

                <div class="row featurette">
                    <div class="col-md-7">
                        <h2 class="featurette-heading">Корисник што потрошил најмногу пари. <span class="text-muted">
                            <asp:Label runat="server" ID="lblNajmnoguPotroshil"></asp:Label></span></h2>
                        <p class="lead">
                            <asp:Label runat="server" ID="lblNajmnoguPotroshilDescription" Text="Нема корисник што потрошил најмногу пари во овој момент."></asp:Label></p>
                    </div>
                </div>

                <hr class="featurette-divider">

                <!-- /END THE FEATURETTES -->


                <!-- FOOTER -->


                <footer class="footer">
                    <div class="row" style="padding-bottom: 1%; padding-top: 1%">
                        <div class="col-lg-8">
                            All copyrights &copy; reserved 2015 It Project 
                        </div>
                        <div class="col-lg-4">
                            <asp:Button runat="server" ID="kontakt" CssClass="btn-link" Text="Контакт" />
                            <asp:Button runat="server" ID="Button1" CssClass="btn-link" Text="За нас" />
                            <asp:Button runat="server" ID="Button2" CssClass="btn-link" Text="Маркетинг" />
                        </div>
                    </div>
                </footer>

            </div>
            <!-- /.container -->
        </div>
    </form>
</body>


<script src="Scripts/jquery-1.10.2.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/HomePage.js"></script>
</html>
