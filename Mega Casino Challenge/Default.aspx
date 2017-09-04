<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mega_Casino_Challenge.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="reel1" runat="server" />
        <asp:Image ID="reel2" runat="server" />
        <asp:Image ID="reel3" runat="server" />
        <br />
        <br />
        Your Bet:&nbsp;
        <asp:TextBox ID="playerBetTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull the Lever!" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        <br />
        Player&#39;s Money:
        <asp:Label ID="moneyLabel" runat="server"></asp:Label>
        <br />
        <br />
        1 Cherry - x2 Your Bet<br />
        2 Cherry - x3 Your Bet<br />
        3 Cherry - x4 Your Bet<br />
        <br />
        3 7&#39;s - Jackpot - x100 Your Bet<br />
        <br />
        HOWEVER<br />
        <br />
        If there&#39;s even one bar you win nothing.</div>
    </form>
</body>
</html>
