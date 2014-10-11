<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileType.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.FileType" %>

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
                <%--<ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="180px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                    Layout="Fit" runat="server">
                    <Items>
                        <ext:Tree ID="tree_Main" runat="server" OnNodeCommand="tree_Main_NodeCommand" EnableArrows="true" ShowBorder="false" Title="模板分类" ShowHeader="true" AutoScroll="true" />
                    </Items>
                </ext:Region>--%>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="tlr_Btn" runat="server">
                                    <Items>
                                        <ext:Button ID="btn_Add_Type" Icon="PageAdd" Text="新增类别" runat="server" OnClick="btn_Add_Type_Click">
                                        </ext:Button>
                                        <ext:Button ID="btn_Edit_Type" Text="编辑类别" runat="server" OnClick="btn_Edit_Type_Click" Icon="PageEdit">
                                        </ext:Button>
                                        <ext:Button ID="btn_Delete_Type" Icon="PageDelete" Text="删除类别" ConfirmText="是否删除该类别？" ConfirmTarget="Top" runat="server" OnClick="btn_Delete_Type_Click">
                                        </ext:Button>
                                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true"
                                    DataKeyNames="TYPE_ID,TYPE_VALUE" AutoScroll="true" EnableRowDoubleClick="true" EnableMultiSelect="false">
                                    <Columns>
                                        <%--<ext:BoundField DataToolTipField="CODE" HeaderText="类别代码" SortField="CODE" DataField="CODE" Width="100px" ExpandUnusedSpace="false" />--%>
                                        <ext:BoundField DataToolTipField="TYPE_NAME" HeaderText="类别类型" SortField="TYPE_NAME" DataField="TYPE_NAME" Width="100px" ExpandUnusedSpace="false" />
                                        <ext:BoundField DataToolTipField="TYPE_VALUE" HeaderText="类别名称" SortField="TYPE_VALUE" DataField="TYPE_VALUE" Width="100px" ExpandUnusedSpace="false" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="400px" Height="180px" OnClose="win_Edit_Close">
        </ext:Window>
    </form>
</body>
</html>

