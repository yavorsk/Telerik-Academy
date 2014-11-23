<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNums.aspx.cs" Inherits="RandomHTMLControls.RandomNums" %>

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
        <label id="labelLowBound" runat="server" for="lowBoundInput">Lower bound</label>
        <input type="text" id="lowBoundInput" runat="server" />
        <br />
        <br />
        <label id="labelUpBound" runat="server" for="upBoundInput">Upper bound</label>
        <input type="text" id="upBoundInput" runat="server"/>
        <br />
        <br />
        <input  type="button" id="generateRandom" runat="server" value="Generate" onserverclick="generateRandom_Click"/>
        <br />
        <br />
        <input type="text" id="output" runat="server" disabled="disabled"/>
    </div>
    </form>
</body>
</html>
