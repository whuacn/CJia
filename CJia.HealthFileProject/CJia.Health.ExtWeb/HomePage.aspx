<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="CJia.Health.ExtWeb.HomePage" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>病案借阅申请系统</title>
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <script type="text/javascript" src="Js/Main.js"></script>
    <style type="text/css">
        .bg {
            background-color: blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="rgn_Top" Height="100px" ShowBorder="false" ShowHeader="false" Position="Top"
                    Layout="Fit" runat="server">
                    <Items>
                        <ext:ContentPanel CssClass="topBJ" ShowBorder="false" ShowHeader="false" ID="cpnl_Logo" runat="server" CssStyle="topBJ">                        
                        <div style="background-color:#007ACC; font-weight: bold;height:100px; font-size:30px; color:#ffffff; float:left;width:100%;">
                            <table>
                                <tr  style="height:100%;width:100%">
                                </tr>
                            </table>
                         </div>
                        <div style="float:right;padding:0 5px 0 0;"></div>
                        </ext:ContentPanel>
                    </Items>
                    <Toolbars>
                        <ext:Toolbar ID="tbr_b" Position="Bottom" runat="server">
                            <Items>
                                <ext:ToolbarSeparator ID="tbf_sepll" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Image ID="img_clock" Icon="Clock" runat="server"></ext:Image>
                                <ext:ToolbarText ID="tbt_Clock" runat="server"></ext:ToolbarText>
                                <ext:ToolbarSeparator ID="tbf_seplc" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Image ID="Image1" Icon="User" runat="server"></ext:Image>
                                <ext:ToolbarText ID="tbt_Info" runat="server"></ext:ToolbarText>
                                <ext:ToolbarFill ID="tbf_c" runat="server">
                                </ext:ToolbarFill>
                                <ext:ToolbarSeparator ID="tbf_seplrl" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Button ID="btn_UserInfo" Icon="User" Text="个人信息" runat="server">
                                </ext:Button>
                                <ext:ToolbarSeparator ID="tbf_seplrc" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Button ID="btn_ChangePassword" Icon="LockKey" Text="修改密码" runat="server">
                                </ext:Button>
                                <ext:ToolbarSeparator ID="tbf_seplrr" runat="server">
                                </ext:ToolbarSeparator>
                                <ext:Button ID="btn_EndLogin" IconUrl="Icons/zhuxiao.png" Text="注销登录" runat="server"
                                    OnClientClick="if(confirm('确认要注销登录吗？')) top.location='LoginView.aspx';">
                                </ext:Button>
                                <ext:ToolbarSeparator ID="tbf_seplr" runat="server">
                                </ext:ToolbarSeparator>
                            </Items>
                        </ext:Toolbar>
                    </Toolbars>
                </ext:Region>
                <ext:Region ID="ren_Left" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="180px" ShowHeader="true"
                    Title="功能菜单" Icon="Outline" Margins="0 0 5 5" Layout="Fit" Position="Left" runat="server" Collapsed="False">
                    <Items>
                        <ext:Accordion ID="ad_Main" runat="server" ShowHeader="false" ShowBorder="false" BodyPadding="2px">
                            <Panes>
                                <ext:AccordionPane ID="ap_MBasic" Icon="FolderWrench" Hidden="false" Expanded="true" Title="病案查询" runat="server" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MBasic" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode NodeID="node_DeptUser" Text="病案查询" IconUrl="Icons/user_home.png" NavigateUrl="UI/MyQuery.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                            <Nodes>
                                                <ext:TreeNode NodeID="node_MyReceipt" Text="我的申请" IconUrl="Icons/user_home.png" NavigateUrl="UI/MyReceipt.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                             <Nodes>
                                                <ext:TreeNode NodeID="node_MyBorrow" Text="我的借阅" IconUrl="Icons/user_home.png" NavigateUrl="UI/ReceiptFavorite.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                             <Nodes>
                                                <ext:TreeNode NodeID="node_MyFavorite" Text="我的收藏" IconUrl="Icons/user_home.png" NavigateUrl="UI/MyFavorite.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MBusiness" Icon="FolderBell" runat="server" Hidden="false" Expanded="false" Title="病案管理" Layout="Fit" Visible="false">
                                    <Items>
                                        <ext:Tree ID="tree_MBusiness" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text="我的申请" NodeID="node_DataInput" IconUrl="Icons/database_yellow.png" NavigateUrl="BackStage/DataInput.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MArticle" AutoScroll="true" Icon="FolderImage" runat="server" Expanded="false" Hidden="false" Title="病案查阅" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MArticle" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text="我的借阅" NodeID="node_DataDeclare" IconUrl="Icons/table_go.png" NavigateUrl="Backstage/CheckSubmitView.aspx?id=1">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text="查看病案" NodeID="node_DataReview" IconUrl="Icons/table_relationship.png" NavigateUrl="Backstage/CheckSubmitView.aspx?id=2">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MCenter" AutoScroll="true" Icon="FolderImage" runat="server" Expanded="false" Hidden="false" Title="个人中心" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MCenter" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text="我的收藏" NodeID="node_DataDeclare" IconUrl="Icons/table_go.png" NavigateUrl="Backstage/CheckSubmitView.aspx?id=1">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                            </Panes>
                        </ext:Accordion>
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="0 0 5 0"
                    runat="server">
                    <Items>
                        <ext:TabStrip ID="tabs_Main" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <ext:Tab ID="tab_Home" Title="首页" Layout="Fit" Icon="House" runat="server">
                                    <Toolbars>
                                        <ext:Toolbar ID="tb_Tool" runat="server">
                                            <Items>
                                                <ext:ToolbarFill ID="tbf_htfill" runat="server">
                                                </ext:ToolbarFill>
                                                <ext:Button ID="btn_Reload" runat="server">
                                                </ext:Button>
                                                <%--<ext:Button ID="btn_Reload" Icon="ArrowRefresh" Text="刷新窗口" runat="server">
                                                </ext:Button>--%>
                                                <%--<ext:Button ID="btn_SourceCode" OnClientClick="window.open('../Default.aspx', '_blank');e.stopEvent();"
                                                    Icon="WorldLink" Text="网站首页" EnablePostBack="false" runat="server">
                                                </ext:Button>--%>
                                            </Items>
                                        </ext:Toolbar>
                                    </Toolbars>
                                    <Items>
                                        <ext:ContentPanel ID="ct_Home" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px" AutoScroll="true">
                                        <%--<%=Caches.Config["Home"][0] %>--%>
                                        </ext:ContentPanel>
                                    </Items>
                                </ext:Tab>
                            </Tabs>
                        </ext:TabStrip>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_ChangePassword" Icon="LockKey" Title="修改密码" IFrameUrl="UI/ChangePassword.aspx" Hidden="true" EnableIFrame="true"
            Target="Parent" runat="server" IsModal="true" Width="350px" Height="170px">
        </ext:Window>
    </form>
    <script type="text/javascript">
        var IDS = {
            tree_MBasic: '<%= tree_MBasic.ClientID %>',
            tree_MBusiness: '<%= tree_MBusiness.ClientID %>',
            tree_MArticle: '<%= tree_MArticle.ClientID %>',
            tree_MCenter: '<%= tree_MCenter.ClientID %>',
            tabs_Main: '<%= tabs_Main.ClientID %>'
        };
    </script>
</body>
</html>
