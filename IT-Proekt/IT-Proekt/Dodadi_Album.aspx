<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dodadi_Album.aspx.cs" Inherits="IT_Proekt.Dodadi_Album" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
    
        <title>Add Album</title>
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
                            <li><asp:LinkButton href="#Doma" runat="server" Text="Дома"></asp:LinkButton></li>
                            <li class="active"><asp:LinkButton href="#Dodadi_Album" runat="server" Text="Додади Албум"></asp:LinkButton></li>
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
          <div class="container" style="margin:auto; padding:15%">
            <div class="row">
                <div class="col-lg-6">
                    <asp:TextBox runat="server" placeholder ="Year" CssClass="form-control" ID="tbYear" ValidationGroup="1"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbYear" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </div>
              <br />
            <div class="row">
                <div class="col-lg-6">
                    <asp:TextBox runat="server" placeholder="Title of Album" CssClass="form-control" ID="tbTitle" ValidationGroup="1"></asp:TextBox>
                </div>
            </div>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbTitle" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
              <br />
              <div class="row">
                   <div class="col-lg-6">
                       <label style="position:center;"><input id="user_lic" type="number" min="5" max="100" step="5" value ="5"/></label>
                   </div>
              </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Button runat="server" Text="Dodadi" CssClass="btn btn-success" ID="btAddAlbum" OnClick="btAddAlbum_Click"></asp:Button>
                </div>
            </div>
         </div>
    </form>
</body>
</html>
