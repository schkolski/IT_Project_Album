﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="albumElement.ascx.cs" Inherits="IT_Proekt.albumElement" %>

<div id="albumContainer" class="">
    <!-- Функционира само над 768px -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">

                <div class="col-sm-6" id="albumElementContainer1">
                    <div class="offer" style="margin-right: 7px">
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

                        <div class="row" style="padding-top: 15px">
                            <div class="col-xs-6">
                                <asp:Image ID="imgAlbumElementPreview1" runat="server" Height="200px" Width="155px" />
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6" style="padding-left: 0px">
                                        <p>Количина</p>
                                    </div>
                                    <div class="col-sm-6" style="float: right">
                                        <asp:TextBox runat="server" ID="txbAlbumElementNumber1" Width="30px">0</asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-sm-offset-6" style="padding-top: 15px">
                                        <asp:Button CommandName="btnAlbumElementAdd1" ID="btnAlbumElementAdd1" runat="server" CssClass="btn btn-success" Text="Додај" OnClick="btnAlbumElementAdd1_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end albumElementContainer1 -->

                <div class="col-sm-6" id="albumElementContainer2">
                    <div class="offer" style="margin-right: 7px">
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

                        <div class="row" style="padding-top: 15px">
                            <div class="col-xs-6">
                                <asp:Image ID="imgAlbumElementPreview2" runat="server" Height="200px" Width="155px" />
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6" style="padding-left: 0px">
                                        <p>Количина</p>
                                    </div>
                                    <div class="col-sm-6" style="float: right">
                                        <asp:TextBox runat="server" ID="txbAlbumElementNumber2" Width="30px">0</asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6 col-sm-offset-6" style="padding-top: 15px">
                                        <asp:Button CommandName="btnAlbumElementAdd2" ID="btnAlbumElementAdd2" runat="server" CssClass="btn btn-success" Text="Додај" OnClick="btnAlbumElementAdd2_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end albumElementContainer2 -->

            </div>
            <!-- end row -->

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAlbumElementAdd1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAlbumElementAdd2" EventName="Click" />
        </Triggers>

    </asp:UpdatePanel>
</div>
<!-- end albumContainer -->
