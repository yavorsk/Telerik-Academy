<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="Employees.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView ID="EmployeeDetailsView" runat="server" AutoGenerateRows="true"/>
        <asp:LinkButton Text="Back" runat="server" ID="backLink" OnClick="backLink_Click"/>
    </div>
    </form>
</body>
</html>
