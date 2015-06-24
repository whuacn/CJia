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
                <ext:Region ID="ren_Center" EnableSplitTip="true" ShowBorder="false" CollapseMode="Mini" EnableCollapse="true" Width="500px" Margins="0" ShowHeader="false" Position="Center"
                    Layout="Fit" runat="server" CssClass="fontSize">
                    <Items>
                        <ext:Panel ID="pnl_Main" runat="server" BodyPadding="2px"
                            Height="" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Items>
                                <ext:Grid ID="gr_detail" ShowHeader="False" runat="server" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true" EnableRowNumber="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_detail_PageIndexChange" OnRowCommand="gr_detail_RowCommand"
                                    DataKeyNames="ID,ft_id" AutoScroll="true">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="RECORDNO" Width="120px" HeaderText="病案号" SortField="RECORDNO" DataField="RECORDNO" />
                                        <ext:BoundField DataToolTipField="IN_HOSPITAL_TIME" HeaderText="入院次数" DataField="IN_HOSPITAL_TIME" Width="60px" />
                                        <ext:BoundField HeaderText="病人姓名" SortField="PATIENT_NAME" DataField="PATIENT_NAME" Width="80px" />
                                        <ext:BoundField Width="60px" HeaderText="性别" DataField="GENDER_NAME" />
                                        <ext:BoundField Width="110px" HeaderText="入院日期" SortField="IN_HOSPITAL_DATE2" DataField="IN_HOSPITAL_DATE2" />
                                        <ext:BoundField Width="110px" HeaderText="入院科室" SortField="IN_HOSPITAL_DEPT_NAME" DataField="IN_HOSPITAL_DEPT_NAME" />
                                        <ext:BoundField Width="110px" HeaderText="出院日期" SortField="OUT_HOSPITAL_DATE2" DataField="OUT_HOSPITAL_DATE2" />
                                        <ext:BoundField Width="110px" HeaderText="出院科室" SortField="OUT_HOSPITAL_DEPT_NAME" DataField="OUT_HOSPITAL_DEPT_NAME" />
                                        <ext:BoundField Width="110px" HeaderText="收藏时间" SortField="favorites_date" DataField="favorites_date" />
                                        <ext:LinkButtonField ConfirmTarget="Top" Text="详细>>" ColumnID="lbf_Edit" HeaderText="&nbsp;" Width="65px" CommandName="Details" />
                                        <ext:LinkButtonField ConfirmTarget="Top" Text="浏览病案" ColumnID="lbf_Edit2" HeaderText="&nbsp;" Width="80px" CommandName="Image" />
                                        <ext:LinkButtonField ConfirmTarget="Top" Text="" ColumnID="lbf_Edit3" ToolTip="移除" ConfirmText="确定移除？" Icon="Delete" HeaderText="&nbsp;" Width="50px" CommandName="Delete" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar1" runat="server" Position="Bottom">
                                    <Items>
                                        <ext:ToolbarFill ID="ToolbarFill1" runat="server"></ext:ToolbarFill>
                                        <ext:Button runat="server" ConfirmText="确定删除此收藏夹？" ID="btnDeleteFav" Text="删除此收藏夹" Icon="BookDelete" OnClick="btnDeleteFav_Click"></ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_Image" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" >
        </ext:Window>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="1050px" Height="500px">
        </ext:Window>
    </form>
</body>
</html>
