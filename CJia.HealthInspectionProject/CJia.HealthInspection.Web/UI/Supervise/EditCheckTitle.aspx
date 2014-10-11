<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCheckTitle.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Supervise.EditCheckTitle" %>

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
                <ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="450px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                    Layout="Fit" runat="server" CssClass="fontSize">
                    <Items>
                        <ext:Panel ID="Panel1" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Items>
                                <ext:Grid ID="gr_title" ShowHeader="false" Title="添加检查题目" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnRowCommand="gr_title_RowCommand"
                                    DataKeyNames="CHECK_TITLE_ID" AutoScroll="true" EnableRowNumber="True">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_NAME" Width="110px" HeaderText="题目名称" SortField="CHECK_TITLE_NAME" DataField="CHECK_TITLE_NAME" />
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_CONTENT" HeaderText="题目内容" DataField="CHECK_TITLE_CONTENT" ExpandUnusedSpace="true" />
                                        <ext:LinkButtonField ConfirmTarget="Top" IconUrl="../../Icons/page_header_footer.png" ToolTip="详情" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="30px" CommandName="Details" Text="" />
                                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="30px" CommandName="Delete" Text="" ToolTip="移除" Icon="Delete" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                                    <Items>
                                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                                        <ext:Button ID="btn_Save" Text="保存" ConfirmText="确定保存这些题目吗？" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btn_Save_Click">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                        </ext:Panel>
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
                                        <ext:Label ID="Label1" runat="server" Width="30px" Text="分类"></ext:Label>
                                        <ext:DropDownList ID="ddl_Big" AutoPostBack="true" Width="131" runat="server" OnSelectedIndexChanged="ddl_Big_SelectedIndexChanged">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label4" runat="server" Width="6"></ext:Label>
                                        <ext:DropDownList ID="ddl_Middle" AutoPostBack="true" runat="server" EnableSimulateTree="false" ShowRedStar="true" Width="133"  OnSelectedIndexChanged="ddl_Middle_SelectedIndexChanged">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label5" runat="server" Width="6"></ext:Label>
                                        <ext:DropDownList ID="ddl_Small" runat="server" EnableSimulateTree="true" Width="133">
                                        </ext:DropDownList>
                                        <ext:Label ID="Label2" runat="server" Width="6"></ext:Label>
                                        <ext:Button runat="server" IconUrl="../../Icons/zoom.png" Text="查询" ID="btn_Select" Type="Button" OnClick="btn_Select_Click"></ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gr_SingleTitle" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnRowCommand="gr_SingleTitle_RowCommand" OnPageIndexChange="gr_SingleTitle_PageIndexChange"
                                    DataKeyNames="CHECK_TITLE_ID" AutoScroll="true" EnableRowNumber="True">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_NAME" Width="110px" HeaderText="题目名称" SortField="CHECK_TITLE_NAME" DataField="CHECK_TITLE_NAME" />
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_CONTENT" HeaderText="题目内容" DataField="CHECK_TITLE_CONTENT" ExpandUnusedSpace="true" />
                                        <%--<ext:BoundField Width="120px" HeaderText="添加时间" SortField="CREATE_DATE" DataField="CREATE_DATE" />
                                        <ext:BoundField Width="120px" HeaderText="更新时间" SortField="UPDATE_DATE" DataField="UPDATE_DATE" />--%>
                                        <ext:LinkButtonField ConfirmTarget="Top" IconUrl="../../Icons/page_header_footer.png" ToolTip="详情" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="30px" CommandName="Details" Text="" />
                                        <ext:LinkButtonField Icon="Add" ConfirmTarget="Top" ToolTip="添加" ColumnID="lbf_Delete" HeaderText="&nbsp;" Width="30px" CommandName="Add" Text="" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar2" Position="Bottom" runat="server">
                                    <Items>
                                        <ext:ToolbarFill ID="ToolbarFill1" runat="server"></ext:ToolbarFill>
                                        <ext:Button ID="btn_add" Text="添加" runat="server" Icon="Tick" OnClick="btn_add_Click">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
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
