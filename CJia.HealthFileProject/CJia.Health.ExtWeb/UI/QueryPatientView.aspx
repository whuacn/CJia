<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryPatientView.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.QueryPatientView" %>

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
        <ext:PageManager ID="pm_Main" AutoSizePanelID="pnl_Main" runat="server" AjaxAspnetControls="img_PicD" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" Layout="Fit" EnableBackgroundColor="true" BodyPadding="0"
                            Height="80px" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false">
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Label ID="Label4" runat="server" Text="出院时间："></ext:Label>
                                        <ext:DatePicker ID="startDate" runat="server" Width="150px"></ext:DatePicker>
                                        <ext:Label ID="Label6" runat="server" Text="" Width="5px"></ext:Label>
                                        <ext:Label ID="Label5" runat="server" Text="至"></ext:Label>
                                        <ext:Label ID="Label7" runat="server" Text="" Width="5px"></ext:Label>
                                        <ext:DatePicker ID="endDate" runat="server" Width="150px"></ext:DatePicker>
                                        <ext:Label ID="Label9" runat="server" Text="" Width="30px"></ext:Label>
                                        <ext:Label ID="Label8" runat="server" Text="病案号："></ext:Label>
                                        <ext:TextBox ID="txtRecordNO" runat="server" Width="150px"></ext:TextBox>
                                        <ext:Label ID="Label10" runat="server" Text="" Width="30px"></ext:Label>
                                        <ext:Label ID="Label11" runat="server" Text="病人姓名："></ext:Label>
                                        <ext:TextBox ID="txtPatientName" runat="server" Width="150px"></ext:TextBox>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Panel ID="Panel1" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                                    Height="" EnableLargeHeader="true" Layout="Fit" ShowBorder="false" ShowHeader="false">
                                    <Toolbars>
                                        <ext:Toolbar runat="server">
                                            <Items>
                                                <ext:Label ID="Label1" runat="server" Text="入院科室： "></ext:Label>
                                                <ext:DropDownList ID="ddl_Data_Type" AutoPostBack="true" runat="server" Width="150px">
                                                </ext:DropDownList>
                                                <ext:Label ID="Label3" runat="server" Width="30px" Text=""></ext:Label>
                                                <ext:Label ID="Label2" runat="server" Text="出院科室："></ext:Label>
                                                <ext:DropDownList ID="ddl_Data_User" AutoPostBack="true" runat="server" Width="150px">
                                                </ext:DropDownList>
                                                <ext:Label ID="Label12" runat="server" Text="" Width="30px"></ext:Label>
                                                <ext:Label ID="Label13" runat="server" Text="出院诊断："></ext:Label>
                                                <ext:TextBox ID="txtZhengD" runat="server" Width="150px"></ext:TextBox>
                                                <ext:Label ID="Label14" runat="server" Text="" Width="30px"></ext:Label>
                                                <ext:Label ID="Label15" runat="server" Text="手术名称："></ext:Label>
                                                <ext:TextBox ID="txtShouSu" runat="server" Width="150px"></ext:TextBox>
                                                <ext:Label ID="Label16" runat="server" Text="" Width="10px"></ext:Label>
                                                <ext:Button ID="btnQuery" runat="server" Icon="SystemSearch" Text="查询"></ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </Toolbars>
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
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
    </form>
</body>
</html>
