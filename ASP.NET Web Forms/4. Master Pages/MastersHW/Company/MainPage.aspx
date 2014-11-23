<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" 
    Inherits="Company.MainPage" MasterPageFile="~/Site.Master"%>

<asp:Content ID="ContentPage" runat="server" ContentPlaceHolderID="ContentPlaceHolderPageContent">
    <h1 id="welcome-text">Welcome to My company web site</h1>
    <asp:HyperLink runat="server" NavigateUrl="~/bg/BgHome.aspx" Text="Site in bulgarian" />
    <br />
    <asp:HyperLink runat="server" NavigateUrl="~/en/EnHome.aspx" Text="Site in english" />
</asp:Content>
