<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="HtmlEscaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTML escaping</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="input"/>
        <asp:Button Text="Display" runat="server" ID="displayBtn" OnClick="displayBtn_Click"/>
        <br />
        <br />
        <span>Label control:  </span>
        <asp:Label Text="" runat="server" ID="outputLabel"/>
        <br />
        <span>Text box control:  </span>
        <asp:TextBox runat="server" ID="outputTextBox" ReadOnly="true" />
        <br />
        <span>Literal control:  </span>
        <asp:Literal Text="text" runat="server" ID="outputLiteral" Mode="Encode"/>
    </div>
    </form>
</body>
</html>
