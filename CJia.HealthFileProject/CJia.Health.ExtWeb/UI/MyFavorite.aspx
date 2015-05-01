<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyFavorite.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.MyFavorite" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>病案借阅申请系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="300px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                    Layout="Fit" runat="server" CssClass="fontSize">
                    <Items>
                        <ext:Panel ID="Panel1" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar1" runat="server" Width="300px" CssClass="fontSize">
                                    <Items>
                                        <ext:Button ID="Button1" runat="server" Icon="SystemSearch" Text="收藏夹管理"></ext:Button>
                                        <ext:DropDownList ID="ddl_Data_Type" AutoPostBack="true" runat="server" Width="150px">
                                        </ext:DropDownList>
                                        <ext:Button ID="btnQuery" runat="server" Icon="SystemSearch" Text="查询"></ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gr_title" ShowHeader="false" Title="病人列表" runat="server" >
                                    <Columns>
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_NAME" Width="150px"  HeaderText="病人姓名" SortField="CHECK_TITLE_NAME" DataField="CHECK_TITLE_NAME" />
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_NAME" Width="150px"  HeaderText="出院诊断" SortField="CHECK_TITLE_NAME" DataField="CHECK_TITLE_NAME" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Center" Title="病人基本信息" ShowHeader="true" Layout="Row" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel CssClass="rowpanel" runat="server" ShowHeader="false" ShowBorder="false">
                            <Items>
                                <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    AutoScroll="true" LabelWidth="5px" BodyPadding="5px 5px" runat="server" EnableCollapse="True">
                                    <Rows>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="Label1" runat="server" Text="病案号： "></ext:Label>
                                                <ext:Label ID="Label2" runat="server" Text="病案号： "></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="Label3" runat="server" Text="病人姓名： "></ext:Label>
                                                <ext:Label ID="Label4" runat="server" Text="病人姓名： "></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="Label5" runat="server" Text="性别： "></ext:Label>
                                                <ext:Label ID="Label6" runat="server" Text="性别： "></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="Label7" runat="server" Text="出生日期： "></ext:Label>
                                                <ext:Label ID="Label8" runat="server" Text="出生日期： "></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="Label9" runat="server" Text="出生日期： "></ext:Label>
                                                <ext:Label ID="Label10" runat="server" Text="出生日期： "></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="Label11" runat="server" Text="出生日期： "></ext:Label>
                                                <ext:Label ID="Label12" runat="server" Text="出生日期： "></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                    </Rows>
                                </ext:Form>
                            </Items>
                        </ext:Panel>
                        <ext:Panel CssClass="rowpanel" runat="server" RowHeight="100%" Layout="Fit" ShowHeader="false">
                            <Items>
                                <ext:Grid ID="grid1" ShowHeader="False" runat="server" ShowBorder="false">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_NAME" Width="500px" HeaderText="病案分类" SortField="CHECK_TITLE_NAME" DataField="CHECK_TITLE_NAME" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Right" Title="图像浏览" Split="true"
                    EnableSplitTip="true" Margins="2 0 2 0" BodyPadding="0px" Position="Right" Width="1000px"
                    runat="server" Layout="Fit">
                    <Items>
                        <ext:Panel ID="Panel2" runat="server" EnableBackgroundColor="true" BodyPadding="2 2 2 2"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Items>
                                <ext:Grid ID="gridCheckTitle" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true" IsDatabasePaging="true"
                                    EnableCheckBoxSelect="false" EnableMultiSelect="false" DataKeyNames="CHECK_TITLE_ID" AutoScroll="true" EnableRowDoubleClick="true" EnableRowNumber="True">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="CHECK_TITLE_NAME" Width="400px" HeaderText="题目名称" SortField="CHECK_TITLE_NAME" DataField="CHECK_TITLE_NAME" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar3" Position="Bottom" runat="server">
                                    <Items>
                                        <ext:ToolbarFill ID="ToolbarFill2" runat="server"></ext:ToolbarFill>
                                        <ext:Button ID="btn_answer" Text="答题" runat="server" Icon="TextRuler">
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
