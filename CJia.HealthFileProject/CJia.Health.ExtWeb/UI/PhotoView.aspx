<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoView.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.PhotoView" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>病案借阅申请系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
    <script src="../Js/jquery.min.js"></script>
    <script src="../Js/jquery.rotate.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
        });
        var value = 0;
        function RotateL() {
            value += 90;
            $("#rpnl_Main_ren_Right IMG").rotate({ animateTo: value })
        };
        function RotateR() {
            value -= 90;
            $("#rpnl_Main_ren_Right IMG").rotate({ animateTo: value })
        };
        function Init() {
            value = 0;
        };
    </script>
    <script type="text/javascript">
        function Click() {
            if (window.event.srcElement.tagName == "IMG") {
                window.event.returnValue = false;
            }
        }
        document.oncontextmenu = Click;
    </script>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" Title="病人基本信息" ShowHeader="true" Layout="Row" Position="Left" Margins="2" runat="server" Width="250px">
                    <Items>
                        <ext:Panel ID="Panel2" runat="server" ShowHeader="false" ShowBorder="false" Height="130px">
                            <Items>
                                <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    AutoScroll="true" LabelWidth="60px" BodyPadding="5px 5px" runat="server" EnableCollapse="True">
                                    <Rows>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="lblRecordNO" runat="server" Label="病案号" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="lblTimes" runat="server" Label="入院次数" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="lblName" runat="server" Label="病人姓名" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="lblGender" runat="server" Text="" Label="性别"></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                        <ext:FormRow>
                                            <Items>
                                                <ext:Label ID="lblBirthDay" runat="server" Label="出生日期" Text=""></ext:Label>
                                            </Items>
                                        </ext:FormRow>
                                    </Rows>
                                </ext:Form>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="Panel3" runat="server" ShowBorder="false" RowHeight="100%" Layout="Fit" ShowHeader="false">
                            <Items>
                                <ext:Grid ID="gr_project" DataKeyNames="PICTURE_ID,STORAGE_PATH,PICTURE_NAME" EnableTextSelection="true" EnableRowNumber="true" ShowHeader="False"
                                    AutoScroll="true" runat="server" ShowBorder="false" EnableRowClick="true" OnRowClick="gr_project_RowClick">
                                    <Columns>
                                        <ext:BoundField Width="35px" HeaderText="页码" DataField="PAGE_NO" />
                                        <ext:BoundField HeaderText="附加码" Width="48px" DataField="SUBPAGE" />
                                        <ext:BoundField ExpandUnusedSpace="true" DataToolTipField="PRO_NAME" HeaderText="病案分类" DataField="PRO_NAME" />
                                    </Columns>
                                </ext:Grid>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Region>
                <ext:Region ID="ren_Right" Title="图像浏览" Split="true"
                    EnableSplitTip="true" Margins="2 0 2 0" BodyPadding="0px" Position="Center"
                    runat="server" Layout="Fit">
                    <Items>
                        <ext:Panel ID="Panel4" runat="server" EnableBackgroundColor="true" BodyPadding="0"
                            Height="" AutoScroll="true" ShowBorder="false" ShowHeader="false"
                            Layout="Fit">
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar2" runat="server" Width="300px" CssClass="fontSize">
                                    <Items>
                                        <ext:Button ID="btnFirst" OnClick="btnFirst_Click" Text="首页" OnClientClick="Init()" runat="server" Icon="Picture">
                                        </ext:Button>
                                        <ext:Button ID="btnPre" OnClick="btnPre_Click" Text="上一页" OnClientClick="Init()" runat="server" Icon="ArrowLeft">
                                        </ext:Button>
                                        <ext:Button ID="btnNext" OnClick="btnNext_Click" Text="下一页" OnClientClick="Init()" runat="server" Icon="ArrowRight">
                                        </ext:Button>
                                        <ext:Button ID="btnLast" OnClick="btnLast_Click" Text="尾页" OnClientClick="Init()" runat="server" Icon="HouseConnect">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                            <Items>
                                <ext:Image ID="pimg" BoxMargin="0" runat="server" ImageUrl="" ShowLabel="False"></ext:Image>
                            </Items>
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar3" Position="Bottom" runat="server">
                                    <Items>
                                        <ext:ToolbarFill ID="ToolbarFill2" runat="server"></ext:ToolbarFill>
                                        <ext:Button ID="btnLeft" Text="左转" OnClientClick="RotateR();" runat="server" Icon="ArrowRotateAnticlockwise">
                                        </ext:Button>
                                        <ext:Button ID="btnRight" Text="右转" OnClientClick="RotateL()" runat="server" Icon="ArrowRotateClockwise">
                                        </ext:Button>
                                        <ext:Button ID="btnBig" Text="放大" OnClientClick="Init()" OnClick="btnBig_Click" runat="server" Icon="ZoomIn">
                                        </ext:Button>
                                        <ext:Button ID="BtnSmall" Text="缩小" OnClientClick="Init()" OnClick="BtnSmall_Click" runat="server" Icon="ZoomOut">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                        </ext:Panel>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
    </form>
</body>
</html>
