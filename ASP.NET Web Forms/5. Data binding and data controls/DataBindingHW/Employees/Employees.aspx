<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <div>
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" OnPageIndexChanging="GridViewEmployees_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:HyperLinkField Text="Employee Name" HeaderText="Full name" DataNavigateUrlFields="EmployeeID"
                        DataNavigateUrlFormatString="EmployeeDetails.aspx?id={0}" DataTextField="FullName"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
