<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiptFavorite.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.ReceiptFavorite" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>病案借阅申请系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="rgn_Top" Split="true" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="500px" Margins="2 0 2 2" ShowHeader="false" Position="Left"
                    Layout="Fit" runat="server" CssClass="fontSize">
                    <Toolbars>
                        <ext:Toolbar ID="Toolbar1" runat="server" Width="500px" CssClass="fontSize">
                            <Items>
                                <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    AutoScroll="true" LabelWidth="80px" CssClass="fontSize" BodyPadding="10px 5px" runat="server" EnableCollapse="True" Width="500px" ColumnWidth="500px">
                                    <Rows>
                                        <ext:FormRow ColumnWidths="100%">
                                            <Items>
                                                <ext:Label runat="server" ID="applyName" Label="申请人" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow ColumnWidths="100%">
                                            <Items>
                                                <ext:Label runat="server" ID="applyTime" Label="申请时间" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow ColumnWidths="100%">
                                            <Items>
                                                <ext:Label runat="server" ID="applyReson" ToolTip="" Label="申请理由" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow ColumnWidths="100%">
                                            <Items>
                                                <ext:Label runat="server" ID="lblStart" ToolTip="" Label="借阅开始时间" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow ColumnWidths="100%">
                                            <Items>
                                                <ext:Label runat="server" ID="lblEnd" ToolTip="" Label="借阅截止时间" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                    </Rows>
                                </ext:Form>
                            </Items>
                        </ext:Toolbar>
                    </Toolbars>
                    <Items>
                        <ext:Panel ID="Panel2" BodyPadding="2px" Title="申请记录单" runat="server" Layout="Fit" ShowHeader="true" ShowBorder="false">
                            <Items>
                                <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnRowCommand="gr_Main_RowCommand"
                                    DataKeyNames="BORROW_LIST_ID,APPLYER_NAME,APPLY_DATE,APPLY_REASON,BORROW_DATE,RETURN_DATE" OnRowClick="gr_Main_RowClick" AutoScroll="true" EnableRowClick="true" EnableRowNumber="true">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="BORROW_LIST_NO" HeaderText="申请单编号" SortField="BORROW_LIST_NO" DataField="BORROW_LIST_NO" Width="150px" ExpandUnusedSpace="true" />
                                        <ext:BoundField DataToolTipField="APPLY_DATE" HeaderText="申请时间" SortField="APPLY_DATE" DataField="APPLY_DATE" Width="120px" />
                                        <ext:BoundField Hidden="true" DataToolTipField="APPLYER_NAME" HeaderText="申请人" SortField="APPLYER_NAME" DataField="APPLYER_NAME" Width="80px" />
                                        <ext:BoundField DataToolTipField="BORROW_STATE_NAME" Width="60px" HeaderText="状态" DataField="BORROW_STATE_NAME" />
                                        <ext:BoundField Hidden="true" DataToolTipField="APPLY_REASON" Width="400px" HeaderText="申请理由" DataField="APPLY_REASON" ExpandUnusedSpace="true" />
                                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="60px" CommandName="Info" Text="详情>>" />
                                        <ext:LinkButtonField Hidden="true" ConfirmText="确定归还？" ConfirmTarget="Top" ColumnID="lbf_Edit1" HeaderText="&nbsp;" Width="50px" CommandName="Resert" Text="归还" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Center" EnableSplitTip="true" CollapseMode="Mini" EnableCollapse="true" Width="500px" Margins="2 2 2 0" ShowHeader="false" Position="Center"
                    Layout="Fit" runat="server" CssClass="fontSize">

                    <Items>
                        <ext:Panel ID="pnl_Main" Title="申请单详情" runat="server" BodyPadding="2px"
                            Height="" ShowBorder="false" ShowHeader="true"
                            Layout="Fit">
                            <Items>
                                <ext:Grid ID="gr_detail" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true" EnableRowNumber="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_detail_PageIndexChange" OnRowCommand="gr_detail_RowCommand"
                                    DataKeyNames="ID" AutoScroll="true">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="RECORDNO" Width="100px" HeaderText="病案号" SortField="RECORDNO" DataField="RECORDNO" />
                                        <ext:BoundField DataToolTipField="IN_HOSPITAL_TIME" HeaderText="入院次数" DataField="IN_HOSPITAL_TIME" Width="60px" />
                                        <ext:BoundField HeaderText="病人姓名" SortField="PATIENT_NAME" DataField="PATIENT_NAME" Width="80px" />
                                        <ext:BoundField Width="50px" HeaderText="性别" DataField="GENDER_NAME" />
                                        <ext:BoundField Width="90px" HeaderText="入院日期" SortField="IN_HOSPITAL_DATE2" DataField="IN_HOSPITAL_DATE2" />
                                        <ext:BoundField Width="100px" HeaderText="入院科室" SortField="IN_HOSPITAL_DEPT_NAME" DataField="IN_HOSPITAL_DEPT_NAME" />
                                        <ext:LinkButtonField ConfirmTarget="Top" Text="详细>>" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="60px" CommandName="Details" />
                                        <ext:LinkButtonField ConfirmTarget="Top" Text="浏览图片" ColumnID="lbf_Edit2" HeaderText="&nbsp;" Width="70px" CommandName="Image" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_Image" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="1000px" Height="550px">
        </ext:Window>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="1050px" Height="500px">
        </ext:Window>
    </form>
</body>
</html>
