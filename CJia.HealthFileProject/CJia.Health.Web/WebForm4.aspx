<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="CJia.Health.Web.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Image ID="Image1" ImageUrl="~/CheckCode.aspx" runat="server" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <img alt="" title="" src='CheckCode.aspx>' border="0" runat="server" />
        <asp:Image ID="Image2" ImageUrl="~/CheckCode.aspx" runat="server" />
    </div>
    </form>
</body>
</html>
