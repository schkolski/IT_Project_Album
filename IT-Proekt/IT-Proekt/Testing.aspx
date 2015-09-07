<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="IT_Proekt.Testing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:FileUpload ID="fuPicture" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:TextBox ID="tbIdInput" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" Width="102px" />
        <br />
        <asp:Label ID="lblResponse" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Image ID="img1" runat="server" Height="130px" Width="120px" />
        <p>
            <asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" Text="Retrieve" />
            <asp:TextBox ID="tbId" runat="server"></asp:TextBox>
        </p>
        <asp:Image ID="img2" runat="server" Height="149px" Width="127px" />
    </form>
</body>
</html>
