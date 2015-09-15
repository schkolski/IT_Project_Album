<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="IT_Proekt.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Admin-Korisnici</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/homePage.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap-wizard/1.2/jquery.bootstrap.wizard.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript">
        function GetMyValue()
        {
            var someVar = <%=this.fillAllUsers()%>;
            return someVar;
        }

    </script>
    <script>
        $(function () {
            var availableTags = GetMyValue();
            console.log(availableTags); 
            $("#txtSearch").autocomplete({
                source: availableTags
            });
        });
    </script>
</head>
<body onload="GetMyValue()">
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
                    <asp:LinkButton CssClass="navbar-brand" href="Admin.aspx" runat="server" Text="ИТ Проект"></asp:LinkButton>
                </div>

                <div id="navbar" class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li class="active">
                            <asp:LinkButton href="Admin.aspx" runat="server" Text="Kорисници"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton href="AddAlbum.aspx" runat="server" Text="Додади Албум"></asp:LinkButton></li>
                         <li>
                            <asp:LinkButton href="Statistiki.aspx" runat="server" Text="Статистики"></asp:LinkButton></li>
                        
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li>
                            <asp:LinkButton href="ProfilePage.aspx" runat="server" Text="Мои Информации"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton runat="server" Text="Одлогирај се" ID="LogOut" OnClick="LogOut_Click"></asp:LinkButton></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>

        <div class="container col-sm-5 col-sm-offset-3 col-lg-5 col-lg-offset-3" >
            <div class="search" style="margin-left:12%">
                <div class="col-xs-12">
                    <div class="input-group">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Пребарај корисници..."></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnSearch" runat="server" Text="Барај" CssClass="btn btn-default" style="position: absolute; clip: rect(0px 0px 0px 0px);" OnClick="btnSearch_Click"></asp:Button>
                            <div class="bootstrap-filestyle input-group " style="width: auto;">
                                <span class="group-span-filestyle " tabindex="0">
                                    <label for="btnSearch" class="btn btn-primary">
                                        <span class="icon-span-filestyle glyphicon glyphicon-search"></span>
                                        <span class="buttonText">Барај</span>

                                    </label>

                                </span>
                                <!-- Choose file - button  glyphicon glyphicon-forward-->
                            </div>
                        </span>
                    </div>
                    <!-- /input-group -->
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12" style="margin-left: 20%; margin-top: 5%">
                    <asp:Repeater runat="server" ID="repeaterTransakcii">
                        <ItemTemplate>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="327px" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="username" SortExpression="username" HeaderText="Корисници">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="type" SortExpression="type" HeaderText="Тип">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Button" Text="Промени" CommandName="Select">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                            </asp:ButtonField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbConnection %>" SelectCommand="SELECT [username] FROM [Korisnik]"></asp:SqlDataSource>
                </div>
            </div>
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
</html>

