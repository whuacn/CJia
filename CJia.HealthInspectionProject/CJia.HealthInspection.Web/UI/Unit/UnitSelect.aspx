<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitSelect.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.UnitSelect" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="../favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="pnl_Main" runat="server" />
        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            Height="" EnableLargeHeader="true" Title="单位查询统计" ShowBorder="false" ShowHeader="True"
            Layout="Fit">
            <Toolbars>
                <ext:Toolbar ID="tlr_Btn" runat="server">
                    <Items>
                      <%--  <ext:Button ID="btn_Add" Icon="DatabaseAdd" Text="新增" runat="server">
                        </ext:Button>--%>
                        <ext:Button ID="btnDataBaseDelete" Icon="DatabaseDelete" ConfirmText="确定要删除选中行记录及其该行相关所有记录么？" Text="删除" runat="server" OnClick="btnDataBaseDelete_Click">
                        </ext:Button>
                       <%-- <ext:Button ID="btn_Search" Icon="DatabaseConnect" Text="筛选" runat="server" OnClick="btn_Search_Click">
                        </ext:Button>
                        <ext:Button ID="btn_Export" Icon="DatabaseTable" Text="导出" runat="server" DisableControlBeforePostBack="false" EnableAjax="false">
                        </ext:Button>--%>
                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                        <ext:DropDownList ID="ddl_PageSize" AutoPostBack="true" Width="80" runat="server" OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged">
                            <ext:ListItem Text="每页10条" Value="10" />
                            <ext:ListItem Text="每页18条" Value="18" Selected="true" />
                            <ext:ListItem Text="每页30条" Value="30" />
                            <ext:ListItem Text="每页50条" Value="50" />
                        </ext:DropDownList>
                        <ext:Label ID="lbl_c" runat="server" Width="3"></ext:Label>
                        <ext:DropDownList ID="ddl_Search" AutoPostBack="true" Width="80"
                            runat="server">
                            <ext:ListItem Text="名称" Value="UnitName" />
                            <ext:ListItem Text="法人" Value="LegalPerson" />
                        </ext:DropDownList>
                        <ext:Label ID="lbl_r" runat="server" Width="3"></ext:Label>
                        <ext:TwinTriggerBox ID="btnSearch" runat="server" Width="150" EmptyText="输入要搜索的关键字"
                            ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="btnSearch_Trigger2Click">
                        </ext:TwinTriggerBox>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
            <Items>
                <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="18" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnRowCommand="gr_Main_RowCommand"
                DataKeyNames="UNIT_ID" AutoScroll="true" EnableRowDoubleClick="true" OnSort="gr_Main_Sort">
                <Columns>
                        <ext:BoundField HeaderText="单位名称" SortField="UNIT_NAME" DataField="UNIT_NAME" ExpandUnusedSpace="true" />
                        <ext:BoundField HeaderText="单位地址" SortField="UNIT_ADDRESS" DataField="UNIT_ADDRESS" />
                        <ext:BoundField HeaderText="负责人" SortField="RESPONSIBLE_PERSON" DataField="RESPONSIBLE_PERSON" />
                        <ext:BoundField HeaderText="证件号" SortField="UNIT_CODE" DataField="UNIT_CODE" />
                        <ext:BoundField Width="120px" HeaderText="添加时间" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                        <ext:BoundField Width="120px" HeaderText="更新时间" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="50px" CommandName="Edit" Text="编辑" />
                        <ext:LinkButtonField ConfirmText="确定要删除此记录么？" ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="50px" CommandName="Delete" Text="删除"/>
                </Columns>
                </ext:Grid>
            </Items>
        </ext:Panel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="880px" Height="550px">
        </ext:Window>
        <ext:Window ID="win_Search" Title="详细筛选" Hidden="true" Icon="ApplicationFormMagnify" Target="Self"
            runat="server" IsModal="true" CloseAction="HidePostBack" Width="600px" Height="332px">
            <Items>
                <ext:Panel ID="pnl_Search" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false" Height="300px" EnableBackgroundColor="true">
                    <Items>
                        <ext:Form ID="sf_Search" BodyPadding="25px 15px" LabelWidth="100" AutoScroll="true" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" runat="server">
                            <Rows>
                                <ext:FormRow ColumnWidths="50% 50%">
                                    <Items>
                                        <ext:TextBox ID="txt_NameD" runat="server" Label="名称" Text="">
                                        </ext:TextBox>
                                        <ext:NumberBox ID="txt_SortD" runat="server" Label="排序" Text="">
                                        </ext:NumberBox>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="50% 50%">
                                    <Items>
                                        <ext:DatePicker ID="dp_AddTimeD_Min" Label="添加时间-开始" runat="server">
                                        </ext:DatePicker>
                                        <ext:DatePicker ID="dp_AddTimeD_Max" Label="添加时间-结束" runat="server">
                                        </ext:DatePicker>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="50% 50%">
                                    <Items>
                                        <ext:DatePicker ID="dp_UpdateTimeD_Min" Label="更新时间-开始" runat="server">
                                        </ext:DatePicker>
                                        <ext:DatePicker ID="dp_UpdateTimeD_Max" Label="更新时间-结束" runat="server">
                                        </ext:DatePicker>
                                    </Items>
                                </ext:FormRow>
                            </Rows>
                        </ext:Form>
                    </Items>
                    <Toolbars>
                        <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                            <Items>
                                <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                                <ext:Button ID="btn_XSearch" Text="检索" ValidateForms="sf_Search" runat="server" Icon="TextRuler">
                                </ext:Button>
                                <ext:Button ID="btn_Return" Text="返回" runat="server" Icon="BulletGo">
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Toolbars>
                </ext:Panel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
