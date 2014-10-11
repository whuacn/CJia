<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkLoad.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.User.WorkLoad" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="tlr_Btn" runat="server">
                                    <Items>
                                        <ext:Label ID="Label3" runat="server" Width="55px" Text="选择时间"></ext:Label>
                                        <ext:DatePicker ID="dpkStart" runat="server"></ext:DatePicker>
                                        <ext:Label ID="Label7" runat="server" Width="4"></ext:Label>
                                        <ext:DatePicker ID="dpkEnd" runat="server"></ext:DatePicker>
                                         <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                        <ext:Label ID="Label6" runat="server" Width="6"></ext:Label>
                                        <ext:Label ID="Label1" runat="server" Width="30px" Text="分类"></ext:Label>
                                        <ext:DropDownList ID="dropBig" AutoPostBack="true" Width="170" runat="server" OnSelectedIndexChanged="dropBig_SelectedIndexChanged">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label4" runat="server" Width="6"></ext:Label>
                                        <ext:DropDownList ID="dropMiddle" AutoPostBack="true" runat="server" EnableSimulateTree="false" ShowRedStar="true" Width="170" OnSelectedIndexChanged="dropMiddle_SelectedIndexChanged">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label5" runat="server" Width="6"></ext:Label>
                                        <ext:DropDownList ID="dropSmall" runat="server" EnableSimulateTree="true" Width="170">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label2" runat="server" Width="6"></ext:Label>
                                       <ext:TextBox ID="txtContent" runat="server" EmptyText="输入要搜索的关键字">
                                       </ext:TextBox>
                                        <ext:Label ID="Label8" runat="server" Width="6"></ext:Label>
                                        <ext:Button runat="server" IconUrl="../../Icons/zoom.png" Text="查询" ID="btnSelect" Type="Button" OnClick="btnSelect_Click">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gridTemp" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange"
                                   OnSort="gr_Main_Sort" DataKeyNames="TEMPLATE_ID" AutoScroll="true">
                                    <Columns>
                                         <ext:BoundField DataToolTipField="TEMPLATE_NAME"  HeaderText="执行模块" SortField="TEMPLATE_NAME" DataField="TEMPLATE_NAME"/>
                                         <ext:BoundField DataToolTipField="SMALL_TEMPLATE_NAME" Width="140px" HeaderText="单位名称" DataField="SMALL_TEMPLATE_NAME" />
                                         <ext:BoundField HeaderText="执行人员" SortField="USER_NAME" DataField="USER_NAME"/>
                                         <ext:BoundField Width="120px" HeaderText="开始时间" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                                         <ext:BoundField Width="120px" HeaderText="结束时间" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                                         <ext:BoundField HeaderText="检查地点" SortField="USER_NAME" DataField="USER_NAME"/>
                                         <ext:BoundField HeaderText="是否要整改" SortField="USER_NAME" DataField="USER_NAME"/>
                                         <ext:BoundField HeaderText="是否复查" SortField="USER_NAME" DataField="USER_NAME"/>
                                         <ext:BoundField HeaderText="复查日期" SortField="USER_NAME" DataField="USER_NAME"/>
                                         <ext:BoundField HeaderText="整改情况" SortField="USER_NAME" DataField="USER_NAME"/>
                                         <ext:BoundField HeaderText="备注" SortField="USER_NAME" DataField="USER_NAME"/>
                                         <ext:BoundField HeaderText="检查结果" SortField="USER_NAME" DataField="USER_NAME"/>
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
