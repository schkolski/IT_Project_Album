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
            .display-next
            {
             clear:both;
             display:block;
             float:left;
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
                            <li style="padding:5px;"><asp:TextBox runat="server" ID="tbUsernamelog" placeholder="Username"></asp:TextBox></li>
                            <li style="padding:5px;"><asp:TextBox runat="server" ID="tbPasslog" placeholder="Password"></asp:TextBox></li>
                            <li style="padding:5px;"><asp:Button href="#LogOut" runat="server" Text="Log in" CssClass="proba" ID="Login" OnClick="LogIn_Click" /></li>
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
                            <asp:TextBox runat="server" placeholder="Name" CssClass="form-control" ID="tbName"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox runat="server" placeholder="Username" CssClass="form-control" ID="tbUserReg"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName" ErrorMessage="Vnesete ime" ValidationGroup="1" CssClass="display-next"></asp:RequiredFieldValidator>
                    </div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbUserReg" ErrorMessage="Vnesete Username" ValidationGroup="1" CssClass="display-next"></asp:RequiredFieldValidator>
                    <br />
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:TextBox runat="server" placeholder="E-mail" CssClass="form-control" ID="tbEmail"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEmail" ErrorMessage="Vnesete Email" ValidationGroup="1" CssClass="display-next"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                <div class="row">
                        <div class="col-xs-12">
                            <asp:TextBox runat="server" placeholder="Password" CssClass="form-control" ID="tbPassReg"></asp:TextBox>
                        </div>
                    </div>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPassReg" ControlToValidate="tbPass" ErrorMessage="Passwordot ne se poklopuva" ValidationGroup="1" CssClass="display-next"></asp:CompareValidator>
                <div class="row">
                        <div class="col-xs-12">
                            <asp:TextBox runat="server" placeholder="Re-Password" CssClass="form-control" ID="tbPass"></asp:TextBox>
                        </div>
                    </div>
                    
                    <div class="row">
                        <div class="col-xs-12">
                            <h3>BirthDay</h3>
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
                            <asp:Panel runat="server" ID="panael">
                                <asp:RadioButton runat="server" Text="Male" ID="rbMale" ValidationGroup="1" GroupName="1"/>
                                <asp:RadioButton runat="server" Text="Female" ID="rbFemale" ValidationGroup="1" GroupName="1"/>
                            </asp:Panel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-6">
                        <asp:Button runat="server" Text="Sign Up"  CssClass="btn btn-success" OnClick="SignUp_Click" ID="btSignUp" ValidationGroup="1"/>
                        </div>
                    </div>
                </div>
            </div>
           
        </form>
        </body>
</html>
