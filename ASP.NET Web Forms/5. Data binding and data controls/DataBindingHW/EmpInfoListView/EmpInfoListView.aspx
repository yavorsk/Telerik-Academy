<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpInfoListView.aspx.cs" Inherits="EmpInfoListView.EmpInfoListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListViewEmployees" runat="server" ItemType="NorthwindData.Employee"
                ItemPlaceholderID="employeePlaceholder">
                <LayoutTemplate>
                    <h2>Employees</h2>
                    <asp:PlaceHolder runat="server" ID="employeePlaceholder"></asp:PlaceHolder>
                </LayoutTemplate>

                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>

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
                </ItemTemplate>
            </asp:ListView>

            <asp:DataPager ID="DataPagerEmployees" runat="server"
                PagedControlID="ListViewEmployees" PageSize="2"
                QueryStringField="page">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </form>
</body>
</html>
