<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="transakciiElementHalfProdavam.ascx.cs" Inherits="IT_Proekt.transakciiElementHalfProdavam" %>


<div id="TransakciiContainer" class="">  <!-- Функционира само над 500px. Централен во една страна -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                
                <div class="col-sm-8 col-sm-offset-2" id="offerElementContainer1">
                    <div class="offer" style="margin-right:7px">
                        <div class="row">
                            <div class="col-xs-6">
                                <asp:Label runat="server" ID="lblOfferName1" Text="OfferName"></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <div class="row">
                                    <div class="col-lg-8" style="padding-left:0px">
                                        <asp:Label runat="server" ID="lblUserName1" Text="UserName"></asp:Label>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Label runat="server" ID="lblOfferDatum" Text="01.01.3000"></asp:Label>
                                    </div> 
                                </div>
                            </div>
                        </div>  
                                    
                        <div class="row" style="padding-top:15px">
                            <div class="col-xs-6">
                                <asp:Image ID="imgOfferPreview1" runat="server" height="200px" Width="155px"/>
                            </div>
                            <div class="col-xs-6" >                                                
                                <div class="row" style="padding-bottom:10px">
                                    <div class="col-xs-12" style="padding-left:0px">
                                        <asp:Label runat="server" ID="lblUserEmail1" Text="email@email.com"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <h4>Опис</h4>
                                </div>            
                                <div class="row">
                                    <div class="col-xs-12" style="padding-left:0px; height:100px">
                                        <asp:Label ID="lblOfferDescription1" CssClass="widthTextBox" runat="server">
                                            Lorem ipsum dolor sit amet, consectetur adipiscing elit
                                        </asp:Label>
                                    </div>
                                </div>                                                          
                                <div class="row" style="padding-bottom:10px">
                                    <div class="col-xs-1" style="padding-left:0px; padding-top:8px">
                                        <p>Цена:</p>
                                    </div>
                                    <div class="col-xs-3" style="padding-top:8px">
                                        <asp:Label ID="lblOfferPrice1" runat="server">10$</asp:Label>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Button runat="server" id="btnOfferCancel1" CssClass="btn btn-danger" Text="Откажи"/> 
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:Button runat="server" id="btnOfferBuy1" CssClass="btn btn-success" Text="Потврди"/> 
                                    </div>
                                </div>
                            </div>      
                        </div>                                          
                    </div>
                </div> <!-- end offerElementContainer1 -->
                
                <asp:Label ID="lblOffer1ID" runat="server" CssClass="displayNone"></asp:Label>

            </div>     
        </ContentTemplate>
    </asp:UpdatePanel>
</div><!--end TransakciiContainer-->
