<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesSP.aspx.cs" Inherits="EmployeesSP.EmployeesSP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeID" 
                OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:HyperLinkField Text="Employee Name" HeaderText="Full name" DataTextField="FullName" />
                </Columns>
            </asp:GridView>

            <asp:FormView ID="FormViewEmployee" runat="server">
                <ItemTemplate>
                    <h3><%#: Eval("FirstName") + " " + Eval("LastName") %></h3>
                    <table border="1">
                        <tr>
                            <td>Birth date:</td>
                            <td><%#: Eval("BirthDate")%></td>
                        </tr>
                        <tr>
                            <td>Hire date:</td>
                            <td><%#: Eval("HireDate")%></td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td><%#: Eval("Address")%></td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td><%#: Eval("City")%></td>
                        </tr>
                        <tr>
                            <td>Region:</td>
                            <td><%#: Eval("Region")%></td>
                        </tr>
                        <tr>
                            <td>Country:</td>
                            <td><%#: Eval("Country")%></td>
                        </tr>
                        <tr>
                            <td>Home phone:</td>
                            <td><%#: Eval("HomePhone")%></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
