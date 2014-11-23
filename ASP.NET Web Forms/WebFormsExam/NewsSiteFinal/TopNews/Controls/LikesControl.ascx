<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikesControl.ascx.cs" Inherits="TopNews.Controls.LikesControl" %>

<asp:UpdatePanel runat="server" ID="UpdatePanelUserControl"
    CssClass="like-control col-md-1" UpdateMode="Conditional" 
    ChildrenAsTriggers="true"
    style="align-content: center; text-align: center">
    <ContentTemplate>
        <asp:Button ID="ButtonLike" runat="server" Text="Like"
            OnClick="ButtonLike_Click" CssClass="btn btn-default" />
        <br />
        <asp:Label Text="" runat="server" ID="LabelLikesCount" Width="30px" />
        <br />
        <asp:Button ID="ButtonDislike" runat="server" Text="Dislike"
            OnClick="ButtonDislike_Click" CssClass="btn btn-default" />
    </ContentTemplate>
</asp:UpdatePanel>
