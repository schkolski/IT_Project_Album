<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Korisnici.ascx.cs" Inherits="IT_Proekt.Korisnici" %>
<div id="korisnici" class="" style="width:70%">  <!-- Функционира само над 768px -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>        
             <div class="row">
                 <div class="col-lg-6">
                     <asp:Label ID="tbName" runat="server" Text ="Пример"></asp:Label>
                 </div>
                 <div class="col-lg-6">
                      <asp:Button runat="server" ID="btPromeni" Text="Промени"/>
                 </div>
             </div>                                 
        </ContentTemplate>
    </asp:UpdatePanel>   
</div>