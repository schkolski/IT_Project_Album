<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="IT_Proekt.ProfilePage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>ProfilePage</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/homePage.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <!--<script>
            $(document).ready(function () {
                $("#changePass").click(function () {
                    $(".skrij").toggle();
                })
            });
        </script>-->
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
    <script src="Scripts/js/bootstrap-datepicker.js"></script>
    <script src="Scripts/css/datepicker.css"></script>
    <style>
        .nevidlivo 
        {
            display:none;
            visibility:hidden;
        }
    </style>
    <link rel="stylesheet" href="Scripts/jquery-ui-1.11.4/jquery-ui.css">
        
    <script src="Scripts/jquery-ui-1.11.4/jquery-ui.js"></script>
    <script>
        
        $(document).ready(function () {
            // $('.datepicker').datepicker();
            $(function () {
                $(".datepicker").datepicker({
                    startDate: '-3d',
                    dateFormat:"dd/mm/yy",
                    changeMonth: true,
                    changeYear: true
                });
            });
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
                    <asp:LinkButton CssClass="navbar-brand" href="#" ID="lbIt" runat="server" Text="ИТ Проект"></asp:LinkButton>
                </div>

                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li>
                            <asp:LinkButton href="HomePage.aspx" ID="lbKorisnici" CssClass="lbKorisnici" runat="server" Text="Дома"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="Album.aspx" ID="lbAddAlbum" CssClass="lbAddAlbum" runat="server" Text="Албум"></asp:LinkButton></li>
                        <li class="primer">
                            <asp:LinkButton href="MyOffers.aspx" runat="server" CssClass="primer" Text="Мои Понуди"></asp:LinkButton></li>
                        <li class="primer">
                            <asp:LinkButton href="Transakcii.aspx" runat="server" CssClass="primer" Text="Трансакции"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="Statistiki.aspx" runat="server" Text="Статистики"></asp:LinkButton></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="active">
                            <asp:LinkButton href="ProfilePage.aspx" runat="server" Text="Мои Информации"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton id="LogOut"  runat="server" Text="Одлогирај се" OnClick="LogOut_Click"></asp:LinkButton></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>
        <div class="container">
            <div class="row" style="margin-top: 10%;">
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
                    <div class="input-append date" id="dp3">
                        <asp:TextBox ID="bDay" runat="server" class="datepicker" size="16"></asp:TextBox>
                        <!--<asp: input id="bDay" class="datepicker" size="16" type="text">-->
                      <span class="add-on"><i class="icon-th"></i></span>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12">
                </div>
            </div>
            <br />
            <div class="row">
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Panel runat="server" ID="panael">
                        <asp:RadioButton runat="server" Text="Male" ID="rbMale" ValidationGroup="1" GroupName="1" />
                        <asp:RadioButton runat="server" Text="Female" ID="rbFemale" ValidationGroup="1" GroupName="1" />
                        <br />
                        <asp:Button ID="Promeni" runat="server" CssClass="btn-info" Text="Save" OnClick="Promeni_Click" />
                    </asp:Panel>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-xs-12" id="primer">
                    <input type="text" class="skrij" id="oldPassword" placeholder="Old Password" runat="server" /><br />
                    <input type="text" class="skrij" id="newPassword" placeholder="New Password" runat="server" /><br />
                    <asp:Button runat="server" Text="Change Password" ID="changePass" OnClick="changePass_Click" />
                    &nbsp;
                </div>
            </div>
            <div class="row" style="float: right">
                <div class="col-xs-12">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
