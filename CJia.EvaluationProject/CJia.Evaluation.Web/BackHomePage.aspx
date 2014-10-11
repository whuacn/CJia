<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackHomePage.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.BackHomePage" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>三甲医院评审资料管理系统</title>
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <script type="text/javascript" src="Js/BackMain.js"></script>
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
                                    <td style="width:70px;">
                                        <img src="../Images/hsz.png" height="65" width="65" title="" alt="" style="margin-top:2px;"/>
                                    </td>
                                    <td style="align-content:center;vertical-align:middle;width:600px;">
                                        <label>医院等级评审资料查阅系统</label>
                                    </td>
                                    <td>
                                    </td>
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
                                <%--<ext:Button ID="btn_EndLogin" Icon="BulletGo" Text="注销登录" runat="server" ConfirmText="确认要注销登录吗？"
                                     >
                                </ext:Button>--%>
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
                                <ext:AccordionPane ID="ap_MBasic" Icon="FolderWrench" Hidden="false" Expanded="true" Title="系统管理" runat="server" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MBasic" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode NodeID="node_DeptUser" Text="部门管理" IconUrl="Icons/user_home.png" NavigateUrl="BackStage/DeptUserManage.aspx">
                                                </ext:TreeNode><%--Icon="ApplicationSideTree"--%>
                                                <ext:TreeNode NodeID="node_ColumnManage" Text="栏目管理"  IconUrl="Icons/application_side_tree.png" NavigateUrl="BackStage/ColumEdit.aspx">
                                                </ext:TreeNode>
                                                <ext:TreeNode NodeID="node_TypeEdit" Text="类别维护" IconUrl="Icons/application_osx_cascade.png" NavigateUrl="BackStage/FileType.aspx">
                                                </ext:TreeNode>
                                                <ext:TreeNode NodeID="node_NoticeManage" Text="公告管理" IconUrl="Icons/bell.png" NavigateUrl="BackStage/PublishNotice.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MBusiness" Icon="FolderBell" runat="server" Hidden="false" Expanded="false" Title="档案管理" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MBusiness" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text="档案录入" NodeID="node_DataInput" IconUrl="Icons/database_yellow.png" NavigateUrl="BackStage/DataInput.aspx">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text="档案查询" NodeID="node_DataQuery" IconUrl="Icons/magnifier.png" NavigateUrl="BackStage/FileQuery.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MArticle" AutoScroll="true" Icon="FolderImage" runat="server" Expanded="false" Hidden="false" Title="评审管理" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MArticle" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode Text="档案申报" NodeID="node_DataDeclare" IconUrl="Icons/table_go.png" NavigateUrl="Backstage/CheckSubmitView.aspx?id=1">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text="档案评审" NodeID="node_DataReview" IconUrl="Icons/table_relationship.png" NavigateUrl="Backstage/CheckSubmitView.aspx?id=2">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text="档案查询" NodeID="node_ReviewQuery" IconUrl="Icons/table_column.png" NavigateUrl="Backstage/CheckSubmitView.aspx?id=3">
                                                </ext:TreeNode>
                                                <ext:TreeNode Text="档案统计" NodeID="node_ReviewStats" IconUrl="Icons/chart_bar.png" NavigateUrl="Backstage/ReviewChart.aspx">
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
                                <ext:Tab ID="tab_Home" Title="管理首页" Layout="Fit" Icon="House" runat="server">
                                    <Toolbars>
                                        <ext:Toolbar ID="tb_Tool" runat="server">
                                            <Items>
                                                <ext:ToolbarFill ID="tbf_htfill" runat="server">
                                                </ext:ToolbarFill>
                                                <ext:Button ID="btn_Reload" Icon="ArrowRefresh" Text="刷新窗口" runat="server">
                                                </ext:Button>
                                                <ext:Button ID="btn_SourceCode" OnClientClick="window.open('../Default.aspx', '_blank');e.stopEvent();"
                                                    Icon="WorldLink" Text="网站首页" EnablePostBack="false" runat="server">
                                                </ext:Button>
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
            tabs_Main: '<%= tabs_Main.ClientID %>'
        };
    </script>
</body>
</html>
