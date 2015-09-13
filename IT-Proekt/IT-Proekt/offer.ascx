<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="offer.ascx.cs" Inherits="IT_Proekt.offer" %>


<div id="OfferContainer" class="container offer" style="width:70%">  <!-- Функционира само над 768px -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>        
            <div class="row">
                <div class="col-sm-4">
                    <div class="row">
                        <div class="col-sm-4" style="font-size:12px">
                            <asp:Label ID="lblOfferName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4" style="font-size:12px">
                            <asp:Image ID="imgAlbumElementPreview1" runat="server" height="200px" Width="155px"/>
                        </div>
                    </div> 
                </div>
                <div class="col-sm-4" style="margin-left:10px;">
                    <div class="row" style="font-size:12px">
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
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class="col-sm-12" style=" margin-left:260px;" >
                            <asp:Button runat="server" id="btnOfferBuy" CommandName="btnOfferBuy" CssClass="btn btn-success" Text="Купи"/>
                            <asp:DropDownList runat="server" ID="ddZamena" CommandName="ddZamena" Visible="false" OnSelectedIndexChanged="ddZamena_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Button runat="server" id="exchange" CommandName="exchange" CssClass="btn btn-success" Text="Замени" OnClick="exchange_Click"/>
                           
                        </div>                                    
                    </div>
                </div>
            </div>                                     
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="exchange" EventName="Click" />
             <asp:AsyncPostBackTrigger ControlID="ddZamena" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnOfferBuy" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>   
</div>