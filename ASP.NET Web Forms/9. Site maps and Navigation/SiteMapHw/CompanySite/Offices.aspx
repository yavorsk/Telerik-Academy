<%@ Page Title="" Language="C#" MasterPageFile="~/NestedMasterOffices.master" AutoEventWireup="true" CodeBehind="Offices.aspx.cs" Inherits="CompanySite.Offices" %>

<asp:Content ID="OfficesContent" ContentPlaceHolderID="MainContentOffices" runat="server">
    <h3>Our offices: </h3>
    <br />
    <ul>
        <li>
            <a runat="server" href="~/OfficesBulgaria.aspx">Bulgaria</a>
        </li>
        <li>
            <a runat="server" href="~/OfficesUK.aspx">UK</a>
        </li>
    </ul>
</asp:Content>
