<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckSubmitView.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.CheckSubmitView" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                                        <ext:Label runat="server" EncodeText="false" Width="60px" Text="评审状态" ShowLabel="true"></ext:Label>
                                        <ext:RadioButtonList AutoPostBack="true" CssStyle="color:red;font-weight:bold;" OnSelectedIndexChanged="rbState_SelectedIndexChanged" ID="rbState" Width="300px" LabelSeparator="1" ShowLabel="true" Label="评审状态" ColumnNumber="4" runat="server">
                                        </ext:RadioButtonList>
                                        <ext:ToolbarFill ID="tbf_t" runat="server"></ext:ToolbarFill>
                                        <ext:Button runat="server" ConfirmText="确定提交？" ID="btnSubmit" Text="提交审核" Icon="Tick" OnClick="Unnamed_Click"></ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" EnableRowDoubleClick="true"
                                    DataKeyNames="CHECK_ID" OnRowCommand="gr_Main_RowCommand" OnPageIndexChange="gr_Main_PageIndexChange" AutoScroll="true" OnSort="gr_Main_Sort">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="DESCRIPTION" HeaderText="条款" SortField="TREE_NAME" DataField="TREE_NAME" ExpandUnusedSpace="true" />
                                        <ext:BoundField DataToolTipField="RESPONSIBLE_NAME" Width="80px" HeaderText="责任人" DataField="RESPONSIBLE_NAME" />
                                        <ext:BoundField HeaderText="报审日期" DataField="SUBMIT_DATE" Width="120px" />
                                        <ext:BoundField Width="80px" HeaderText="评审人" SortField="CHECK_USER_NAME" DataField="CHECK_USER_NAME" />
                                        <ext:BoundField Width="120px" HeaderText="评审日期" SortField="CHECK_DATE" DataField="CHECK_DATE" />
                                        <ext:BoundField Width="120px" HeaderText="评审状态" SortField="STATE_NAME" DataField="STATE_NAME" />
                                        <ext:BoundField Width="120px" HeaderText="评审结果" SortField="RESULT_NAME" DataField="RESULT_NAME" />
                                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="查看" Width="60px" CommandName="Read" Icon="BookOpen" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="BookOpen" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="450px" Height="300px" OnClose="win_Edit_Close" >
        </ext:Window>
    </form>
</body>
</html>
