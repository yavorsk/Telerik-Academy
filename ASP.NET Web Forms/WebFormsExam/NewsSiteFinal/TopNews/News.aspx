<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="TopNews.News" %>

<asp:Content ID="NewsContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: this.Title %></h1>

    <h2>Most popular articles</h2>

    <asp:ListView ID="ListViewPopularArticles" runat="server"
        ItemType="TopNews.Models.Article"
        SelectMethod="ListViewPopularArticles_GetData">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
        </LayoutTemplate>

        <ItemTemplate>
            <div class="row">
                <h3>
                    <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.ID) %>'
                        runat="server"
                        Text='<%# Item.Title %>' />
                    <small><%# Item.Category.Name %></small></h3>
                <p>
                    <%# GetContentPreview(Item) %>
                </p>
                <p>Likes: <%# GetLikes(Item) %></p>
                <div>
                    <i>by <%# Item.Author.UserName %></i>
                    <i>created on: <%# Item.DateCreated %></i>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <h2>All categories</h2>

    <asp:ListView ID="ListViewCategories" runat="server"
        ItemType="TopNews.Models.Category"
        GroupItemCount="2"
        SelectMethod="ListViewCategories_GetData">
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
            </div>
        </GroupTemplate>

        <ItemTemplate>
            <div class="col-md-6">
                <h3><%# Item.Name %></h3>
                <asp:ListView runat="server" ID="ListViewArticlesInCategories"
                    ItemType="TopNews.Models.Article"
                    DataSource="<%# GetLatestAticles(Item) %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}", Item.ID) %>' runat="server"
                                Text='<%# string.Format("<strong>{0}</strong> <i> by {1}</i>", Item.Title, Item.Author.UserName) %>' />
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No articles in this category.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
