<%@ Page Title="Article Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleDetails.aspx.cs" Inherits="TopNews.ArticleDetails" %>

<%@ Register Src="~/Controls/LikesControl.ascx" TagPrefix="UserControl" TagName="LikesControl" %>

<asp:Content ID="ArticleDetailsContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server"
        ID="FormViewArticle"
        ItemType="TopNews.Models.Article"
        SelectMethod="FormViewArticle_GetItem">
        <ItemTemplate>
            <%--<asp:UpdatePanel runat="server" ID="UpdatePanelUserControl"
                CssClass="like-control col-md-1" UpdateMode="Conditional">
                <ContentTemplate>
                    <UserControl:LikesControl runat="server" ID="LikesControl" Value="<%# GetLikes(Item) %>"
                        OnLikeUp="LikePlus"
                        OnLikeDown="LikeMinus" />
                    <asp:Label Text="<%#  %>" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>--%>
            <div class="like-control col-md-1">
                <UserControl:LikesControl runat="server" ID="LikesControl1" Value="<%# GetLikes(Item) %>"
                    OnLikeUp="LikePlus"
                    OnLikeDown="LikeMinus" />
            </div>
            <h2><%# Item.Title %> <small>Category: <%# Item.Category.Name %></small></h2>
            <p><%# Item.Content %></p>
            <p>
                <span>Author: <%# Item.Author.UserName %></span>
                <span class="pull-right"><%# Item.DateCreated %></span>
            </p>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
