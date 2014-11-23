<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Events.Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageButton ImageUrl="http://blogs.telerik.com/images/default-source/miroslav-miroslav/super_ninja.png?sfvrsn=2"
            ID="telerikNinja" runat="server"
            OnClick="telerikNinja_Click" OnInit="telerikNinja_init" OnLoad="telerikNinja_Load" OnPreRender="telerikNinja_PreRender" />
    </div>
    </form>
</body>
</html>
