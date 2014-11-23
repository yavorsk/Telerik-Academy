<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpsOrders.aspx.cs" Inherits="AsyncOrdersNW.EmpsOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager" runat="server" />

            <asp:EntityDataSource ID="EntityDataSourceEmployees" runat="server"
                ConnectionString="name=NorthwindEntities"
                DefaultContainerName="NorthwindEntities"
                EnableFlattening="False"
                EntitySetName="Employees">
            </asp:EntityDataSource>

            <h2>Employees</h2>
            <asp:GridView ID="GridViewEmployees" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="EmployeeID"
                DataSourceID="EntityDataSourceEmployees" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                    <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
                    <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
                </Columns>
            </asp:GridView>
            <br />
            <br />

            <asp:EntityDataSource ID="EntityDataSourceOrders" runat="server"
                ConnectionString="name=NorthwindEntities"
                DefaultContainerName="NorthwindEntities"
                EnableFlattening="False"
                EntitySetName="Orders"
                Where="it.EmployeeID=@EmpID">
                <WhereParameters>
                    <asp:ControlParameter Name="EmpID" Type="Int32"
                        ControlID="GridViewEmployees" />
                </WhereParameters>
            </asp:EntityDataSource>

            <h3>Orders:</h3>

            <asp:UpdatePanel runat="server" ID="UpdatePanelOrders" UpdateMode="Conditional" OnLoad="UpdatePanelOrders_Load" >
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridViewEmployees" EventName="SelectedIndexChanged" />
                </Triggers>

                <ContentTemplate>
                    <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderID" DataSourceID="EntityDataSourceOrders">
                        <Columns>
                            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                            <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" SortExpression="RequiredDate" />
                            <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" SortExpression="ShippedDate" />
                            <asp:BoundField DataField="Freight" HeaderText="Freight" SortExpression="Freight" />
                            <asp:BoundField DataField="ShipName" HeaderText="ShipName" SortExpression="ShipName" />
                            <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" SortExpression="ShipAddress" />
                            <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" SortExpression="ShipCity" />
                            <asp:BoundField DataField="ShipRegion" HeaderText="ShipRegion" SortExpression="ShipRegion" />
                            <asp:BoundField DataField="ShipPostalCode" HeaderText="ShipPostalCode" SortExpression="ShipPostalCode" />
                            <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" SortExpression="ShipCountry" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdateProgress ID="UpdateProgressOrders" runat="server" AssociatedUpdatePanelID="UpdatePanelOrders" >
                <ProgressTemplate>
                    <img src="loading.gif" alt="" />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </form>
</body>
</html>
