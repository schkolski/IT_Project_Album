<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="transakciiElement.ascx.cs" Inherits="IT_Proekt.transakciiElement" %>


<div id="TransakciiContainer" class="">  <!-- Функционира само над 500px -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                
                <div class="col-sm-6" id="offerElementContainer1">
                    <div class="offer" style="margin-right:7px">
                        <div class="row">
                            <div class="col-xs-6">
                                <asp:Label runat="server" ID="lblOfferName1" Text="OfferName"></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <div class="row">
                                    <div class="col-lg-6" style="padding-left:0px">
                                        <asp:Label runat="server" ID="lblUserName1" Text="UserName"></asp:Label>
                                    </div>
                                    <div class="col-lg-6" style="padding-left:0px">
                                        <asp:Label runat="server" ID="lblUserEmail1" Text="email@email.com"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>  
                                    
                        <div class="row" style="padding-top:15px">
                            <div class="col-xs-6">
                                <asp:Image ID="imgOfferPreview1" runat="server" height="200px" Width="155px"/>
                            </div>
                            <div class="col-xs-6">
                                <div class="row">
                                    <h4>Опис</h4>
                                </div>            
                                <div class="row">
                                    <div class="col-xs-12" style="padding-left:0px; height:120px">
                                        <asp:Label ID="lblOfferDescription1" CssClass="widthTextBox" runat="server">
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit
                                        </asp:Label>
                                    </div>
                                </div>                
                                <div class="row" style="padding-bottom:10px">
                                    <div class="col-xs-3" style="padding-left:0px; padding-top:8px">
                                        <p>Цена:</p>
                                    </div>
                                    <div class="col-xs-3" style="padding-top:8px">
                                        <asp:Label ID="lblOfferPrice1" runat="server">10$</asp:Label>
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Button runat="server" id="btnOfferBuy1" CssClass="btn btn-success" Text="Потврди"/> 
                                    </div>
                                </div>
                            </div>      
                        </div>                                          
                    </div>
                </div> <!-- end offerElementContainer1 -->

                <div class="col-sm-6" id="offerElementContainer2">
                    <div class="offer" style="margin-right:7px">
                        <div class="row">
                            <div class="col-xs-6">
                                <asp:Label runat="server" ID="lblOfferName2" Text="OfferName"></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <div class="row">
                                    <div class="col-lg-6" style="padding-left:0px">
                                        <asp:Label runat="server" ID="lblUserName2" Text="UserName"></asp:Label>
                                    </div>
                                    <div class="col-lg-6" style="padding-left:0px">
                                        <asp:Label runat="server" ID="lblUserEmail2" Text="email@email.com"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>  
                        <div class="row" style="padding-top:15px">
                            <div class="col-xs-6">
                                <asp:Image ID="imgOfferPreview2" runat="server" height="200px" Width="155px"/>
                            </div>
                            <div class="col-xs-6">
                                <div class="row">
                                    <h4>Опис</h4>
                                </div>            
                                <div class="row">
                                    <div class="col-xs-12" style="padding-left:0px; height:120px">
                                        <asp:Label ID="lblOfferDescription2" CssClass="widthTextBox" runat="server">
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit
                                        </asp:Label>
                                    </div>
                                </div>                
                                <div class="row" style="padding-bottom:10px">
                                    <div class="col-xs-3" style="padding-left:0px; padding-top:8px">
                                        <p>Цена:</p>
                                    </div>
                                    <div class="col-xs-3" style="padding-top:8px">
                                        <asp:Label ID="lblOfferPrice2" runat="server">10$</asp:Label>
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:Button runat="server" id="btnOfferBuy2" CssClass="btn btn-success" Text="Потврди"/> 
                                    </div>
                                </div>
                            </div>      
                        </div>                                          
                    </div>
                </div> <!-- end offerElementContainer2 -->
                
                <asp:Label ID="lblOffer1ID" runat="server" CssClass="displayNone"></asp:Label>
                <asp:Label ID="lblOffer2ID" runat="server" CssClass="displayNone"></asp:Label>

            </div>     
        </ContentTemplate>
    </asp:UpdatePanel>
</div><!--end TransakciiContainer-->