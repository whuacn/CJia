<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuerySupervise.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Supervise.QuerySupervise" %>
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
                        <ext:Button ID="btnNewSupervise" Icon="DatabaseAdd" Text="新增" runat="server" OnClick="btnNewSupervise_Click">
                        </ext:Button>
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
                <ext:Grid ID="gridUser" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="18" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" AutoHeight="true" OnRowCommand="gridUser_RowCommand"
                DataKeyNames="USER_ID" AutoScroll="true" EnableRowDoubleClick="true" OnSort="gr_Main_Sort" OnPreRowDataBound="gridUser_PreRowDataBound">
                <Columns>
                        <ext:BoundField HeaderText="用户编号" Width="160px" SortField="USER_NO" DataField="USER_NO" />
                        <ext:BoundField HeaderText="用户名称" Width="160px" SortField="USER_NAME" DataField="USER_NAME" />
                        <ext:BoundField HeaderText="所属机构" ExpandUnusedSpace="true" SortField="ORGAN_NAME" DataField="ORGAN_NAME" />
                        <ext:BoundField HeaderText="用户类型" SortField="USER_TYPE_NAME" DataField="USER_TYPE_NAME" />
                        <ext:BoundField HeaderText="添加时间" Width="140px" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                        <ext:BoundField HeaderText="更新时间" Width="140px" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="50px" CommandName="Edit" Text="编辑" />
                        <ext:LinkButtonField ConfirmText="确定要删除此记录么？" ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="50px" CommandName="Delete" Text="删除"/>
                        <ext:BoundField HeaderText="" Width="140px"  ColumnID="user_type" SortField="USER_TYPE" DataField="USER_TYPE" Hidden="true"/>
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
