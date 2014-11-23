<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterOffices.master" AutoEventWireup="true" CodeBehind="OfficesBulgaria.aspx.cs" Inherits="CompanySite.OfficesBulgaria" %>

<asp:Content ID="OfficesBulgariaContent" ContentPlaceHolderID="MainContentOffices" runat="server">
    <h3>Our offices in Bulgaria: </h3>
    <br />
    <ul>
        <li>
            <a runat="server" href="~/OfficeSofia.aspx">Sofia</a>
        </li>
        <li>
            <a runat="server" href="~/OfficeVarna.aspx">Varna</a>
        </li>
        <li>
            <a runat="server" href="~/OfficePlovdiv.aspx">Plovdiv</a>
        </li>
    </ul>
</asp:Content>
