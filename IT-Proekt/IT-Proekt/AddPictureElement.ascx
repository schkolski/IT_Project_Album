<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddPictureElement.ascx.cs" Inherits="IT_Proekt.AddPictureElement" %>

<div id="albumContainer" class="">  <!-- Функционира само над 768px -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>                        
            <div class="row">

                <div class="col-sm-6" id="albumElementContainer1">
                    <div class="offer" style="margin-right:7px">
                        <div class="row">
                            <div class="col-sm-4 col-sm-offset-1">
                                <asp:Label runat="server" ID="lblAlbumElementID1" Text="ID"></asp:Label>
                            </div>   
                            <div class="col-sm-4">
                                <asp:Label runat="server" ID="lblAlbumElementName1" Text="Album"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label runat="server" ID="lblAlbumElementGodina1" Text="Year"></asp:Label>
                                </div>
                        </div>  
                                    
                        <div class="row" style="padding-top:15px">
                            <div class="col-xs-6">
                                <asp:Image ID="imgAlbumElementPreview1" runat="server" height="130px" Width="100%"/>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <asp:FileUpload ID="FileUploadLeft" runat="server" OnPreRender="FileUploadLeft_DataBinding" />
                                </div>            
                                <div class="row">
                                    <div class="col-sm-6 col-sm-offset-6" style="padding-top:15px">
                                        <asp:Button ID="btnAlbumElementAdd1" runat="server" CssClass="btn btn-success" Text="Додај во база" /> 
                                    </div>
                                </div>
                            </div>      
                        </div>                                          
                    </div>
                </div> <!-- end albumElementContainer1 -->

                <div class="col-sm-6" id="albumElementContainer2">
                    <div class="offer" style="margin-right:7px">
                        <div class="row">
                            <div class="col-sm-4 col-sm-offset-1">
                                <asp:Label runat="server" ID="lblAlbumElementID2" Text="ID"></asp:Label>
                            </div>   
                            <div class="col-sm-4">
                                <asp:Label runat="server" ID="lblAlbumElementName2" Text="Album"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label runat="server" ID="lblAlbumElementYear2" Text="Year"></asp:Label>
                                </div>
                        </div>  
                                    
                        <div class="row" style="padding-top:15px">
                            <div class="col-xs-6">
                                <asp:Image ID="imgAlbumElementPreview2" runat="server" height="130px" Width="100%"/>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <asp:FileUpload ID="FileUploadRight" runat="server" OnPreRender="FileUploadRight_DataBinding" />
                                </div>  
                                <div class="row">
                                    <div class="col-sm-6 col-sm-offset-6" style="padding-top:15px">
                                        <asp:Button ID="btnAlbumElementAdd2" runat="server" CssClass="btn btn-success" Text="Додај во база" /> 
                                    </div>
                                </div>
                            </div>      
                        </div>                                          
                    </div>
                </div> <!-- end albumElementContainer2 -->

            </div> <!-- end row -->
                                 
        </ContentTemplate>
    </asp:UpdatePanel>
</div> <!-- end albumContainer -->