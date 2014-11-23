<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesInfo.aspx.cs" Inherits="EmpInfoRepeater.EmployeesInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="RepeaterEmployees" runat="server" ItemType="NorthwindData.Employee">
                <ItemTemplate>
                    <h3><%#: Item.FirstName + " " + Item.LastName %></h3>
                    <table border="1">
                        <tr>
                            <td>Birth date:</td>
                            <td><%#: Item.BirthDate%></td>
                        </tr>
                        <tr>
                            <td>Hire date:</td>
                            <td><%#: Item.HireDate%></td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td><%#: Item.Address%></td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td><%#: Item.City%></td>
                        </tr>
                        <tr>
                            <td>Region:</td>
                            <td><%#: Item.Region%></td>
                        </tr>
                        <tr>
                            <td>Country:</td>
                            <td><%#: Item.Country%></td>
                        </tr>
                        <tr>
                            <td>Home phone:</td>
                            <td><%#: Item.HomePhone%></td>
                        </tr>
                    </table>
                    <hr />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
