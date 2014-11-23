<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSite.aspx.cs" Inherits="CarSite.CarSite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <strong>Producer: </strong>
        <asp:DropDownList ID="DropDownListProducer" runat="server" DataTextField="Name"
             OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        <strong>Models: </strong>
        <asp:DropDownList ID="DropDownListModels" runat="server" DataTextField="Name" >
        </asp:DropDownList>
        <br />
        <br />
        <strong>Extras: </strong>
        <asp:CheckBoxList ID="CheckBoxListExtras" runat="server" DataTextField="Name">
        </asp:CheckBoxList>
        <br />
        <strong>Engine type: </strong>
        <asp:RadioButtonList ID="RadioButtonListEngines" runat="server" RepeatDirection="Horizontal">
        </asp:RadioButtonList>
        <br />
        <asp:Button Text="Submit" runat="server" ID="submit" OnClick="submit_Click"/>
        <hr />
        <asp:Label Text="" runat="server" ID="submittedInfo"/>
    </div>
    </form>
</body>
</html>
