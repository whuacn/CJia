<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryDept.aspx.cs" Inherits="CJia.HealthInspection.Web.Dept.QueryDept" %>
<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="pnl_Main" runat="server" />
        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            Height="" EnableLargeHeader="true" Title="监督人员查询统计" ShowBorder="false" ShowHeader="True"
            Layout="Fit">
            <Toolbars>
                <ext:Toolbar ID="tlr_Btn" runat="server">
                    <Items>
                        <%--<ext:Button ID="btn_Add" Icon="DatabaseAdd" Text="新增" runat="server" OnClientClick="window.location.href="PublishTask.aspx";">
                        </ext:Button>--%>
                        <ext:Button ID="btnDataBaseDelete" Icon="DatabaseDelete" ConfirmText="确定要删除选中行记录及其该行相关所有记录么？" Text="删除" runat="server" OnClick="btnDataBaseDelete_Click">
                        </ext:Button>
                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                        <ext:DropDownList ID="dropPageSize" AutoPostBack="true" Width="80" runat="server" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged">
                            <ext:ListItem Text="每页10条" Value="10" />
                            <ext:ListItem Text="每页18条" Value="18" Selected="true" />
                            <ext:ListItem Text="每页30条" Value="30" />
                            <ext:ListItem Text="每页50条" Value="50" />
                        </ext:DropDownList>
                        <ext:Label ID="lbl_r" runat="server" Width="3"></ext:Label>
                        <ext:TwinTriggerBox ID="btnSearch" runat="server" Width="150" EmptyText="输入要搜索的关键字"
                            ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="btnSearch_Trigger2Click">
                        </ext:TwinTriggerBox>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
            <Items>
                <ext:Grid ID="gridDept" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="18" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" AutoHeight="true" OnRowCommand="gridDept_RowCommand"
                DataKeyNames="DEPT_ID" AutoScroll="true" EnableRowDoubleClick="true" OnSort="gr_Main_Sort">
                <Columns>
                        <ext:BoundField HeaderText="部门编号" SortField="DEPT_NO" DataField="DEPT_NO" />
                        <ext:BoundField HeaderText="部门名称" SortField="DEPT_NAME" DataField="DEPT_NAME" />
                        <ext:BoundField HeaderText="所属机构编号" SortField="ORGAN_NO" DataField="ORGAN_NO"/>
                        <ext:BoundField HeaderText="所属机构名称" SortField="ORGAN_NAME" DataField="ORGAN_NAME" ExpandUnusedSpace="true"/>
                        <ext:BoundField HeaderText="添加时间" Width="140px" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                        <ext:BoundField HeaderText="更新时间" Width="140px" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="50px" CommandName="Edit" Text="编辑" />
                        <ext:LinkButtonField ConfirmText="确定要删除此记录么？" ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="50px" CommandName="Delete" Text="删除"/>
                    </Columns>
                </ext:Grid>
            </Items>
        </ext:Panel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="880px" Height="550px">
        </ext:Window>
      
    </form>
</body>
</html>
