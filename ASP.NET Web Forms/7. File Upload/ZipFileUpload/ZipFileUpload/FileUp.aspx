<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUp.aspx.cs" Inherits="ZipFileUpload.FileUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FileUploadForm" runat="server">
        <asp:FileUpload ID="FileUploadControl" runat="server" />
        <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
        <br />
        <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
        <asp:Label runat="server" ID="File" Text="File: " />
    </form>
</body>
</html>
