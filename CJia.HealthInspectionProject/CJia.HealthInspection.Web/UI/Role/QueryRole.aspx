<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryRole.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Role.QueryRole" %>
<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
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
                                    <ext:Button ID="btnAdd" Icon="DatabaseAdd" Text="新增" runat="server" OnClick="btnAdd_Click">
                                    </ext:Button>
                                    <ext:Button ID="btnDelete" Icon="DatabaseDelete" ConfirmText="确定要删除选中行记录及其该行相关所有记录么？" Text="删除" runat="server" OnClick="btnDelete_Click">
                                    </ext:Button>
                                    <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    <ext:DropDownList ID="dropPageSize" AutoPostBack="true" Width="80"  OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged" runat="server">
                                        <ext:ListItem Text="每页15条" Value="15" />
                                        <ext:ListItem Text="每页20条" Value="20" Selected="true" />
                                        <ext:ListItem Text="每页30条" Value="30" />
                                        <ext:ListItem Text="每页50条" Value="50" />                                
                                    </ext:DropDownList>
                                    <ext:Label ID="lbl_c" runat="server" Width="3"></ext:Label>
                                    <ext:DropDownList ID="ddl_Search" AutoPostBack="true" Width="80" runat="server">                                
                                        <ext:ListItem Text="名称" Value="NameD"/>
                                    </ext:DropDownList>
                                    <ext:Label ID="lbl_r" runat="server" Width="3"></ext:Label>
                                    <ext:TwinTriggerBox ID="ttbSearch" runat="server" Width="150" EmptyText="输入要搜索的关键字" 
                                        ShowTrigger1="false" OnTrigger2Click="ttbSearch_Trigger2Click" Trigger1Icon="Clear" Trigger2Icon="Search" >
                                    </ext:TwinTriggerBox>                                                  
                                </Items>
                            </ext:Toolbar>
                        </Toolbars>              
                        <Items>
                            <ext:Grid ID="gridRole" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="18" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                OnSort="gr_Main_Sort" IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnRowCommand="gridRole_RowCommand"
                                DataKeyNames="ROLE_ID" AutoScroll="true" EnableRowDoubleClick="true" OnRowDoubleClick="gridRole_RowDoubleClick">
                                <Columns>
                                    <ext:BoundField HeaderText="名称" SortField="ROLE_NAME" DataField="ROLE_NAME" ExpandUnusedSpace="true"/>
                                     <ext:BoundField HeaderText="添加时间" Width="140px" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                                     <ext:BoundField HeaderText="更新时间" Width="140px" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />
                                    <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="50px" CommandName="Edit" Text="编辑" />
                                    <ext:LinkButtonField ConfirmText="确定要删除此记录及其相关所有记录么？" ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="50px" CommandName="Delete" Text="删除" />                            
                                </Columns>                        
                            </ext:Grid>
                        </Items>
                    </ext:Panel> 
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>  
    <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
        CloseAction="HidePostBack" IsModal="true" Width="880px" Height="550px">
    </ext:Window> 
    </form>
</body>
</html>
