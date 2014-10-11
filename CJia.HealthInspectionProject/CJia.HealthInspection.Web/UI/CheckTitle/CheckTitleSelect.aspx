<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckTitleSelect.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.CheckTitle.CheckTitleSelect" %>

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
                    <ext:Tree ID="tree_Main" runat="server" OnNodeCommand="tree_Main_NodeCommand" EnableArrows="true" ShowBorder="false" Title="题目分类"  ShowHeader="true" AutoScroll="true" />
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
                                    <ext:Button ID="btn_Add" Icon="DatabaseAdd" Text="新增" runat="server">
                                    </ext:Button>
                                    <ext:Button ID="btn_Delete" Icon="DatabaseDelete" ConfirmText="确定要删除选中行记录及其该行相关所有记录么？" Text="删除" runat="server"
                                        OnClick="btn_Delete_Click">
                                    </ext:Button>
                                    <ext:Button ID="btn_Search" Icon="DatabaseConnect" Text="筛选" runat="server">
                                    </ext:Button>                            
                                    <ext:Button ID="btn_Export" Icon="DatabaseTable" Text="导出" runat="server" DisableControlBeforePostBack="false" EnableAjax="false">
                                    </ext:Button>                            
                                    <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    <ext:DropDownList ID="ddl_PageSize" AutoPostBack="true" Width="80"  OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged" runat="server">
                                        <ext:ListItem Text="每页15条" Value="15" />
                                        <ext:ListItem Text="每页20条" Value="20" Selected="true" />
                                        <ext:ListItem Text="每页30条" Value="30" />
                                        <ext:ListItem Text="每页50条" Value="50" />                                
                                    </ext:DropDownList>
                                    <ext:Label ID="lbl_c" runat="server" Width="3"></ext:Label>
                                    <ext:DropDownList ID="ddl_Search" AutoPostBack="true" Width="80"  OnSelectedIndexChanged="ddl_Search_SelectedIndexChanged"
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
                                OnSort="gr_Main_Sort" IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnRowCommand="gr_Main_RowCommand" OnRowDataBound="gr_Main_RowDataBound" OnPreRowDataBound="gr_Main_PreRowDataBound"
                                DataKeyNames="CHECK_TITLE_ID" AutoScroll="true" EnableRowDoubleClick="true" OnRowDoubleClick="gr_Main_RowDoubleClick">
                                <Columns>                           
                                    <%--<ext:BoundField HeaderText="编码" DataField="CHECK_TITLE_ID" /> --%>      
                                    <ext:BoundField DataToolTipField="CHECK_TITLE_NAME" Width="120px" HeaderText="题目名称" SortField="CHECK_TITLE_NAME" DataField="CHECK_TITLE_NAME" />
                                    <ext:BoundField DataToolTipField="CHECK_TITLE_CONTENT" HeaderText="题目内容" DataField="CHECK_TITLE_CONTENT" ExpandUnusedSpace="true"/>
                                    <ext:BoundField HeaderText="添加人" SortField="USER_NAME" DataField="USER_NAME" Width="50px"/>
                                    <ext:BoundField Width="120px" HeaderText="添加时间" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                                    <ext:BoundField Width="120px" HeaderText="更新时间" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                                    <ext:CheckBoxField  SortField="IS_CHOICE" Width="50px" RenderAsStaticField="True" CommandName="cb_choice" DataField="IS_CHOICE" HeaderText="选择题" />
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
        CloseAction="HidePostBack" IsModal="true" Width="880px" Height="550px" OnClose="win_Edit_Close">
    </ext:Window>
    </form>
</body>
</html>
