<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyQuery.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.MyQuery" %>

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
    <form id="form1" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" Title="病人基本信息" ShowBorder="false" ShowHeader="false" Layout="Row" Position="Center" Margins="2 0 2 2" runat="server">
                    <Items>
                        <ext:Panel ID="Panel1" runat="server" ShowHeader="false" ShowBorder="false">
                            <Items>
                                <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    AutoScroll="true" LabelWidth="75px" BodyPadding="15px 15px" runat="server" EnableCollapse="True">
                                    <Rows>
                                        <ext:FormRow ColumnWidths="23% 23% 23% 23% 8%">
                                            <Items>
                                                <ext:DatePicker ID="startDate" Label="出院时间" runat="server"></ext:DatePicker>
                                                <ext:DatePicker ID="endDate" Label="至" runat="server"></ext:DatePicker>
                                                <ext:TextBox ID="txtRecordNO" AutoPostBack="true" runat="server" Label="病案号" MaxLength="100" Text=""></ext:TextBox>
                                                <ext:TextBox ID="txtPatientName" AutoPostBack="true" runat="server" Label="病人名称" MaxLength="100" Text=""></ext:TextBox>
                                                <ext:Button ID="btnResert" runat="server" Icon="Reload" OnClick="btnResert_Click" Text="重置"></ext:Button>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow ColumnWidths="23% 23% 23% 23% 8%">
                                            <Items>
                                                <ext:DropDownList ID="cbRYKS" runat="server" Label="入院科室" EnableSimulateTree="true">
                                                </ext:DropDownList>
                                                <ext:DropDownList ID="cbCYKS" runat="server" Label="出院科室" EnableSimulateTree="true">
                                                </ext:DropDownList>
                                                <ext:TextBox ID="CYZD" AutoPostBack="true" runat="server" Label="出院诊断" MaxLength="100" Text=""></ext:TextBox>
                                                <ext:TextBox ID="SSMC" AutoPostBack="true" runat="server" Label="手术名称" MaxLength="100" Text=""></ext:TextBox>
                                                <ext:Button ID="btnQuery" runat="server" Icon="SystemSearch" OnClick="btnQuery_Click" Text="查询"></ext:Button>
                                            </Items>
                                        </ext:FormRow>
                                    </Rows>
                                </ext:Form>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel2" runat="server" Layout="Fit" AutoScroll="true" RowHeight="84%" ShowHeader="false" BodyPadding="3px">
                            <Items>
                                <ext:Grid ID="gr_Main" ShowHeader="False" runat="server" EnableCheckBoxSelect="true" AllowSorting="true" PageSize="20" ShowBorder="true" AllowPaging="true" EnableTextSelection="true"
                                    IsDatabasePaging="true" OnPageIndexChange="gr_Main_PageIndexChange" OnRowCommand="gr_Main_RowCommand"
                                    DataKeyNames="ID" AutoScroll="true" EnableRowDoubleClick="true">
                                    <Columns>
                                        <ext:BoundField DataToolTipField="FLAG" HeaderText="状态" DataField="FLAG" Width="60px" />
                                        <ext:BoundField DataToolTipField="RECORDNO" HeaderText="病案号" SortField="RECORDNO" DataField="RECORDNO" Width="110px" />
                                        <%--<ext:BoundField DataToolTipField="PATIENT_ID" HeaderText="病人ID" DataField="PATIENT_ID" Width="110" />--%>
                                        <ext:BoundField DataToolTipField="IN_HOSPITAL_TIME" Width="70px" HeaderText="入院次数" DataField="IN_HOSPITAL_TIME" />
                                        <ext:BoundField DataToolTipField="PATIENT_NAME" Width="90px" HeaderText="病人姓名" DataField="PATIENT_NAME" />
                                        <ext:BoundField DataToolTipField="GENDER_NAME" HeaderText="性别" DataField="GENDER_NAME" Width="50px" />
                                        <ext:BoundField DataToolTipField="IN_HOSPITAL_DATE2" Width="100px" HeaderText="入院日期" DataField="IN_HOSPITAL_DATE2" />
                                        <ext:BoundField DataToolTipField="IN_HOSPITAL_DEPT_NAME" HeaderText="入院科室" SortField="IN_HOSPITAL_DEPT_NAME" DataField="IN_HOSPITAL_DEPT_NAME" Width="120px" />
                                        <ext:BoundField DataToolTipField="OUT_HOSPITAL_DATE2" Width="100px" HeaderText="出院日期" DataField="OUT_HOSPITAL_DATE2" />
                                        <ext:BoundField DataToolTipField="OUT_HOSPITAL_DEPT_NAME" HeaderText="出院科室" SortField="OUT_HOSPITAL_DEPT_NAME" DataField="OUT_HOSPITAL_DEPT_NAME" Width="120px" />
                                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Info" HeaderText="&nbsp;" Width="80px" CommandName="Info" Text="详细信息>>" />
                                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_fav" HeaderText="&nbsp;" Width="40px" Icon="Add" CommandName="Favorite" ToolTip="收藏" Text="" />
                                        <ext:LinkButtonField ConfirmTarget="Top" ColumnID="lbf_Apply" HeaderText="&nbsp;" Width="80px" CommandName="Apply" Text="申请借阅" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                            <Toolbars>
                                <ext:Toolbar runat="server" Position="Bottom">
                                    <Items>
                                        <ext:ToolbarFill runat="server"></ext:ToolbarFill>
                                        <ext:Button runat="server" ID="btnApply" Text="申请借阅" Icon="BulletGo" OnClick="btnApply_Click"></ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="1050px" Height="500px">
        </ext:Window>
        <ext:Window ID="win_Reson" Title="填写申请原因" Hidden="true" Icon="ApplicationFormMagnify" Target="Self"
            runat="server" IsModal="true" CloseAction="HidePostBack" Width="350px" Height="250px">
            <Items>
                <ext:Panel ID="pnl_Search" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false" Height="300px" EnableBackgroundColor="true">
                    <Items>
                        <ext:TextArea runat="server" ID="txtReson" MaxLength="80"></ext:TextArea>
                    </Items>
                </ext:Panel>
            </Items>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btnOk" Text="提交申请" runat="server" Icon="BulletGo" OnClick="btnOk_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Window>
    </form>
</body>
</html>
