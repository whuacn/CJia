<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptFavorite.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.ReceiptFavorite" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>病案借阅申请系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="pnl_Main" runat="server" />
        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            Height="" EnableLargeHeader="true" Title="借阅/收藏" ShowBorder="false" ShowHeader="True"
            Layout="Fit">
            <Toolbars>
                <ext:Toolbar ID="tlr_Btn" runat="server">
                    <Items>
                        <ext:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" Width="150px">
                            <ext:ListItem Text="<全部>" Value="0" Selected="true" />
                            <ext:ListItem Text="借阅" Value="1" Selected="false" />
                            <ext:ListItem Text="收藏" Value="2" Selected="false" />
                        </ext:DropDownList>
                        <ext:DropDownList ID="ddl_Data_Type" AutoPostBack="true" runat="server" Width="150px">
                            <ext:ListItem Text="<全部>" Value="0" Selected="true" />
                            <ext:ListItem Text="糖尿病" Value="1" Selected="false" />
                            <ext:ListItem Text="高血压" Value="2" Selected="false" />
                        </ext:DropDownList>
                        <ext:Button ID="btnQuery" runat="server" Icon="SystemSearch" Text="查询"></ext:Button>
                        <ext:Button ID="btnDataBaseDelete" Icon="DatabaseDelete" Text="图片弹框测试，实际用于GRID里的显示图片" runat="server" OnClick="btnDataBaseDelete_Click">
                        </ext:Button>
                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                        <ext:DropDownList ID="ddl_PageSize" AutoPostBack="true" Width="80" runat="server">
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
                            ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search">
                        </ext:TwinTriggerBox>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
            <Items>
                <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="18" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                    IsDatabasePaging="true"
                    DataKeyNames="UNIT_ID" AutoScroll="true" EnableRowDoubleClick="true">
                    <Columns>
                        <ext:BoundField DataToolTipField="DATA_NAME" HeaderText="病案号" SortField="DATA_NAME" DataField="DATA_NAME" Width="120px" />
                        <ext:BoundField DataToolTipField="TREE_PATH" HeaderText="病人ID" SortField="TREE_PATH" DataField="TREE_PATH" Width="120" />
                        <ext:BoundField DataToolTipField="TYPE_VALUE" Width="70px" HeaderText="入院次数" DataField="TYPE_VALUE" />
                        <ext:BoundField DataToolTipField="USER_NAME" Width="100px" HeaderText="病人姓名" DataField="USER_NAME" />
                        <ext:BoundField DataToolTipField="CREATER_DATE" HeaderText="性别" SortField="CREATER_DATE" DataField="CREATER_DATE" Width="60px" />
                        <ext:BoundField DataToolTipField="USER_NAME" Width="120px" HeaderText="入院日期" DataField="USER_NAME" />
                        <ext:BoundField DataToolTipField="CREATER_DATE" HeaderText="入院科室" SortField="CREATER_DATE" DataField="CREATER_DATE" Width="120px" />
                        <ext:BoundField DataToolTipField="USER_NAME" Width="120px" HeaderText="出院日期" DataField="USER_NAME" />
                        <ext:BoundField DataToolTipField="CREATER_DATE" HeaderText="出院科室" SortField="CREATER_DATE" DataField="CREATER_DATE" Width="120px" />
                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="60px" Icon="SystemSearch" CommandName="data_Query" />
                    </Columns>
                </ext:Grid>
            </Items>
        </ext:Panel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="1000px" Height="550px">
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
