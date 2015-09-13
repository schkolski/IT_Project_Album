<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="offer.ascx.cs" Inherits="IT_Proekt.offer" %>


<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="row">

            <div class="col-sm-8 col-sm-offset-2" id="offerElementContainer1">
                <div class="offer" style="margin-right: 7px">
                    <div class="row">
                        <div class="col-xs-6">
                            <asp:Label runat="server" ID="lblOfferName" Text="OfferName"></asp:Label>
                        </div>
                        <div class="col-xs-6">
                            <div class="row">
                                <div class="col-lg-8" style="padding-left: 0px">
                                    <asp:Label runat="server" ID="lblUserName" Text="UserName"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:Label runat="server" ID="lblOfferDatum" Text="01.01.3000"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row" style="padding-top: 15px">
                        <div class="col-xs-6">
                            <asp:Image ID="imgOfferPreview" runat="server" Height="200px" Width="155px" />
                        </div>
                        <div class="col-xs-6">
                            <div class="row" style="padding-bottom: 10px">
                                <div class="col-xs-12" style="padding-left: 0px">
                                    <asp:Label runat="server" ID="lblOfferOwner" Text="email@email.com"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <h4>Опис</h4>
                            </div>
                            <div class="row">
                                <div class="col-xs-12" style="padding-left: 0px; height: 100px">
                                    <asp:Label ID="lblOfferDescription" CssClass="widthTextBox" runat="server">
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit
                                    </asp:Label>
                                </div>
                            </div>
                            <div class="row" style="padding-bottom: 10px">
                                <div class="col-xs-1" style="padding-left: 0px; padding-top: 8px">
                                    <p>Цена:</p>
                                </div>
                                <div class="col-xs-1" style="padding-top: 8px">
                                    <asp:Label ID="lblOfferPrice" runat="server">10$</asp:Label>
                                </div>
                                <div class="col-xs-10">
                                    <asp:Button runat="server" ID="btnOfferBuy" CommandName="btnOfferBuy" CssClass="btn btn-success" Text="Купи" OnClick="btnOfferBuy_Click"/>
                                    <asp:Button runat="server" ID="exchange" CommandName="exchange" CssClass="btn btn-success" Text="Замени" OnClick="exchange_Click" />
                                    <asp:DropDownList runat="server" ID="ddZamena"  Visible="false" OnSelectedIndexChanged="ddZamena_SelectedIndexChanged"  AutoPostBack="true" ></asp:DropDownList>
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
        <asp:AsyncPostBackTrigger ControlID="exchange" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOfferBuy" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddZamena" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
