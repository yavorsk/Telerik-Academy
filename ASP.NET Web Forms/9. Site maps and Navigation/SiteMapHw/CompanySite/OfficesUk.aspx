<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterOffices.master" AutoEventWireup="true" CodeBehind="OfficesUk.aspx.cs" Inherits="CompanySite.OfficesUk" %>
<asp:Content ID="OfficesUkContent" ContentPlaceHolderID="MainContentOffices" runat="server">
    <h3>Our offices in the UK: </h3>
    <br />
    <ul>
        <li>
            <a runat="server" href="~/OfficeLondon.aspx">London</a>
        </li>
        <li>
            <a runat="server" href="~/OfficeBristol.aspx">Bristol</a>
        </li>
        <li>
            <a runat="server" href="~/OfficeManchester.aspx">Manchester</a>
        </li>
    </ul>
</asp:Content>
