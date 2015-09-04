<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="myOffer.ascx.cs" Inherits="IT_Proekt.myOffer" %>


<div id="OfferContainer" class="container offer">  <!-- Функционира само над 768px -->
    <asp:UpdatePanel>
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-12" style="font-size:20px">
                            <asp:Label ID="lblOfferName" runat="server">Име на понуда</asp:Label>
                        </div>   
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3 ">
                            <asp:Button ID="btnOfferRefresh" runat="server" CssClass="btn btn-info" Text="Refresh" />
                        </div>
                        <div class="col-sm-3 col-sm-offset-6">
                            <asp:Button ID="btnOfferRemove" runat="server" CssClass="btn btn-danger" Text="Remove"/>
                        </div>
                    </div>
                    <div class="row" style="padding-top:10px">
                        <div class="col-sm-12">
                            <p>Опис</p>
                            <asp:Label ID="lblOfferDescription" CssClass="widthTextBox" runat="server">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            </asp:Label>
                        </div>                                
                    </div>
                    <div class="row " style="padding-top:10px">
                        <div class="col-sm-2 " >
                            <p>Цена:</p>
                        </div>
                        <div class="col-sm-7">
                            <asp:Label ID="lblOfferPrice" runat="server">10$</asp:Label>
                        </div>
                        <div class="col-sm-3 " >
                            <asp:Button runat="server" id="Button3" CssClass="btn btn-success" Text="Потврди"/>
                        </div>                                    
                    </div>
                </div>
            </div>     
        </ContentTemplate>
    </asp:UpdatePanel>
</div><!--end offerContainer-->
            