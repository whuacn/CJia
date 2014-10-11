<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublishNotice.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.SendNotice" %>


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
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 2 2 0" runat="server">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
                            Height="" EnableLargeHeader="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="tlr_Btn" runat="server">
                                    <Items>
                                        <ext:Button ID="btn_Add_Notice" Icon="BellAdd" Text="发布公告" runat="server" OnClick="btn_Add_Notice_Click">
                                        </ext:Button>
                                        <ext:Button ID="btn_Edit_Notice" Text="编辑公告" runat="server" Icon="BellGo" OnClick="btn_Edit_Notice_Click">
                                        </ext:Button>
                                        <ext:Button ID="btn_Delete_Notice" Icon="BellDelete" Text="删除公告" ConfirmText="是否删除该公告？" ConfirmTarget="Top" runat="server" OnClick="btn_Delete_Notice_Click">
                                        </ext:Button>
                                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnRowCommand="gr_Main_RowCommand" OnPageIndexChange="gr_Main_PageIndexChange" OnSort="gr_Main_Sort"
                                    DataKeyNames="NOTICE_ID" AutoScroll="true" EnableRowDoubleClick="true" EnableMultiSelect="false">
                                    <Columns>
                                        <%--<ext:BoundField DataToolTipField="CODE" HeaderText="类别代码" SortField="CODE" DataField="CODE" Width="100px" ExpandUnusedSpace="false" />--%>
                                        <ext:BoundField DataToolTipField="NOTICE_SUBJECT" HeaderText="标题" SortField="NOTICE_SUBJECT" DataField="NOTICE_SUBJECT" Width="300px" ExpandUnusedSpace="false" />
                                        <ext:BoundField DataToolTipField="CREATE_DATE" HeaderText="发布日期" SortField="CREATE_DATE" DataField="CREATE_DATE" Width="150px" ExpandUnusedSpace="false" />
                                        <ext:BoundField DataToolTipField="VALID_DATE" HeaderText="有效期至" SortField="VALID_DATE" DataField="VALID_DATE" Width="150px" ExpandUnusedSpace="false" />
                                        <ext:BoundField DataToolTipField="CREATE_USER" HeaderText="发布人" SortField="CREATE_USER" DataField="CREATE_USER" Width="150px" ExpandUnusedSpace="false" />
                                        <ext:BoundField DataToolTipField="CREATE_DEPT" HeaderText="科室名称" SortField="CREATE_DEPT" DataField="CREATE_DEPT" Width="150px" ExpandUnusedSpace="false" />
                                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="公告内容" Width="80px" CommandName="Notice_Text" Icon="SystemSearch" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="1000px" Height="500px" OnClose="win_Edit_Close">
        </ext:Window>
    </form>
</body>
</html>
