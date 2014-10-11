<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectDept.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Supervise.SelectDept" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server"/>
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
                                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                        <ext:TwinTriggerBox ID="ttbSearch" runat="server" Width="150" EmptyText="输入要搜索的关键字"
                                            ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search" OnTrigger2Click="btnSearch_Trigger2Click">
                                        </ext:TwinTriggerBox>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gridDept" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" EnableCheckBoxSelect="true" OnSort="gr_Main_Sort" EnableMultiSelect="false"
                                     DataKeyNames="DEPT_ID" AutoScroll="true" EnableRowDoubleClick="true" OnRowDoubleClick="gridDept_RowDoubleClick">
                                    <Columns>
                                         <ext:BoundField DataToolTipField="DEPT_NO"  HeaderText="部门编号" SortField="DEPT_NO" DataField="DEPT_NO" ExpandUnusedSpace="true" />
                                         <ext:BoundField DataToolTipField="DEPT_NAME" Width="140px" HeaderText="部门名称" DataField="DEPT_NAME" />
                                         <ext:BoundField DataToolTipField="ORGAN_NO" Width="140px" HeaderText="组织编号" DataField="ORGAN_NO" />
                                         <ext:BoundField DataToolTipField="ORGAN_NAME" Width="140px" HeaderText="组织名称" DataField="ORGAN_NAME" />
                                         <ext:BoundField Width="120px" HeaderText="添加时间" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                                         <ext:BoundField Width="120px" HeaderText="更新时间" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                 <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                                    <Items>
                                 <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                                        <ext:Button ID="btnOk" Text="确定" OnClick="btnOk_Click" ValidateForms="sf_Edit" runat="server" Icon="Accept">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                   
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
    </form>
</body>
</html>
