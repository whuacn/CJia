<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptUserManage.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.UI.DeptUserManage" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../../Css/main.css" />
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="180px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                    Layout="Fit" runat="server">
                    <Items>
                        <ext:Tree ID="tree_Main" runat="server" OnNodeCommand="tree_Main_NodeCommand" EnableArrows="true" ShowBorder="false" Title="组织结构" ShowHeader="true" AutoScroll="true" />
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="tlr_Btn" runat="server">
                                    <Items>
                                        <ext:Button ID="btn_Add_Dept" Icon="GroupAdd" Text="新增科室" runat="server" OnClick="btn_Add_Dept_Click">
                                        </ext:Button>
                                        <ext:Button ID="btn_Edit_Dept" Icon="GroupEdit" Text="修改科室" runat="server" OnClick="btn_Edit_Dept_Click">
                                        </ext:Button>
                                        <ext:Button ID="btn_Delete_Delt" Icon="GroupDelete" Text="删除科室" ConfirmText="是否删除该科室及其子科室？" runat="server" OnClick="btn_Delete_Delt_Click">
                                        </ext:Button>
                                        <ext:Button ID="btn_Add_User" Icon="UserAdd" Text="新增人员" runat="server" OnClick="btn_Add_User_Click">
                                        </ext:Button>
                                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnRowCommand="gr_Main_RowCommand" EnableRowNumber="True" OnSort="gr_Main_Sort" OnPageIndexChange="gr_Main_PageIndexChange"
                                    DataKeyNames="USER_ID,USER_CODE,USER_NAME,DEPT_ID" AutoScroll="true" EnableRowDoubleClick="true" EnableMultiSelect="false">
                                    <columns>          
                                    <ext:BoundField DataToolTipField="USER_CODE"  HeaderText="用户代码" SortField="USER_CODE" DataField="USER_CODE"  Width="100px" ExpandUnusedSpace="false" />                 
                                    <ext:BoundField DataToolTipField="USER_NAME"  HeaderText="用户名称" SortField="USER_NAME" DataField="USER_NAME"  Width="100px" ExpandUnusedSpace="false" />
                                    <ext:BoundField DataToolTipField="DEPT_NAME" Width="200px" HeaderText="部门" SortField="DEPT_NAME" DataField="DEPT_NAME" />
                                    <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Competence" HeaderText="&nbsp;" Width="80px" CommandName="Competence" Text="设置权限" />
                                    <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="35px" CommandName="Edit" Text="编辑" />
                                    <ext:LinkButtonField ConfirmText="确定要删除此记录及其相关所有记录么？" ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="35px" CommandName="Delete" Text="删除" />                            
                                </columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="400px" Height="200px">
        </ext:Window>
        <ext:Window ID="Window1" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="400px" Height="220px">
        </ext:Window>
        <ext:Window ID="Window2" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="900px" Height="500px">
        </ext:Window>
    </form>
</body>
</html>
