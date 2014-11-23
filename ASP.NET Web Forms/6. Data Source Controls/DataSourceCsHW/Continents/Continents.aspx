<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Continents.aspx.cs" Inherits="Continents.Continents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:EntityDataSource ID="EntityDataSourceContinents" runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False"
                EntitySetName="Continents" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
            </asp:EntityDataSource>
            <h2>Continents:</h2>
            <asp:ListBox ID="ListBoxContinents" runat="server"
                DataSourceID="EntityDataSourceContinents"
                DataTextField="Name"
                DataValueField="Id"
                AutoPostBack="true"></asp:ListBox>

            <asp:EntityDataSource ID="EntityDataSourceCountries" runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False"
                EntitySetName="Countries"
                Where="it.ContinentId=@Id" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter Name="Id" Type="Int32"
                        ControlID="ListBoxContinents" />
                </WhereParameters>
            </asp:EntityDataSource>

            <h2>Countries:</h2>
            <asp:GridView ID="GridViewCountries" runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id"
                DataSourceID="EntityDataSourceCountries"
                AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" ShowInsertButton="true" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                </Columns>
            </asp:GridView>


            <asp:EntityDataSource ID="EntityDataSourceCities" runat="server"
                ConnectionString="name=WorldEntities"
                DefaultContainerName="WorldEntities"
                EnableFlattening="False"
                EntitySetName="Cities"
                OrderBy="it.Name"
                Where="it.CountryId=@CountryId" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
                <WhereParameters>
                    <asp:ControlParameter Name="CountryId" Type="Int32"
                        ControlID="GridViewCountries" />
                </WhereParameters>
            </asp:EntityDataSource>

            <h2>Cities:</h2>
            <asp:ListView ID="ListViewCities" runat="server" DataSourceID="EntityDataSourceCities" DataKeyNames="Id">

                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("CountryId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>

                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("CountryId") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="ButtonEdit" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="ButtonInsert" runat="server" CommandName="New" Text="New" />
                            <asp:Button ID="ButtonDelete" runat="server" CommandName="Delete" Text="Delete" />
                        </td>
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                    <tr runat="server" style="">
                                        <th runat="server">Id</th>
                                        <th runat="server">Name</th>
                                        <th runat="server">Population</th>
                                        <th runat="server">CountryId</th>
                                        <th runat="server">Country</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:Button ID="ButtonInsertCustomer" Text="Insert" runat="server"
                                    OnClick="ButtonInsert_Click" />
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>


        </div>
    </form>
</body>
</html>
