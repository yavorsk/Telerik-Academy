<%@ Page Title="Edit Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="TopNews.Admin.EditCategories" %>

<asp:Content ID="EditCategoriesContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewEditCategories" runat="server"
        ItemType="TopNews.Models.Category"
        SelectMethod="ListViewEditCategories_GetData"
        DeleteMethod="ListViewEditCategories_DeleteItem"
        UpdateMethod="ListViewEditCategories_UpdateItem"
        InsertMethod="ListViewEditCategories_InsertItem"
        DataKeyNames="ID"
        InsertItemPosition="LastItem">
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton Text="Category Name" runat="server"
                    ID="LinkButtonSortByCategory"
                    CommandName="Sort"
                    CommandArgument="Name"
                    CssClass="btn btn-default" />
            </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
            <div class="row">
                <asp:DataPager runat="server" ID="DataPagerCategories"
                    PagedControlID="ListViewEditCategories"
                    PageSize="4">
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
                <div class="col-md-3">
                    <asp:Label Text="<%# Item.Name %>" runat="server" />
                </div>
                <asp:LinkButton runat="server" ID="LinkButtonEdit"
                    Text="Edit"
                    CommandName="Edit"
                    CssClass="btn btn-info" />
                <asp:LinkButton runat="server" ID="LinkButtonDelete"
                    Text="Delete"
                    CommandName="Delete"
                    CssClass="btn btn-danger" />
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:Panel runat="server" CssClass="row">
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoryName"
                        ControlToValidate="TextBoxName"
                        runat="server" Display="Dynamic"
                        Text="Required Field" ErrorMessage="Category name is required!"
                        ForeColor="Red" EnableClientScript="False"
                        ValidationGroup="ValidationGroupEdit" />
                </div>
                <asp:LinkButton runat="server" ID="LinkButtonSave"
                    Text="Save"
                    CommandName="Update"
                    CssClass="btn btn-info" OnClick="LinkButtonSave_Click"/>
                <asp:LinkButton runat="server" ID="LinkButtonCancel"
                    Text="Cancel"
                    CommandName="Cancel"
                    CssClass="btn btn-danger" />
            </asp:Panel>
        </EditItemTemplate>
        <InsertItemTemplate>
            <asp:Panel runat="server" CssClass="row">
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="TextBoxName" Text="<%#: BindItem.Name %>" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoryName"
                        ControlToValidate="TextBoxName"
                        runat="server" Display="Dynamic"
                        Text="Required Field" ErrorMessage="Category name is required!"
                        ForeColor="Red" EnableClientScript="False"
                        ValidationGroup="ValidationGroupInsert" />
                </div>
                <asp:LinkButton runat="server" ID="LinkButtonInsert"
                    Text="Save"
                    CommandName="Insert"
                    CssClass="btn btn-info" OnClick="LinkButtonInsert_Click"/>
                <asp:LinkButton runat="server" ID="LinkButtonDelete"
                    Text="Cancel"
                    CommandName="Cancel"
                    CssClass="btn btn-danger" />
            </asp:Panel>
        </InsertItemTemplate>
    </asp:ListView>
    <br />
    <br />
    <div class="back-link">
        <a href="/">Back to News</a>
    </div>
</asp:Content>
