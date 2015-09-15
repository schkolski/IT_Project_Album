<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IT_Proekt._Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Sign up / Register page </title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/homePage.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"/>
    <script src="Scripts/js/bootstrap-datepicker.js"></script>
    <script src="Scripts/css/datepicker.css"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap-wizard/1.2/jquery.bootstrap.wizard.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.js"></script>
    
    <style>
        .proba {
            margin-bottom: 10px;
        }

        .display-next {
            clear: both;
            display: block;
            float: left;
        }
    </style>
    <script runat="server">
        void ValidateText(object source, ServerValidateEventArgs args)
        {
            Console.WriteLine("Vlegov");
            int day = 0;
            int year = 0;
            Int32.TryParse(ddDay.SelectedValue.ToString(), out day);
            Int32.TryParse(ddYear.SelectedValue.ToString(), out year);
            int month = ddMonth.SelectedIndex;
            Response.Write(day + " " + month + " " + year);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(" + day + " " + month + ")", true);
            if (day >= 1 && day <= 31 && year >= 1900 && year <= 2015 && month >= 1 && month <= 12)
            {
                System.Diagnostics.Debug.WriteLine(day + " " + month + " " + year);
                Response.Write("yes");
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
    </script>
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
    <style>
        .rotate45 {
    -webkit-transform: rotate(25deg);
    -moz-transform: rotate(25deg);
    -o-transform: rotate(25deg);
    -ms-transform: rotate(25deg);
    transform: rotate(25deg);
}
    </style>
</head>
<body style="background-color:darkgrey">
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
                </div>

                <div id="navbar" class="navbar-collapse collapse">
                    <!--<ul class="nav navbar-nav">
                            <li class="active"><a href="#">Äîìà</a></li>
                            <li><asp:LinkButton href="#Album" runat="server" Text="Àëáóì"></asp:LinkButton></li>
                            <li><asp:LinkButton href="#MyOffers" runat="server" Text="Ìîè Ïîíóäè"></asp:LinkButton></li>                                 
                            <li><asp:LinkButton href="#Stats" runat="server" Text="Ñòàòèñòèêè"></asp:LinkButton></li>           
                        </ul>
                            !-->   
                    <ul class="nav navbar-nav navbar-right" style="margin-top: 10px;">
                        <li style="padding: 5px;">
                            <asp:TextBox runat="server" ID="tbUsernamelog" placeholder="Username"></asp:TextBox></li>
                        <li style="padding: 5px;">
                            <asp:TextBox runat="server" ID="tbPasslog" placeholder="Password" TextMode="Password"></asp:TextBox></li>
                        <li style="padding: 5px;">
                            <asp:Button href="#LogOut" runat="server" Text="Log in" CssClass="proba" ID="Login" OnClick="LogIn_Click" /></li>
                    </ul>
                    <div class="row">
                        <div class="col-lg-12 col-lg-offset-10">
                            <asp:Label runat="server" Text ="Погрешена лозинка или корисник" ID="lblError" ForeColor="Red" Visible="false"></asp:Label>
                        </div>
                    </div>
                    
                </div>
                <!--/.nav-collapse -->
            </div>
        </nav>
        <div class="container">
            <div id="Left-Picture" style="float: left; width:40%; padding-top:100px;">
                <div>
                    <img src="img/panini.jpg"  class="img-responsive img-rounded rotate45"/>
                </div>
            </div>
            <div id="Right-Register" style="float: right">
                <br style="clear: both;" />
                <div class="row">
                    <div class="col-xs-12">
                        <h1>Sing up</h1>
                        <h2>Enjoy the Fun!!!</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:TextBox runat="server" placeholder="Name" CssClass="form-control" ID="tbName"></asp:TextBox>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox runat="server" placeholder="Username" CssClass="form-control" ID="tbUserReg"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName" ErrorMessage="Vnesete ime" ValidationGroup="1" CssClass="display-next" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-6">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbUserReg" ErrorMessage="Vnesete Username" ValidationGroup="1" CssClass="display-next" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-12">
                        <asp:TextBox runat="server" placeholder="E-mail" CssClass="form-control" ID="tbEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbEmail" ErrorMessage="Vnesete Email" ValidationGroup="1" CssClass="display-next" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-12">
                        <asp:TextBox runat="server" placeholder="Password" CssClass="form-control" ID="tbPassReg" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbPass" ControlToValidate="tbPassReg" ErrorMessage="Passwordot ne se poklopuva" ValidationGroup="1" CssClass="display-next" ForeColor="Red"></asp:CompareValidator>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:TextBox runat="server" placeholder="Re-Password" CssClass="form-control" ID="tbPass" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <h3>BirthDay</h3>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12">
                        <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle" ID="ddMonth"></asp:DropDownList>
                        <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle" ID="ddDay"></asp:DropDownList>
                        <asp:DropDownList runat="server" CssClass="btn btn-default dropdown-toggle" ID="ddYear"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <asp:CustomValidator ID="rvDatum" runat="server" ErrorMessage="Vnesete datum" OnServerValidate="ValidateText" ControlToValidate="ddYear" ValidationGroup="1"></asp:CustomValidator>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-12">
                        <asp:Panel runat="server" ID="panael">
                            <asp:RadioButton runat="server" Text="Male" ID="rbMale" ValidationGroup="1" GroupName="1" Checked="True" />
                            <asp:RadioButton runat="server" Text="Female" ID="rbFemale" ValidationGroup="1" GroupName="1" />
                        </asp:Panel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:Button runat="server" Text="Sign Up" CssClass="btn btn-success" OnClick="SignUp_Click" ID="btSignUp" ValidationGroup="1" />
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
