<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumNums.aspx.cs" Inherits="SumNums.SumNums" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sum numbers</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label for="first-num">First Number</label>
        <input runat="server" id="firstNum" type="text" value="" />
        <br />
        <label for="second-num">Second Number</label>
        <input runat="server" id="secondNum" type="text" value="" />
        <br />
        <asp:Button ID="ButtonCalculateSum" runat="server" onclick="BtnOnCalculateSumClick" Text="Calculate Sum" />
    </div>
        <span>Result: </span>
        <span runat="server" id="result"></span>
    </form>
</body>
</html>
