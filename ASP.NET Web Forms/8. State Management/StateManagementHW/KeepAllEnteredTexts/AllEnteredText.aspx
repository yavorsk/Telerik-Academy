<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllEnteredText.aspx.cs" Inherits="KeepAllEnteredTexts.AllEnteredText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:TextBox runat="server" ID="InputTextBox"/>
        <asp:Button Text="AddText" runat="server" ID="ButtonAddLine" OnClick="ButtonAddLine_Click"/>
        <br />
        <br />
        <asp:Label Text="" runat="server" ID="OutputLabel"/>
    </form>
</body>
</html>
