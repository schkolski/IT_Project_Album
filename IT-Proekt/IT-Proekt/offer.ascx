<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="offer.ascx.cs" Inherits="IT_Proekt.offer" %>


<div id="OfferContainer" class="container offer">  <!-- Функционира само над 768px -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>        
            <div class="row">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-12" style="font-size:20px">
                            <asp:Label ID="lblOfferName" runat="server" Text=""></asp:Label>
                        </div>   
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row" style="font-size:20px">
                        <div class="col-sm-3 ">
                            <asp:Label ID="lblOfferOwner" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-sm-3 col-sm-offset-6">
                            <asp:Label ID="lblOfferTrustLevel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row" style="padding-top:10px">
                        <div class="col-sm-12">
                            <p>Опис</p>
                            <asp:Label ID="lblOfferDescription" runat="server" Text=""></asp:Label>
                        </div>                                
                    </div>
                    <div class="row " style="padding-top:10px">
                        <div class="col-sm-2 " >
                            <p>Цена:</p>
                        </div>
                        <div class="col-sm-7">
                            <asp:Label ID="lblOfferPrice" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-sm-3 " >
                            <asp:Button runat="server" id="btnOfferBuy" CssClass="btn btn-success" Text="Купи"/>
                        </div>                                    
                    </div>
                </div>
            </div>                                     
        </ContentTemplate>
    </asp:UpdatePanel>   
</div>