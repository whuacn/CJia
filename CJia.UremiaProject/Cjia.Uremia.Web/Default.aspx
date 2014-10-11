<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CJia.Uremia.Web.Default" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>江西省尿毒症患者信息上报系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <script type="text/javascript" src="Js/main.js"></script>
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
                        <ext:ContentPanel ShowBorder="false" ShowHeader="false" ID="cpnl_Logo" runat="server">                        
                        <div style="font-weight: bold;height:100px; font-size:30px; color:#15428B; float:left;width:700px;padding:0 0 0 10px;">
                            <table>
                                <tr  style="height:100%;width:100%">
                                    <td style="width:70px;">
                                        <img src="Images/logo.jpg" height="65" width="65" title="" alt="" style="margin-top:2px;"/>
                                    </td>
                                    <td style="align-content:center;vertical-align:middle;width:600px;">
                                        <label>江西省尿毒症患者信息上报系统</label>
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
                    Title="功能菜单" Icon="Outline" Margins="0 0 5 5" Layout="Fit" Position="Left" runat="server">
                    <Toolbars>
                        <ext:Toolbar ID="tbr_menu" Position="Bottom" runat="server">
                            <Items>
                                <ext:ToolbarFill ID="tf_m" runat="server">
                                </ext:ToolbarFill>
                                <ext:Button ID="btn_ReloadMenu" IconUrl="Images/reload.png" Text="刷新" runat="server" OnClick="btn_ReloadMenu_Click">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Toolbars>
                    <Items>
                        <ext:Accordion ID="ad_Main" runat="server" ShowHeader="false" ShowBorder="false" BodyPadding="2px">
                            <Panes>
                                <ext:AccordionPane ID="ap_MBasic" Icon="FolderWrench" Expanded="true"  Title="单位管理" runat="server" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MBasic" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                          <Nodes>
                                                <ext:TreeNode NodeID="1_1" Text="新增单位" IconUrl="Icons/world_connect.png" NavigateUrl="UI/Unit/AddUnit.aspx">
                                                </ext:TreeNode>
                                                <ext:TreeNode NodeID="1_2" Text="单位管理" IconUrl="Icons/textfield_key.png" NavigateUrl="UI/Unit/UnitSelect.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MBusiness" Icon="FolderBell" runat="server" Hidden="true" Expanded="false"  Title="行政处罚" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MBusiness" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                            <Nodes>
                                                <ext:TreeNode NodeID="2_1" Text="执行监督" IconUrl="Icons/world_connect.png" NavigateUrl="UI/Supervise/Check.aspx">
                                                </ext:TreeNode>
                                                <ext:TreeNode NodeID="2_2" Text="执行任务" IconUrl="Icons/textfield_key.png" NavigateUrl="UI/UnitSelect.aspx">
                                                </ext:TreeNode>
                                                <ext:TreeNode NodeID="2_3" Text="监督记录" IconUrl="Icons/world_connect.png" NavigateUrl="UI/AddUnit.aspx">
                                                </ext:TreeNode>
                                                <ext:TreeNode NodeID="2_4" Text="任务记录" IconUrl="Icons/textfield_key.png" NavigateUrl="UI/UnitSelect.aspx">
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MArticle" AutoScroll="true" Icon="FolderImage" runat="server" Expanded="false" Hidden="true" Title="模板管理" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MArticle" runat="server" ShowBorder="false" ShowHeader="false"   AutoScroll="true">
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MInfo" AutoScroll="true" Icon="FolderPage" runat="server" Hidden="true" Expanded="false" Title="任务管理" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MInfo" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MGoods" AutoScroll="true" Icon="FolderPalette" runat="server" Hidden="true" Expanded="false" Title="题目管理" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MGoods" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                 <ext:AccordionPane ID="ap_MDept" AutoScroll="true" Icon="FolderLink" Hidden="true" runat="server" Expanded="false" Title="部门管理" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MDept" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                          
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MUser" Icon="FolderUser" runat="server" Hidden="true" Expanded="false" Title="法律法规" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MUser" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                           
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_MSystem" Icon="FolderDatabase" runat="server" Hidden="true" Expanded="false" Title="系统设置" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_MSystem" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                           
                                        </ext:Tree>
                                    </Items>
                                </ext:AccordionPane>
                                <ext:AccordionPane ID="ap_Suppter" Icon="FolderStar" runat="server" Hidden="true" Expanded="false" Title="超级设置" Layout="Fit">
                                    <Items>
                                        <ext:Tree ID="tree_Suppter" runat="server" ShowBorder="false" ShowHeader="false" AutoScroll="true">
                                           
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
                                                <ext:Button ID="btn_Reload" Icon="ArrowRefresh" Text="刷新窗口" runat="server" OnClick="btn_Reload_Click">
                                                </ext:Button>
                                                <ext:Button ID="btn_SourceCode" OnClientClick="window.open('../Default.aspx', '_blank');e.stopEvent();"
                                                    Icon="WorldLink" Text="网站首页" EnablePostBack="false" runat="server">
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </Toolbars>
                                    <Items>
                                        <ext:ContentPanel ID="ct_Home" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px" AutoScroll="true">
                                        
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
            tree_MInfo: '<%= tree_MInfo.ClientID %>',
            tree_MGoods: '<%= tree_MGoods.ClientID %>',
            tree_MDept: '<%= tree_MDept.ClientID %>',
            tree_MUser: '<%= tree_MUser.ClientID %>',
            tree_MSystem: '<%= tree_MSystem.ClientID %>',
            tree_Suppter: '<%= tree_Suppter.ClientID %>',
            tabs_Main: '<%= tabs_Main.ClientID %>'
        };

    </script>
</body>
</html>
