<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="Hello.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="inputName" runat="server" ></asp:TextBox>
        <br />
        <br />
        <asp:Button Text="Print" runat="server" ID="printBtn" OnClick="printBtn_Click"/>
        <br />
        <br />
        <asp:Label Text="" runat="server" ID="output"/>
    </div>
    </form>
</body>
</html>
