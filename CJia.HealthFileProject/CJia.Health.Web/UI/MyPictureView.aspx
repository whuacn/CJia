<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyPictureView.aspx.cs" Inherits="CJia.Health.Web.UI.MyPictureView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Js/Main.js"></script>
    <script src="../js/jquery.pack.js"></script>
    <script src="../js/jquery.rotate.js"></script>
    <script type="text/javascript">
        //加载页面要使用的CSS
        loadCss(top._skinId, 'Page.css');
    </script>
    <style type="text/css">
        .lin {
            border-style: none none dashed none;
            border-color: #808080;
            border-bottom-width: 1px;
        }
    </style>
    <script type="text/javascript">
        function AutoResizeImage(maxWidth, maxHeight, objImg) {
            var img = new Image();
            img.src = objImg.src;
            var hRatio;
            var wRatio;
            var Ratio = 1;
            var w = img.width;
            var h = img.height;
            wRatio = maxWidth / w;
            hRatio = maxHeight / h;
            if (maxWidth == 0 && maxHeight == 0) {
                Ratio = 1;
            } else if (maxWidth == 0) {//
                if (hRatio < 1) Ratio = hRatio;
            } else if (maxHeight == 0) {
                if (wRatio < 1) Ratio = wRatio;
            } else if (wRatio < 1 || hRatio < 1) {
                Ratio = (wRatio <= hRatio ? wRatio : hRatio);
            }
            if (Ratio < 1) {
                w = w * Ratio;
                h = h * Ratio;
            }
            objImg.height = h;
            objImg.width = w;
        }
        window.onload = function () {
            var e = document.body.clientWidth;
            var imga = document.getElementById('pic_td').getElementsByTagName('img')[0];
            AutoResizeImage(e - 240, 0, imga);
        }
    </script>
    <script type="text/javascript">
        //function click() {
        //    alert('对不起,您不能保存此病案,谢谢您的理解和支持!')
        //}
        //function click1() {
        //    if (event.button == 2) { alert('对不起,您不能保存此病案,谢谢您的理解和支持!') }
        //} function CtrlKeyDown() {
        //    if (event.ctrlKey) { alert('不当的拷贝将损害您的系统！') }
        //}
        //document.onkeydown = CtrlKeyDown;
        //document.onselectstart = click;
        //document.onmousedown = click1;
        function Click() {
            if (window.event.srcElement.tagName == "IMG") {
                window.event.returnValue = false;
            }
        }
        document.oncontextmenu = Click;
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var w;
            var h;
            var i = 0;
            var j = 1;
            $("#RotateR").click(function () {
                if (!document.body.filters) {
                    return;
                }
                var imga = document.getElementById('pic_td').getElementsByTagName('img')[0];
                if (i == 0) {
                    w = imga.width;
                    h = imga.height;
                    i = 1;
                }
                if (j == 1) {
                    AutoResizeImage(0, imga.width, imga);
                    j = 0;
                }
                else {
                    AutoResizeImage(w, 0, imga);
                    j = 1;
                }
                $('#pic_td img').rotateRight(90);
            });
            $("#RotateL").click(function () {
                if (!document.body.filters) {
                    return;
                }
                var imga = document.getElementById('pic_td').getElementsByTagName('img')[0];
                if (i == 0) {
                    w = imga.width;
                    h = imga.height;
                    i = 1;
                }
                if (j == 1) {
                    AutoResizeImage(0, imga.width, imga);
                    j = 0;
                }
                else {
                    AutoResizeImage(w, 0, imga);
                    j = 1;
                }
                $('#pic_td img').rotateLeft(90);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMsg" runat="server" Text="对不起,没有您要查看的病案信息。。。"></asp:Label>
            <table width="100%" style="text-align: left; font-family: 宋体; font-size: 14px;" runat="server" id="pictureTab">
                <tr>
                    <%--style="height: 615px"--%>
                    <td>
                        <%--<img id="theimage" src="../images/i1.png" />--%></td>
                    <td id="pic_td" style="text-align:left;vertical-align:top; display: inline-block; background-image: url(../images/7.gif); background-position: top,center; background-repeat: no-repeat;"><%--width: 900px; border: 1px solid #808080;--%>
                        <asp:Repeater ID="pictureList" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <%--<div style="border: 1px solid #808080; width: 820px;height:615px;">--%>
                                <%--<img alt="" title="" src='<%# GetSrc(DataBinder.Eval(Container.DataItem,"SRC").ToString())%>' border="0" width="0" height="0" onload="AutoResizeImage(900,0,this)" />--%>
                                <%--<img alt="" title="" src='~/CheckCode.aspx>' border="0" width="0" height="0" onload="AutoResizeImage(900,0,this)" />--%>
                                <asp:Image ID="pic" runat="server" ImageUrl='<%# GetSrc(DataBinder.Eval(Container.DataItem,"SRC").ToString())%>' BorderWidth="0" />
                                <%--<img id="pic" src="33055901_01_001_00.jpg" />--%>
                                <%--<asp:Image ID="Image1" ImageUrl="~/CheckCode.aspx?id=<%# Eval("SRC") %>" runat="server" onload="AutoResizeImage(900,0,this)" border="0"/>--%>
                                <%--</div>--%>
                                <%-- <asp:Image ToolTip='<%# GetSrc(DataBinder.Eval(Container.DataItem,"SRC").ToString())%>' ImageUrl="\\192.168.1.207\Health\20130717\B0012\0100100.JPG"  ID="picImg" runat="server" Width="820px" Height="615px" />--%>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                    <td style="width: 220px; vertical-align: top;">
                        <table style="border: 1px solid #808080; width: 100%">
                            <tr style="height: 25px; text-align: center">
                                <td class="lin">本次入院共有<asp:Label ID="lblAmount" runat="server" Text="22"></asp:Label>个项目</td>
                            </tr>
                            <tr style="height: 219px">
                                <td style="vertical-align: middle; text-align: center; font-size: 15px;">
                                    <asp:ListBox ID="lbProject" runat="server" Height="200px" Width="160px" OnSelectedIndexChanged="lbProject_SelectedIndexChanged" Font-Size="16px" AutoPostBack="True" ForeColor="Black"></asp:ListBox>
                                </td>
                            </tr>
                            <tr style="height: 60px">
                                <td class="lin">
                                    <table cellpadding="0" cellspacing="0" style="width: 100%; height: 60px;">
                                        <tr style="height: 30px">
                                            <td style="font-size: 13px; width: 100%; text-align: center; height: 30px;">
                                                <asp:Label ID="Label7" runat="server" Text="第"></asp:Label>[
                                                <asp:Label ID="labPage" runat="server" Text="1" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                                ]页
                                                <asp:Label ID="Label6" runat="server" Text="共"></asp:Label>
                                                [
                                                <asp:Label ID="labBackPage" runat="server" ForeColor="Blue" Font-Bold="true"></asp:Label>
                                                ]页
                                            </td>
                                        </tr>
                                        <tr style="height: 30px">
                                            <td style="font-size: 13px; width: 100%; text-align: center; height: 30px;">
                                                <asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="Red"
                                                    OnClick="lnkbtnOne_Click">首页</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="Red"
                                                    OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="Red"
                                                    OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="Red"
                                                    OnClick="lnkbtnBack_Click">尾页</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="height: 30px">
                                <td style="font-size: 13px; width: 100%; text-align: center; height: 30px;">
                                    <input type="button" value="逆时针旋转" name="RotateL" id="RotateL" />
                                    <input type="button" value="顺时针旋转" name="RotateR" id="RotateR" />
                                </td>
                            </tr>
                            <tr style="height: 275px">
                                <td>
                                    <table width="100%" style="text-align: center;">
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">病案号：<asp:Label ID="lblRecordNO" runat="server" Text="C00001"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">病人姓名：<asp:Label ID="lblPatientName" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">性别：<asp:Label ID="lblGender" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">出生于：<asp:Label ID="lblBirth" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">职业：<asp:Label ID="lblJob" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">入院方式：<asp:Label ID="lblInHosState" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">入院科室：<asp:Label ID="lblInHosDept" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">出院医生：<asp:Label ID="lblOutHosDoctor" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">出院诊断：<asp:Label ID="lblCYZD" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin">手术名称：<asp:Label ID="lblSSMC" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                        <tr style="width: 100%; height: 25px">
                                            <td class="lin" style="border-style: none none dashed none; border-color: #808080; border-bottom-width: 1px;">院内感染：<asp:Label ID="lblYNGR" runat="server" Text="张三"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
