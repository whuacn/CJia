<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryTask.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Task.QueryTask" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <style type="text/css">
        .fontSize {
            font-size: 35px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="pnl_Main" runat="server" />
        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            Height="" EnableLargeHeader="true" Title="任务查询统计" ShowBorder="false" ShowHeader="True"
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
                        <ext:Label ID="Label1" runat="server" Width="3"></ext:Label>
                        <ext:DropDownList ID="dropTaskType" AutoPostBack="true" runat="server" Label="任务类型" ShowRedStar="true">
                        </ext:DropDownList>
                        <ext:Label ID="lbl_r" runat="server" Width="3"></ext:Label>
                        <ext:TwinTriggerBox ID="btnSearch" runat="server" Width="150" EmptyText="输入要搜索的关键字"
                            ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="btnSearch_Trigger2Click">
                        </ext:TwinTriggerBox>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
            <Items>
                <ext:Grid ID="gridTask" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="18" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                    IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" AutoHeight="true" OnRowCommand="gridTask_RowCommand"
                    DataKeyNames="TASK_ID" AutoScroll="true" EnableRowDoubleClick="true" OnSort="gr_Main_Sort">
                    <Columns>
                        <ext:BoundField HeaderText="任务名称" SortField="TASK_NAME" DataField="TASK_NAME" />
                        <ext:BoundField HeaderText="任务模版" SortField="TEMPLATE_NAME" DataField="TEMPLATE_NAME" />
                        <ext:BoundField HeaderText="任务类型" SortField="TASK_TYPE_NAME" DataField="TASK_TYPE_NAME" />
                        <ext:BoundField HeaderText="下达机构" SortField="ORGAN_NAME" DataField="ORGAN_NAME" />
                        <ext:BoundField HeaderText="开始时间" SortField="START_DATE" DataField="START_DATE" />
                        <ext:BoundField HeaderText="结束时间" SortField="END_DATE" DataField="END_DATE" />
                        <ext:BoundField HeaderText="检查范围" SortField="CHECK_SCODE" DataField="CHECK_SCODE" />
                        <ext:BoundField HeaderText="备注说明" SortField="REMARK" DataField="REMARK" />
                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbfFile" HeaderText="文件" Width="50px" CommandName="DownLoadFile" Text="查看" />
                        <ext:BoundField HeaderText="添加时间" Width="120px" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                        <ext:BoundField HeaderText="更新时间" Width="120px" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="50px" CommandName="Edit" Text="编辑" />
                        <ext:LinkButtonField ConfirmText="确定要删除此记录么？" ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="50px" CommandName="Delete" Text="删除" />
                    </Columns>
                </ext:Grid>
            </Items>
        </ext:Panel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="880px" Height="550px">
        </ext:Window>

        <ext:Window ID="winDownloadFiles" Hidden="true" EnableIFrame="true" Icon="PackageDown" Target="Parent" runat="server"
             IsModal="true" Width="500px" Height="320px">
        </ext:Window>
    </form>
</body>
</html>
