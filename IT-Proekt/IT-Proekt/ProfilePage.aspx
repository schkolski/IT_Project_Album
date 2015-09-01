<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="IT_Proekt.ProfilePage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
    
        <title>ProfilePage</title>
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <link href="Content/homePage.css" rel="stylesheet" />
        <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
        <script>
            $(document).ready(function () {
                $("#changePass").click(function () {
                    $(".skrij").toggle();
                })
            });
        </script>
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
                <div class="row" style="margin-top:10%;">
                    <div class="col-lg-12">
                        <asp:Label runat="server" Text="Name :"></asp:Label>
                        <asp:TextBox runat="server" placeholder="Name" ID="tbName"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <asp:Label runat="server" Text="Email :"></asp:Label>
                        <asp:TextBox runat="server" placeholder="Email" ID="tbEmail"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                        <div class="col-xs-12">
                            <h5>BirthDay</h5>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:DropDownList runat="server" ID="ddMonth"></asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddDay"></asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddYear"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-12">
                            <h5>BirthDate</h5>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Panel runat="server" ID="panael">
                                <asp:RadioButton runat="server" Text="Male" ID="rbMale" ValidationGroup="1" GroupName="1"/>
                                <asp:RadioButton runat="server" Text="Female" ID="rbFemale" ValidationGroup="1" GroupName="1"/>
                            </asp:Panel>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-xs-12" id="primer">
                            <asp:Button runat="server" Text="Change Password" ID="changePass"/>
                            <input type="text" class="skrij" id="pass" runat="server" />
                            <input type="text" class="skrij" id="repass" runat="server" />
                        </div>
                    </div>
                    <div class="row" style="float:right">
                        <div class ="col-xs-12">
                            <asp:Button runat="server" ID="Promeni" text="Save" CssClass="btn-info"/>
                        </div>
                    </div>
            </div>
    </form>
</body>
</html>