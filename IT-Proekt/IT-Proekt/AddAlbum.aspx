<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAlbum.aspx.cs" Inherits="IT_Proekt.AddAlbum" %>

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
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">

            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

                <a href="Default.aspx" class="navbar-brand">ИТ Проект </a>
            </div>

            <div id="navbar" class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>
                        <a href="Default.aspx">Дома </a></li>
                    <li class="active">
                        <a href="AddAlbum.aspx">Додади Албум </a></li>
                    <li>
                        <a href="MyOffers.aspx">Мои Понуди </a></li>
                    <li>
                        <a href="#Stats">Статистики </a>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="#Stats">Мои Информации </a>
                    </li>
                    <li>
                        <a href="#Stats">Одлогирај се </a>
                    </li>
                </ul>
            </div>
            <!--/.nav-collapse -->
        </div>
    </nav>
    <form id="fInsertAlbum" runat="server" visible="true">

        <div class="container" style="margin: auto; padding: 15%">
            <div class="row">
                <div class="col-lg-6">
                    <asp:TextBox runat="server" placeholder="Year" CssClass="form-control" ID="tbYear" ValidationGroup="1"></asp:TextBox>
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
                    <label style="position: center;">
                        <asp:TextBox ID="user_lic" TextMode="Number" runat="server" min="0" max="1000" step="1" /></label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Button runat="server" Text="Add album" CssClass="btn btn-success" ID="btAddAlbum" OnClick="btAddAlbum_Click"></asp:Button>

                </div>
            </div>
        </div>
    </form>


    <div class="container" style="margin: auto; padding: 15%;">
        <form style="border: dashed" id="fAddPicture" runat="server" visible="false">
            <div class="row">

                <div class="col-md-4 col-sm-4">
                    <asp:Image runat="server" ID="imgPrev" Width="150px" Height="200px" />
                </div>
                <div class="col-md-8 col-sm-8">


                    <fieldset>

                        <!-- Form Name -->
                        <legend>Picture informations
                            <code>
                                <asp:Label runat="server" ID="lblPictureRatio" Text="1/55"></asp:Label></code>
                        </legend>


                        <div class="row" style="margin: 10px;">
                            <b>
                                <asp:Label runat="server" ID="lblPictureID" Text="Picture ID: "></asp:Label></b>
                        </div>
                        <div class="row" style="margin: 10px;">
                            <b>
                                <asp:Label runat="server" ID="lblAlbumName" Text="Album: "></asp:Label></b>

                        </div>
                        <div class="row" style="margin: 10px;">
                            <b>
                                <asp:Label runat="server" ID="lblAlbumYear" Text="Year: "></asp:Label></b>
                        </div>
                        <div class="row" style="margin: 10px;">
                            <b>
                                <asp:Label runat="server" ID="lblPictureName" Text="Picture name:"></asp:Label></b>
                            <asp:TextBox ID="tbImgName" runat="server"></asp:TextBox>
                        </div>
                    </fieldset>
                </div>
            </div>
            <hr />
            <div class="row">

                <div class="col-md-4">
                    <asp:FileUpload runat="server" CssClass="filestyle" ID="ImageUpload" style="position: absolute; clip: rect(0px 0px 0px 0px);" />
                    
                    <div class="bootstrap-filestyle input-group " style="width: auto;">
                        <span class="group-span-filestyle " tabindex="0">
                            <label for="ImageUpload" class="btn btn-warning ">
                                <span class="icon-span-filestyle glyphicon glyphicon-folder-open"></span>
                                <span class="buttonText">Choose file</span>

                            </label>

                        </span>
                        <!-- Choose file - button  glyphicon glyphicon-forward-->
                    </div>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnPreview" runat="server" Text="Preview" CssClass="btn btn-info" OnClick="btnPreview_Click"/>
                </div>
                <div class="col-md-4" style="float: right">
                    <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-primary" OnClick="btnNext_Click"/>
                </div>
            </div>
        </form>
    </div>

    <asp:Label ID="lblTest" runat="server" Text="URL"></asp:Label>
</body>
</html>

