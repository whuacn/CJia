<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyQuery.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.MyQuery" %>

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
    <form id="form1" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" Title="病人基本信息" ShowHeader="true" Layout="Row" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="Panel1" runat="server" ShowHeader="false" ShowBorder="false">
                            <Items>
                                <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    AutoScroll="true" LabelWidth="75px" BodyPadding="15px 15px" runat="server" EnableCollapse="True">
                                    <Rows>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:DatePicker ID="DatePicker1" Label="入院时间" runat="server"></ext:DatePicker>
                                                <ext:DatePicker ID="dp_start" Label="出院时间" runat="server"></ext:DatePicker>
                                                <ext:TextBox ID="txt_Task" AutoPostBack="true" runat="server" Label="住院号" MaxLength="100" Text=""></ext:TextBox>
                                                <ext:TextBox ID="TextBox1" AutoPostBack="true" runat="server" Label="病人名称" MaxLength="100" Text=""></ext:TextBox>
                                                <ext:DatePicker ID="DatePicker2" Label="出生日期" runat="server"></ext:DatePicker>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" Label="入院科室" EnableSimulateTree="true">
                                                    <ext:ListItem Text="无证" Value="0" />
                                                    <ext:ListItem Text="有证" Value="1" Selected="true" />
                                                    <ext:ListItem Text="不用发证" Value="2" />
                                                </ext:DropDownList>
                                                <ext:DropDownList ID="ddl_wuzheng" AutoPostBack="true" runat="server" Label="出院科室" EnableSimulateTree="true">
                                                    <ext:ListItem Text="无证" Value="0" />
                                                    <ext:ListItem Text="有证" Value="1" Selected="true" />
                                                    <ext:ListItem Text="不用发证" Value="2" />
                                                </ext:DropDownList>
                                                <ext:TextBox ID="TextBox3" AutoPostBack="true" runat="server" Label="出院诊断" MaxLength="100" Text=""></ext:TextBox>
                                                <ext:TextBox ID="TextBox4" AutoPostBack="true" runat="server" Label="手术名称" MaxLength="100" Text=""></ext:TextBox>
                                                <ext:Button ID="btnQuery" runat="server" Icon="SystemSearch" Text="查询"></ext:Button>
                                            </Items>
                                        </ext:FormRow>
                                       
                                    </Rows>
                                </ext:Form>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel2" runat="server" RowHeight="100%" Layout="Fit" ShowHeader="false">
                            <Items>
                                <ext:Grid ID="gr_Data" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                            IsDatabasePaging="true" DataKeyNames="DATA_ID" EnableCheckBoxSelect="true">
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
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
    </form>
</body>
</html>
