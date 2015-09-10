<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="album_pictures.aspx.cs" Inherits="IT_Proekt.album_pictures" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/homePage.css" rel="stylesheet" />
    <script type="text/javascript">
        $(":file").filestyle({ input: false });

        function ShowPreview(input) {
            if (input.files && input.files[0]) {
                var ImageDir = new FileReader();
                ImageDir.onload = function (e) {
                    $('#imgPrev').attr('src', e.target.result);
                }
                ImageDir.readAsDataURL(input.files[0]);
            }
        }
    </script>
</head>
<body>
    <div class="container" style="margin: auto; padding: 15%;">
        <form style="border: dashed">
            <div class="row">

                <div class="col-md-4 col-sm-4">
                    <asp:Image runat="server" ID="imgPrev" Width="150px" Height="200px" />
                </div>
                <div class="col-md-8 col-sm-8">
                    <!--promena tuka-->

                    <fieldset>

                        <!-- Form Name -->
                        <legend>
                            Picture informations
                            <code><asp:Label runat="server" ID="lblPictureRatio" Text="1/55"></asp:Label></code>
                        </legend>


                        <div class="row" style="margin: 10px;">
                            <b>
                                <asp:Label runat="server" ID="lblAlbumElement" Text="Picture ID: "></asp:Label></b>
                        </div>
                        <div class="row" style="margin: 10px;">
                            <b>
                                <asp:Label runat="server" ID="lblAlbumElementN" Text="Album: "></asp:Label></b>

                        </div>
                        <div class="row" style="margin: 10px;">
                            <b>
                                <asp:Label runat="server" ID="lblAlbumElementGod1" Text="Year: "></asp:Label></b>
                        </div>
                        <div class="row" style="margin: 10px;">
                            <b>
                                <asp:Label runat="server" ID="Label1" Text="Picture name:"></asp:Label></b>
                            <input type="text" id="tbPictureName" runat="server" />
                        </div>
                    </fieldset>
                </div>
            </div>
            <hr />
            <div class="row">

                <div class="col-md-4">

                    <input type="file" class="filestyle" data-input="false" name="ImageUpload" id="ImageUpload" style="position: absolute; clip: rect(0px 0px 0px 0px);" onchange="ShowPreview(this);" />
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
                <div class="col-md-4" style="float: right">
                    <input type="button" runat="server" id="btnNext" class="" data-input="false" value="Next" style="position: absolute; clip: rect(0px 0px 0px 0px);" />
                    <div class="bootstrap-filestyle input-group " style="width: auto; float: right">
                        <span class="group-span-filestyle " tabindex="0">
                            <label for="btnNext" class="btn btn-success ">
                                <span class="icon-span-filestyle glyphicon glyphicon-forward"></span>
                                <span class="buttonText">Next...</span>

                            </label>

                        </span>
                        <!-- Choose file - button  glyphicon glyphicon-forward-->
                    </div>
                </div>
            </div>
        </form>
    </div>

   
</body>
</html>



<!--
    
    
    
    -->
