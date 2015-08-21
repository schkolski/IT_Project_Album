<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IT_Proekt._Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
    
        <title>Sign up / Register page </title>
        <link href="Content/bootstrap.min.css" rel="stylesheet" />
        <link href="Content/homePage.css" rel="stylesheet" />
        <style>
            .proba
            {
                margin-bottom:10px;
            }
        </style>
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
                        <!--<ul class="nav navbar-nav">
                            <li class="active"><a href="#">Дома</a></li>
                            <li><asp:LinkButton href="#Album" runat="server" Text="Албум"></asp:LinkButton></li>
                            <li><asp:LinkButton href="#MyOffers" runat="server" Text="Мои Понуди"></asp:LinkButton></li>                                 
                            <li><asp:LinkButton href="#Stats" runat="server" Text="Статистики"></asp:LinkButton></li>           
                        </ul>
                            !-->
                        <ul class="nav navbar-nav navbar-right" style="margin-top:10px;">
                            <li><asp:Label runat="server" Text="Username:"></asp:Label></li>
                            <li><asp:TextBox runat="server"></asp:TextBox></li>
                            <li><asp:Label runat="server" Text="Password:"></asp:Label></li>
                            <li><asp:TextBox runat="server"></asp:TextBox></li>
                            <li><asp:LinkButton href="#LogOut" runat="server" Text="Log in" CssClass="proba"></asp:LinkButton></li>
                        </ul>
                          
                    </div> <!--/.nav-collapse -->
                </div>
            </nav>
        <div class="container">
            <div id="Left-Picture" style="float:left">
                <div>
                    <asp:Label runat="server" Text="Ova e tekst shto treba da bide levo"></asp:Label>
                </div>
            </div>
            <div id ="Right-Register" style="float:right">
                <br style="clear:both;"/>
                    <div class="row">
                        <div class="col-xs-12">
                            <h1> Sing up</h1>
                            <h2> Enjoy the Fun!!!</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" Text="Name" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" Text="Username" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:TextBox runat="server" Text="E-mail" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                <div class="row">
                        <div class="col-xs-12">
                            <asp:TextBox runat="server" Text="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                <div class="row">
                        <div class="col-xs-12">
                            <asp:TextBox runat="server" Text="Re-Password" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <h3>BirthDay</h3>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:DropDownList runat="server"></asp:DropDownList>
                            <asp:DropDownList runat="server"></asp:DropDownList>
                            <asp:DropDownList runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:Panel runat="server">
                                <asp:RadioButton runat="server" Text="Male"/>
                                <asp:RadioButton runat="server" Text="Female"/>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Button runat="server" Text="Sign Up"  CssClass="btn btn-success"/>
                    </div>
                </div>
            </div>
           
        </form>
        </body>
</html>
