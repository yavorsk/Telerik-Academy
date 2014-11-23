<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNums.aspx.cs" Inherits="RandomNums.RandomNums" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random number generator</title>
    <style>
        input {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 40px">
        <asp:Label ID="labelLowBound" runat="server" AssociatedControlID="lowBoundInput" Text="Lower bound"></asp:Label>
        <asp:TextBox ID="lowBoundInput" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="labelUpBound" runat="server" AssociatedControlID="upBoundInput" Enabled="False" Text="Upper bound"></asp:Label>
        <asp:TextBox ID="upBoundInput" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="generateRandom" runat="server" Text="Generate" OnClick="generateRandom_Click"/>
        <br />
        <br />
        <asp:TextBox ID="output" runat="server" ReadOnly="True"></asp:TextBox>
    </div>
    </form>
</body>
</html>
