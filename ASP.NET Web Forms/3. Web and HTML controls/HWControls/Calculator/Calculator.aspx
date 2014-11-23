<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <style>
        input {
            margin: 2px;
        }

        #inputBox {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" ID="inputContainer">
            <asp:TextBox runat="server" ID="inputBox" Text="0"/>
        </asp:Panel>
        <asp:Panel runat="server" ID="buttonsContainer">
            <asp:Button Text="1" runat="server" ID="btnOne" OnCommand="btnNum_Command" CommandName="1"/>
            <asp:Button Text="2" runat="server" ID="btnTwo" OnCommand="btnNum_Command" CommandName="2"/>
            <asp:Button Text="3" runat="server" ID="btnThree" OnCommand="btnNum_Command" CommandName="3"/>
            <asp:Button Text="+" runat="server" ID="btnPlus" OnCommand="btnOperator_Command" CommandName="plus" />
            <br />
            <asp:Button Text="4" runat="server" ID="btnFour" OnCommand="btnNum_Command" CommandName="4"/>
            <asp:Button Text="5" runat="server" ID="btnFive" OnCommand="btnNum_Command" CommandName="5"/>
            <asp:Button Text="6" runat="server" ID="btnSix" OnCommand="btnNum_Command" CommandName="6"/>
            <asp:Button Text="-" runat="server" ID="btnMinus" OnCommand="btnOperator_Command" CommandName="minus"/>
            <br />
            <asp:Button Text="7" runat="server" ID="btnSeven" OnCommand="btnNum_Command" CommandName="7"/>
            <asp:Button Text="8" runat="server" ID="btnEight" OnCommand="btnNum_Command" CommandName="8"/>
            <asp:Button Text="9" runat="server" ID="btnNine" OnCommand="btnNum_Command" CommandName="9"/>
            <asp:Button Text="x" runat="server" ID="btnMultiply" OnCommand="btnOperator_Command" CommandName="multiply"/>
            <br />
            <asp:Button Text="clear" runat="server" ID="btnClear" OnClick="btnClear_Click"/>
            <asp:Button Text="0" runat="server" ID="btnZero" OnCommand="btnNum_Command" CommandName="0"/>
            <asp:Button Text="/" runat="server" ID="btnDivide" OnCommand="btnOperator_Command" CommandName="divide"/>
            <asp:Button Text="" runat="server" ID="btnSqrt" OnCommand="btnOperator_Command" CommandName="sqrt"/>
        </asp:Panel>
        <asp:Panel runat="server" ID="enterContainer">
            <asp:Button Text="=" runat="server" ID="equalsBtn" Width="81px" OnClick="equalsBtn_Click"/>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
