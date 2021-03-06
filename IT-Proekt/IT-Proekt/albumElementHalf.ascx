﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="albumElementHalf.ascx.cs" Inherits="IT_Proekt.albumElementHalf" %>


<div id="albumContainer" class="">  <!-- Функционира само над 768px -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>                        
            <div class="row">

                <div class="col-sm-6" id="albumElementContainer1">
                    <div class="offer" style="margin-right:7px">
                        <div class="row">
                            <div class="col-sm-4 col-sm-offset-1">
                                <asp:Label runat="server" ID="lblAlbumElementID" Text="ID"></asp:Label>
                            </div>   
                            <div class="col-sm-4">
                                <asp:Label runat="server" ID="lblAlbumElementName" Text="Album"></asp:Label>
                            </div>
                            <div class="col-sm-3">
                                <asp:Label runat="server" ID="lblAlbumElementGodina" Text="Year"></asp:Label>
                                </div>
                        </div>  
                                    
                        <div class="row" style="padding-top:15px">
                            <div class="col-xs-6">
                                <asp:Image ID="imgAlbumElementPreview" runat="server" height="200px" Width="155px"/>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <div class="col-sm-6">                             
                                <div class="row">
                                    <div class="col-sm-6" style="padding-left:0px">
                                        <p>Количина</p>
                                    </div>
                                    <div class="col-sm-6" style="float:right">
                                        <asp:TextBox runat="server" ID="txbAlbumElementNumber" Width="30px">1</asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-sm-offset-6" style="padding-top:15px">
                                        <asp:Button CommandName="btnAlbumElementAdd" ID="btnAlbumElementAdd" runat="server" CssClass="btn btn-success" Text="Додај" OnClick="btnAlbumElementAdd_Click" /> 
                                    </div>
                                </div>
                            </div>      
                        </div>                                          
                    </div>
                </div> <!-- end albumElementContainer1 -->

                
            </div> <!-- end row -->
                                 
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAlbumElementAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div> <!-- end albumContainer -->