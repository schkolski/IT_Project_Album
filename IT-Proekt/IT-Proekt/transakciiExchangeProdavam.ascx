﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="transakciiExchangeProdavam.ascx.cs" Inherits="IT_Proekt.transakciiExchangeElementHalfProdavam" %>


<div id="TransakciiContainer" class="">
    <!-- Функционира само над 500px. Централен во една страна -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">

                <div class="col-sm-8 col-sm-offset-2" id="offerElementContainer1">
                    <div class="offer" style="margin-right: 7px">
                        <div class="row">
                            <div class="col-xs-6">
                                <asp:Label runat="server" Font-Bold="true" ID="lblOfferName1" Text="OfferName"></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <div class="row">
                                    <div class="col-lg-8" style="padding-left: 0px">
                                        <p>
                                            <b>Корисничко име:</b>
                                            <asp:Label runat="server" ID="lblUserName1" Text="UserName"></asp:Label>
                                        </p>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label runat="server" ID="lblOfferDatum" Text="01.01.3000"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="padding-top: 15px">
                            <div class="col-xs-6">
                                <div class="row">
                                    <div class="col-sm-6" style="padding-left: 0px">
                                        <asp:Image ID="imgOfferPreview1" runat="server" Height="200px" Width="155px" />
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Image ID="imgOfferPreview2" runat="server" Height="200px" Width="155px" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-xs-6">
                                <div class="row" style="padding-bottom: 10px">
                                    <div class="col-xs-12" style="padding-left: 0px">

                                        <p>
                                            <b>Email: </b>
                                            <asp:Label runat="server" ID="lblUserEmail1" Text="email@email.com"></asp:Label>
                                        </p>

                                    </div>
                                </div>
                                <div class="row">
                                    <h4>Опис</h4>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12" style="padding-left: 0px; height: 50px">
                                        <asp:Label ID="lblOfferDescription1" Font-Italic="true" CssClass="widthTextBox" runat="server">
                                           Lorem ipsum dolor sit amet, consectetur adipiscing elit
                                        </asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12" style="padding-left: 0px; margin-top: 1px;">

                                        <p>
                                            <b>Замена за слика:
                                            <asp:Label ID="lblOfferPrice1" runat="server">10$</asp:Label>
                                            </b>
                                        </p>
                                    </div>
                                </div>
                                <div class="row" style="padding-bottom: 10px">
                                    <div class="col-xs-6">
                                        <asp:Button runat="server" CommandName="btnOfferCancel1" ID="btnOfferCancel1" CssClass="btn btn-danger" Text="Откажи" OnClick="btnOfferCancel1_Click" AutoPostBack="True" />
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Button runat="server" CommandName="btnOfferBuy1" ID="btnOfferBuy1" CssClass="btn btn-success" Text="Потврди" OnClick="btnOfferBuy1_Click" AutoPostBack="True" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- end offerElementContainer1 -->

                <asp:Label ID="lblOffer1ID" runat="server" CssClass="displayNone"></asp:Label>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnOfferCancel1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnOfferBuy1" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div>
<!--end TransakciiContainer-->
