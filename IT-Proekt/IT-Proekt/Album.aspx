<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="IT_Proekt.Album1" %>

<%@ Register TagPrefix="my" TagName="albumElement" Src="albumElement.ascx" %>
<%@ Register TagPrefix="myHalf" TagName="albumElementHalf" Src="albumElementHalf.ascx" %>

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
                        <li>
                            <asp:LinkButton href="HomePage.aspx" runat="server" Text="Дома"></asp:LinkButton></li>
                        <li class="active">
                            <asp:LinkButton href="Album.aspx" runat="server" Text="Албум"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="MyOffers.aspx" runat="server" Text="Мои Понуди"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="#Stats" runat="server" Text="Статистики"></asp:LinkButton></li>
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

        <div class="container">
            <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>

            <div id="chooseAlbumContainer" class="container offer" style="width: 97%">
                <asp:UpdatePanel runat="server" ID="upPanelMenu">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txbChooseAlbumName" runat="server" placeholder="Внеси име на албум..." Width="70%"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txbChooseAlbumYear" runat="server" placeholder="Внеси година..." Width="70%"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txbChooseAlbumName" ValidationGroup="1" ErrorMessage="Внесете име!!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txbChooseAlbumYear" ValidationGroup="1" ErrorMessage="Внесете година!!!" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6" style="padding-left: 15px">
                                <div class="row">
                                    <div class="col-sm-3 col-sm-offset-9">
                                        <asp:Button runat="server" ID="btnChooseAlbum" CssClass="btn btn-primary" Text="Избери" ValidationGroup="1" OnClick="btnChooseAlbum_Click" AutoPostBack="True" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div id="albumContainer" class="">
                <!-- Функционира само над 768px -->
                <asp:UpdatePanel runat="server" ID="upPanelPictures">
                    <ContentTemplate>
                        <!-- end row -->
                        <asp:Repeater runat="server" ID="repeaterAlbum" OnItemCommand="repeaterAlbum_ItemCommand">
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <!-- end albumContainer -->
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
