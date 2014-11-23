<%@ Page Title="Edit Articles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="TopNews.Admin.EditArticles" %>

<asp:Content ID="EditArticlesContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewEditArticles" runat="server"
        ItemType="TopNews.Models.Article"
        SelectMethod="ListViewEditArticles_GetData"
        DeleteMethod="ListViewEditArticles_DeleteItem"
        UpdateMethod="ListViewEditArticles_UpdateItem"
        InsertMethod="ListViewEditArticles_InsertItem"
        DataKeyNames="ID"
        InsertItemPosition="None">
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton Text="Sort by Title" runat="server"
                    ID="LinkButtonSortByTitle"
                    CommandName="Sort"
                    CommandArgument="Title"
                    CssClass="col-md-2 btn btn-default" />
                <asp:LinkButton Text="Sort by Date" runat="server"
                    ID="LinkButtonSortByDate"
                    CommandName="Sort"
                    CommandArgument="DateCreated"
                    CssClass="col-md-2 btn btn-default" />
                <asp:LinkButton Text="Sort by Category" runat="server"
                    ID="LinkButtonSortByCategory"
                    CssClass="col-md-2 btn btn-default" />
                <asp:LinkButton Text="Sort by Likes" runat="server"
                    ID="LinkButtonSortByLikes"
                    CssClass="col-md-2 btn btn-default" />
            </div>
            
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />

            <asp:LinkButton Text="Insert new article" runat="server"
                ID="LinkButtonInsertNewArticle"
                CssClass="btn btn-info pull-right" 
                OnClick="LinkButtonInsertNewArticle_Click"/>
            <div class="row">
                <asp:DataPager runat="server" ID="DataPagerArticles"
                    PagedControlID="ListViewEditArticles"
                    PageSize="3">
                    <Fields>
                        <asp:NextPreviousPagerField ShowPreviousPageButton="true" ShowNextPageButton="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowNextPageButton="true" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>

        <ItemTemplate>
            <div class="row">
                <h3><%# Item.Title %>
                    <asp:LinkButton runat="server" ID="LinkButtonEditArticle"
                        Text="Edit"
                        CommandName="Edit"
                        CssClass="btn btn-info" />
                    <asp:LinkButton runat="server" ID="LinkButtonDeleteArticle"
                        Text="Delete"
                        CommandName="Delete"
                        CssClass="btn btn-danger" />
                </h3>
                <p>Category: <%# Item.Category.Name %></p>
                <p><%# GetContentPreview(Item) %></p>
                <p>Likes count: <%# GetLikes(Item) %></p>
                <div>
                    <i>by <%# Item.Author.UserName %></i>
                    <i>created on: <%# Item.DateCreated %></i>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <h3>
                    <asp:TextBox runat="server" ID="TextBoxTitle" Text="<%# BindItem.Title %>" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorArticleTitle"
                        ControlToValidate="TextBoxTitle"
                        runat="server" Display="Dynamic"
                        Text="Required Field" ErrorMessage="Title is required!"
                        ForeColor="Red" EnableClientScript="False" />
                    <asp:LinkButton runat="server" ID="LinkButtonSave"
                        Text="Save"
                        CommandName="Update"
                        CssClass="btn btn-success" />
                    <asp:LinkButton runat="server" ID="LinkButtonCancel"
                        Text="Cancel"
                        CommandName="Cancel"
                        CssClass="btn btn-danger" />
                </h3>
                <p>
                    Category: 
                    <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate"
                        DataTextField="Name"
                        DataValueField="ID"
                        ItemType="TopNews.Models.Category"
                        SelectedValue="<%#: BindItem.CategoryID %>"
                        SelectMethod="DropDownListCategoriesCreate_GetData">
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TextBoxContent"
                        TextMode="MultiLine"
                        Columns="100" Rows="5" Style="overflow: auto"
                        Text="<%#: BindItem.Content %>" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent"
                        ControlToValidate="TextBoxContent"
                        runat="server" Display="Dynamic"
                        Text="Required Field" ErrorMessage="Content is required!"
                        ForeColor="Red" EnableClientScript="False" />
                    <div>
                        <i>by <%# Item.Author.UserName %></i>
                        <i>created on: <%# Item.DateCreated %></i>
                    </div>
                </p>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <h3>Title:
                <asp:TextBox runat="server" ID="TextBoxInsertTitle" Text="<%#: BindItem.Title %>" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorArticleTitleInsert"
                    ControlToValidate="TextBoxInsertTitle"
                    runat="server" Display="Dynamic"
                    Text="Required Field" ErrorMessage="Title is required!"
                    ForeColor="Red" EnableClientScript="False" />
            </h3>
            <p>
                Category: 
                    <asp:DropDownList runat="server" ID="DropDownListCategoriesInsert"
                        DataTextField="Name"
                        DataValueField="ID"
                        ItemType="TopNews.Models.Category"
                        SelectedValue="<%#: BindItem.CategoryID %>"
                        SelectMethod="DropDownListCategoriesCreate_GetData">
                    </asp:DropDownList>
            </p>
            <p>
                <asp:TextBox runat="server" ID="TextBoxContentInsert"
                    TextMode="MultiLine"
                    Columns="60" Rows="5" Style="overflow: auto"
                    Text="<%#: BindItem.Content %>" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContentInsert"
                    ControlToValidate="TextBoxContentInsert"
                    runat="server" Display="Dynamic"
                    Text="Required Field" ErrorMessage="Content is required!"
                    ForeColor="Red" EnableClientScript="False" />
            </p>
            <asp:LinkButton runat="server" ID="LinkButtonSave"
                Text="Insert"
                CommandName="Insert"
                CssClass="btn btn-success" />
            <asp:LinkButton runat="server" ID="LinkButtonInsertArticleCancel"
                Text="Cancel"
                CommandName="Cancel"
                CssClass="btn btn-danger" 
                OnClick="LinkButtonInsertArticleCancel_Click"/>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
