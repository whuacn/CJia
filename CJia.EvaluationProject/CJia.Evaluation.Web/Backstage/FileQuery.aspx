<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileQuery.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.FileQuery" %>


<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../../Css/main.css" />
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="180px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                    Layout="Fit" runat="server">
                    <Items>
                        <ext:Tree ID="tree_Main" runat="server" OnNodeCommand="tree_Main_NodeCommand" EnableArrows="true" ShowBorder="false" Title="组织结构" ShowHeader="true" AutoScroll="true" />
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
                                        <ext:Label runat="server" Text="档案类别： "></ext:Label>
                                        <ext:DropDownList ID="ddl_Data_Type" AutoPostBack="true" runat="server" Label="档案类别" ShowRedStar="true" Width="150">
                                        </ext:DropDownList>
                                         <ext:Label ID="Label3" runat="server" Width="5" Text=""></ext:Label>
                                        <ext:Label runat="server" Text="录入员： "></ext:Label>
                                        <ext:DropDownList ID="ddl_Data_User" AutoPostBack="true" runat="server" Label="档案类别" ShowRedStar="true" Width="150">
                                        </ext:DropDownList>
                                         <ext:Label ID="Label1" runat="server" Width="5" Text=""></ext:Label>
                                        <ext:Label runat="server" Text="标题： "></ext:Label>
                                        <ext:TextBox ID="txt_Subject" runat="server" Width="200"></ext:TextBox>
                                        <ext:Button ID="btn_Query" runat="server" Icon="SystemSearch" Text="查询" OnClick="btn_Query_Click"></ext:Button>
                                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gr_Data" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true"   EnableRowNumber="True"   DataKeyNames="DATA_ID" OnPageIndexChange="gr_Data_PageIndexChange" OnSort="gr_Data_Sort" OnRowCommand="gr_Data_RowCommand">
                                    <columns>          
                                    <ext:BoundField DataToolTipField="DATA_NAME"  HeaderText="标题" SortField="DATA_NAME" DataField="DATA_NAME"  Width="300px" ExpandUnusedSpace="false" />                 
                                    <ext:BoundField DataToolTipField="TREE_PATH"  HeaderText="条款" SortField="TREE_PATH" DataField="TREE_PATH"  Width="120" ExpandUnusedSpace="false" />
                                    <ext:BoundField DataToolTipField="TYPE_VALUE" Width="140px" HeaderText="资料类别" DataField="TYPE_VALUE" />
                                    <ext:BoundField DataToolTipField="USER_NAME" Width="140px" HeaderText="录入用户" DataField="USER_NAME" />
                                    <ext:BoundField DataToolTipField="CREATER_DATE" HeaderText="录入时间" SortField="CREATER_DATE" DataField="CREATER_DATE" Width="150px"/>
                                    <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="35px" Icon="SystemSearch" CommandName="data_Query" />                         
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

