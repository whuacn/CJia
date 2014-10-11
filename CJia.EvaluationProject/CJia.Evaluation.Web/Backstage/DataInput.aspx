<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataInput.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.DataInput" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../../Css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:Toolbar runat="server">
            <Items>
                <ext:Button ID="Button1" Icon="add" Text="增加" runat="server" >
                </ext:Button>
                <ext:Button ID="Button2" Icon="add" Text="修改" runat="server" >
                </ext:Button>
                <ext:ToolbarFill ID="ToolbarFill1" runat="server"></ext:ToolbarFill>
            </Items>
        </ext:Toolbar>
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="180px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                    Layout="Fit" runat="server">
                    <Items>
                        <ext:Tree ID="tree_Main" runat="server"  EnableArrows="true" ShowBorder="false" Title="评审内容" ShowHeader="true" AutoScroll="true" OnNodeCommand="tree_Main_NodeCommand"/>
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="tlr_Btn" runat="server">
                                    <Items>
                                        <ext:Button ID="btnAddData" Icon="add" Text="增加" runat="server" OnClick="btnAddData_Click">
                                        </ext:Button>
                                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    </Items>
                                    
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gr_Data" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true"   EnableRowNumber="True" OnPageIndexChange="gr_Data_PageIndexChange" EnableCheckBoxSelect="true" OnSort="gr_Data_Sort" DataKeyNames="DATA_ID" OnRowCommand="gr_Data_RowCommand">
                                    <columns>          
                                    <ext:BoundField DataToolTipField="DATA_NAME"  HeaderText="标题" SortField="DATA_NAME" DataField="DATA_NAME"  Width="300px" ExpandUnusedSpace="false" />                 
                                    <ext:BoundField DataToolTipField="COLUMN_TREE_NAME"  HeaderText="条款" SortField="COLUMN_TREE_NAME" DataField="COLUMN_TREE_NAME"  ExpandUnusedSpace="false" />
                                    <ext:BoundField DataToolTipField="DATA_TYPE" Width="140px" HeaderText="资料类别" DataField="DATA_TYPE" />
                                    <ext:BoundField DataToolTipField="CREATE_BY" Width="140px" HeaderText="录入用户" DataField="CREATE_BY" />
                                    <ext:BoundField DataToolTipField="CREATER_DATE" HeaderText="录入时间" SortField="CREATER_DATE" DataField="CREATER_DATE" Width="150px"/>
                                    <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="35px" CommandName="data_Edit" Text="编辑" />
                                    <ext:LinkButtonField ConfirmText="确定要删除此记录及其相关所有记录么？" ConfirmTarget="Top" ColumnID="data_Delete" HeaderText="&nbsp;" Width="35px" CommandName="Delete" Text="删除" />                            
                                </columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="window1" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="1000px" Height="500px" >
        </ext:Window>
    </form>
</body>
</html>
