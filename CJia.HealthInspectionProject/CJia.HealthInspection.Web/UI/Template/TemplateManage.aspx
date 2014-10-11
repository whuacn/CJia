<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateManage.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Template.TemplateManage" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
</head>
<body>
    <form id="frm_Main" runat="server">    
    <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
    <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
        <Regions>
            <ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="180px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                Layout="Fit" runat="server">
                <Items>
                    <ext:Tree ID="tree_Main" runat="server" OnNodeCommand="tree_Main_NodeCommand" EnableArrows="true" ShowBorder="false" Title="模板分类"  ShowHeader="true" AutoScroll="true" />
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
                                    <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    <ext:DropDownList ID="ddl_PageSize" AutoPostBack="true" Width="80"  OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged" runat="server">
                                        <ext:ListItem Text="每页15条" Value="15" />
                                        <ext:ListItem Text="每页20条" Value="20" Selected="true" />
                                        <ext:ListItem Text="每页30条" Value="30" />
                                        <ext:ListItem Text="每页50条" Value="50" />                                
                                    </ext:DropDownList>
                                    <ext:Label ID="lbl_c" runat="server" Width="3"></ext:Label>
                                    <ext:DropDownList ID="ddl_Search" AutoPostBack="true" Width="80"
                                        runat="server">                                
                                        <ext:ListItem Text="名称" Value="NameD" />
                                        <ext:ListItem Text="父名" Value="ParentD.NameD" />
                                    </ext:DropDownList>
                                    <ext:Label ID="lbl_r" runat="server" Width="3"></ext:Label>
                                    <ext:TwinTriggerBox ID="ttb_Search" runat="server" Width="150" EmptyText="输入要搜索的关键字" 
                                        ShowTrigger1="false"
                                        Trigger1Icon="Clear" Trigger2Icon="Search" >
                                    </ext:TwinTriggerBox>                                                  
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>              
                        <Items>
                            <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                OnSort="gr_Main_Sort" IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnRowCommand="gr_Main_RowCommand"
                                DataKeyNames="TEMPLATE_ID" AutoScroll="true" EnableRowDoubleClick="true">
                                <Columns>                           
                                    <ext:BoundField DataToolTipField="TEMPLATE_NAME"  HeaderText="模板名称" SortField="TEMPLATE_NAME" DataField="TEMPLATE_NAME" ExpandUnusedSpace="true" />
                                    <ext:BoundField DataToolTipField="SMALL_TEMPLATE_NAME" Width="140px" HeaderText="模板分类" DataField="SMALL_TEMPLATE_NAME" />
                                    <ext:BoundField HeaderText="添加人" SortField="USER_NAME" DataField="USER_NAME" Width="50px"/>
                                    <ext:BoundField Width="120px" HeaderText="添加时间" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                                    <ext:BoundField Width="120px" HeaderText="更新时间" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                                    <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="35px" CommandName="Edit" Text="编辑" />
                                    <ext:LinkButtonField ConfirmText="确定要删除此记录及其相关所有记录么？" ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="35px" CommandName="Delete" Text="删除" />                            
                                </Columns>                        
                            </ext:Grid>
                        </Items>
                    </ext:Panel> 
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>   
    <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server" 
        CloseAction="HidePostBack" IsModal="true" Width="980px" Height="600px" OnClose="win_Edit_Close">
    </ext:Window>
    </form>
</body>
</html>
