<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CJia.Health.Web.UI.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Js/Main.js"></script>
    <script type="text/javascript">
        loadCss(top._skinId, 'Page.css');
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" ExpandDepth="1" ImageSet="XPFileExplorer" NodeIndent="15">
            <Nodes>
                <asp:TreeNode Text="病案查询" Value="病案查询" ImageUrl="~/images/Find_16x16.png">
                    <asp:TreeNode Text="查询病案" NavigateUrl="javascript:top.myTab.Cts('查询病案','QueryPatientView.aspx')" Value="查询病案" ImageUrl="~/images/Preview_16x16.png"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="病案管理" Value="病案管理" ImageUrl="~/images/Find_16x16.png">
                    <asp:TreeNode NavigateUrl="javascript:top.myTab.Cts(&#39;我的申请&#39;,&#39;MyApplyView.aspx&#39;)" Text="我的申请" Value="我的申请" ImageUrl="~/images/CustomerReports.Icon.png"></asp:TreeNode>
                    <%--<asp:TreeNode NavigateUrl="javascript:top.myTab.Cts(&#39;归还病案&#39;,&#39;Test.aspx&#39;,true)" Text="归还病案" Value="归还病案" ImageUrl="~/images/GoToPreviousHeaderFooter_16x16.png"></asp:TreeNode>--%>
                </asp:TreeNode>
                <asp:TreeNode Text="病案查阅" Value="病案查阅" ImageUrl="~/images/Find_16x16.png">
                    <asp:TreeNode NavigateUrl="javascript:top.myTab.Cts(&#39;我的借阅&#39;,&#39;MyBorrowView.aspx&#39;)" Text="我的借阅" Value="我的借阅" ImageUrl="~/images/ColumnsOne_16x16.png"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="javascript:top.myTab.Cts(&#39;查看病案&#39;,&#39;ReadBorrowView.aspx&#39;)" Text="查看病案" Value="查看病案" ImageUrl="~/images/book1.png"></asp:TreeNode>
                </asp:TreeNode>
                <%--<asp:TreeNode Text="归还管理" Value="归还管理" ImageUrl="~/images/Find_16x16.png">
                    <asp:TreeNode NavigateUrl="javascript:top.myTab.Cts(&#39;已归还&#39;,&#39;Test.aspx&#39;)" Text="已归还" Value="已归还" ImageUrl="~/images/AlignFloatingObjectTopCenter_16x16.png"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="javascript:top.myTab.Cts(&#39;待归还&#39;,&#39;Test.aspx&#39;)" Text="待归还" Value="待归还" ImageUrl="~/images/Bookmark_16x16.png"></asp:TreeNode>
                </asp:TreeNode>--%>
                <asp:TreeNode Text="个人中心" Value="个人中心" ImageUrl="~/images/Find_16x16.png">
                    <asp:TreeNode NavigateUrl="javascript:top.myTab.Cts(&#39;修改密码&#39;,&#39;EditPasswordView.aspx&#39;)" Text="修改密码" Value="修改密码" ImageUrl="~/images/richeditcontrol.png"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/LoginView.aspx" Text="退出系统" Value="退出系统" ImageUrl="~/images/Exit.png" Target="_top"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
        </asp:TreeView>
    </form>
</body>
</html>
