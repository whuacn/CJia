<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectTask.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.ExeTask.SelectTask" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
                           <%-- <Toolbars>
                                <ext:Toolbar ID="tlr_Btn" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="单位查询条件"></ext:Label>
                                        <ext:TextBox ID="txt_Unit" runat="server" Width="500px" CssClass="titleColor" EmptyText="填写单位名称、单位地址、单位组织代码、法人作为关键字查询"></ext:TextBox>
                                        <ext:Button runat="server" IconUrl="../../Icons/zoom.png" Text="查询" ID="btnSerch" Type="Button" >
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>--%>
                            <Items>
                                <ext:Grid ID="gridTask" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnRowDoubleClick="gridTask_RowDoubleClick" OnPageIndexChange="gr_Main_PageIndexChange"
                                EnableCheckBoxSelect="true" OnSort="gr_Main_Sort" EnableMultiSelect="false" DataKeyNames="TASK_ID,TASK_NAME,TEMPLATE_ID" AutoScroll="true" EnableRowDoubleClick="true">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="TASK_NAME"  HeaderText="任务名称"  DataField="TASK_NAME" ExpandUnusedSpace="true" />
                                        <ext:BoundField DataToolTipField="START_DATE"  HeaderText="开始时间" DataField="START_DATE"  SortField="START_DATE"/> 
                                        <ext:BoundField DataToolTipField="END_DATE"  HeaderText="结束时间" DataField="END_DATE" SortField="END_DATE"/>
                                        <ext:BoundField DataToolTipField="CHECK_SCODE"  HeaderText="检查范围" DataField="CHECK_SCODE" />  
                                        <ext:BoundField DataToolTipField="REMARK" HeaderText="备注" DataField="REMARK" />  
                                        <ext:BoundField DataToolTipField="ORGAN_NAME" HeaderText="下达机关" DataField="ORGAN_NAME" />  
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                 <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                                    <Items>
                                 <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                                        <ext:Button ID="btnOk" Text="确定"  ValidateForms="sf_Edit" runat="server" Icon="Accept" OnClick="btnOk_Click">
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
