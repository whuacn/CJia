 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryExeTask.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.QueryCheckTask.QueryExeTask" %>
<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
</head>
<body>
    <form id="form1" runat="server">
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
                                        <ext:TextBox ID="txt_ExeTask" runat="server" Width="500px" CssClass="titleColor" EmptyText="填写单位名称,任务名称" Label="执行任务查询"></ext:TextBox>
                                        <ext:Button runat="server" IconUrl="../../Icons/zoom.png" Text="查询" ID="btnSerch" Type="Button" OnClick="btnSerch_Click">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gridExeTask" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true"   EnableRowNumber="True" OnPageIndexChange="gridCheck_PageIndexChange" OnRowCommand="gridCheck_RowCommand"
                                EnableCheckBoxSelect="true" OnSort="gridExeTask_Sort" EnableMultiSelect="false" DataKeyNames="EXETASK_ID,ORGAN_NAME" AutoScroll="true" EnableRowDoubleClick="true">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="UNIT_NAME"  HeaderText="单位名称" SortField="UNIT_NAME" DataField="UNIT_NAME" Width="300px" />
                                        <ext:BoundField DataToolTipField="TASK_NAME"  HeaderText="任务名称" DataField="TASK_NAME" ExpandUnusedSpace="true" SortField="TASK_NAME"/> 
                                        <ext:BoundField DataToolTipField="ORGAN_NAME" HeaderText="下达机关" DataField="ORGAN_NAME" SortField="ORGAN_NAME"/>  
                                        <ext:BoundField DataToolTipField="CHECK_SCODE"  HeaderText="检查范围" DataField="CHECK_SCODE" SortField="CHECK_SCODE" /> 
                                        <ext:BoundField DataToolTipField="START_DATETIME"  HeaderText="开始时间" DataField="START_DATETIME" SortField="START_DATETIME" DataFormatString="{0:yy-MM-dd}"/>
                                        <ext:BoundField DataToolTipField="END_DATETIME"  HeaderText="结束时间" DataField="END_DATETIME" SortField="END_DATETIME" DataFormatString="{0:yy-MM-dd}"/>
                                        <ext:BoundField DataToolTipField="CHECK_RESULT"  HeaderText="检查结果" SortField="CHECK_RESULT" DataField="CHECK_RESULT" />
                                        <ext:LinkButtonField HeaderText="&nbsp;" ColumnID="Check" Width="60px" CommandName="See" Text="查看" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="Window1" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit"  runat="server"
        Target="Parent"  Width="980px" Height="580px">
        </ext:Window>
    </form>
</body>
</html>
