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
                    <asp:LinkButton CssClass="navbar-brand" runat="server" Text="ИТ Проект"></asp:LinkButton>
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

                <asp:chart id="Chart1" runat="server" Height="300px" Width="300px">
                  <titles>
                    <asp:Title ShadowOffset="3" Name="Title1" />
                  </titles>
                  <legends>
                    <asp:Legend Alignment="Center" Docking="Bottom"
                                IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                  </legends>
                  <series>
                    <asp:Series Name="Default" />
                  </series>
                  <chartareas>
                    <asp:ChartArea Name="ChartArea1"
                                     BorderWidth="0" />
                  </chartareas>
                </asp:chart>
                
                <h2>Динамичка Пита 1</h2>
                <p>Информации за питата. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna.</p>
                
            </div><!-- /.col-lg-4 -->
            <div class="col-lg-4">
                <asp:chart id="Chart2" runat="server" Height="300px" Width="300px">
                  <titles>
                    <asp:Title ShadowOffset="3" Name="Title1" />
                  </titles>
                  <legends>
                    <asp:Legend Alignment="Center" Docking="Bottom"
                                IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                  </legends>
                  <series>
                    <asp:Series Name="Default" />
                  </series>
                  <chartareas>
                    <asp:ChartArea Name="ChartArea1"
                                     BorderWidth="0" />
                  </chartareas>
                </asp:chart>
                
                <h2>Динамичка Пита 2</h2>
                <p>Информации за питата. Еget lacinia odio sem nec elit. Cras mattis consectetur purus sit amet fermentum. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh.</p>
                
            </div><!-- /.col-lg-4 -->
            <div class="col-lg-4">
                <asp:chart id="Chart3" runat="server" Height="300px" Width="300px">
                  <titles>
                    <asp:Title ShadowOffset="3" Name="Title1" />
                  </titles>
                  <legends>
                    <asp:Legend Alignment="Center" Docking="Bottom"
                                IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                  </legends>
                  <series>
                    <asp:Series Name="Default" />
                  </series>
                  <chartareas>
                    <asp:ChartArea Name="ChartArea1"
                                     BorderWidth="0" />
                  </chartareas>
                </asp:chart>
                
                <h2>Динамичка Пита 3</h2>
                <p>Информации за питата. Dapibus ac facilisis in, egestas eget quam. Vestibulum id ligula porta felis euismod semper. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>
                
            </div><!-- /.col-lg-4 -->
            </div><!-- /.row -->


            <!-- START THE FEATURETTES -->

            <hr class="featurette-divider">

            <div class="row featurette">
            <div class="col-md-7">
                <h2 class="featurette-heading">Најпродавана сликичка. <span class="text-muted">Име на сликичката</span></h2>
                <p class="lead">Оваа сликичка е најпополарна во овој момент. Се работи за сликичка од албумот ИмеНаАлбум издаден во 3000 година.</p>
            </div>
            <div class="col-md-5">
                <img class="featurette-image img-responsive center-block" data-src="holder.js/500x500/auto" alt="Generic placeholder image">
            </div>
            </div>

            <hr class="featurette-divider">

            <div class="row featurette">
            <div class="col-md-7 col-md-push-5">
                <h2 class="featurette-heading">Албум кој е најсобиран. <span class="text-muted">Име на албум</span></h2>
                <p class="lead">Најсобираниот албум е издаден во 2500 година и има 50 сликички. Повеќе информации за албумот тука ќе се допишат...</p>
            </div>
            <div class="col-md-5 col-md-pull-7">
                <img class="featurette-image img-responsive center-block" data-src="holder.js/500x500/auto" alt="Generic placeholder image">
            </div>
            </div>

            <hr class="featurette-divider">

            <div class="row featurette">
            <div class="col-md-7">
                <h2 class="featurette-heading">Уште една статистика. <span class="text-muted">Име</span></h2>
                <p class="lead">Информации...</p>
            </div>
            <div class="col-md-5">
                <img class="featurette-image img-responsive center-block" data-src="holder.js/500x500/auto" alt="Generic placeholder image">
            </div>
            </div>

            <hr class="featurette-divider">

            <!-- /END THE FEATURETTES -->


            <!-- FOOTER -->
            <footer>
            <p class="pull-right"><a href="#">Back to top</a></p>
            <p>&copy; 2014 Company, Inc. &middot; <a href="#">Privacy</a> &middot; <a href="#">Terms</a></p>
            </footer>

        </div><!-- /.container -->
    </div>
    </form>
</body>

    
<script src="Scripts/jquery-1.10.2.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/HomePage.js"></script>
</html>
