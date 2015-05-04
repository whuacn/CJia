<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyReceipt.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.MyReceipt" %>

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
                <ext:Region ID="ren_Center" Title="申请单信息" ShowHeader="true" Layout="Row" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="Panel1" runat="server" ShowHeader="false" ShowBorder="false">
                            <Items>
                                <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    AutoScroll="true" LabelWidth="75px" BodyPadding="15px 15px" runat="server" EnableCollapse="True">
                                    <Rows>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:DatePicker ID="DatePicker1" Label="申请时间" runat="server"></ext:DatePicker>
                                                <ext:DatePicker ID="DatePicker3" Label="至" runat="server"></ext:DatePicker>
                                                <ext:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" Label="借阅状态" EnableSimulateTree="true">
                                                    <ext:ListItem Text="已申请" Value="0" />
                                                    <ext:ListItem Text="已审批" Value="1" Selected="true" />
                                                    <ext:ListItem Text="拒绝" Value="2" />
                                                </ext:DropDownList>
                                                <ext:Button ID="Button1" runat="server" Icon="SystemSearch" Text="查询"></ext:Button>
                                            </Items>
                                        </ext:FormRow>

                                    </Rows>
                                </ext:Form>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel2" runat="server" RowHeight="100%" Layout="Fit" ShowHeader="false" ShowBorder="false">
                            <Items>
                                <ext:Grid ID="gr_Data" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" DataKeyNames="DATA_ID" EnableCheckBoxSelect="true">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="DATA_NAME" HeaderText="借阅单号" SortField="DATA_NAME" DataField="DATA_NAME" Width="120px" />
                                        <ext:BoundField DataToolTipField="TREE_PATH" HeaderText="借阅医生" SortField="TREE_PATH" DataField="TREE_PATH" Width="120px" />
                                        <ext:BoundField DataToolTipField="TREE_PATH" HeaderText="借阅状态" SortField="TREE_PATH" DataField="TREE_PATH" Width="120px" />
                                        <ext:BoundField DataToolTipField="TYPE_VALUE" Width="200px" HeaderText="借阅原由说明" DataField="TYPE_VALUE" />
                                        <ext:BoundField DataToolTipField="USER_NAME" Width="100px" HeaderText="申请时间" DataField="USER_NAME" />
                                        <ext:BoundField DataToolTipField="CREATER_DATE" HeaderText="借阅时间" DataField="CREATER_DATE" Width="60px" />
                                        <ext:BoundField DataToolTipField="USER_NAME" Width="120px" HeaderText="归还时间" DataField="USER_NAME" />
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
