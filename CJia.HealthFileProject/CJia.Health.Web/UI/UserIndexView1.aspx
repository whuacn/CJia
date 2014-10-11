<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserIndexView1.aspx.cs"
    Inherits="Web.SuperAdmin.SuperAdminindex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>病案借阅申请系统</title>
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.18.custom.min.js" type="text/javascript"></script>
    <script src="../js/menu.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var h = $('#left').height();
            $('#right').height((h - 100) + 'px');
            $('#main').height((h - 100) + 'px');
        });
    </script>
    <style type="text/css">
        ul {
            margin: 0;
            padding: 0;
        }

            ul.container {
                width: 100%;
            }

        li {
            list-style: none;
            text-align: center;
        }

            li.menu {
                width: 100%;
                margin-top: 10px;
                background-color: #42B5D2;
            }

            li.button a {
                display: block;
                font-size: 21px;
                height: 30px;
                overflow: hidden;
                width: 100%;
                top: 5px;
                text-align: center;
                background-image: url(../images/Admin/110.JPG);
                background-position: center;
                background-repeat: no-repeat;
            }


        .dropdown {
            display: none;
            width: 100%;
            background-color: #42B5D2;
            text-align: center;
        }

            .dropdown li {
                color: #CCCCCC;
                margin: 5px 0;
                width: 100%;
                text-align: center;
            }

            .dropdown a:hover {
                color: #FF6600;
            }

        a, a:visited {
            color: #000000;
            font-weight: bold;
            text-decoration: none;
            outline: none;
        }

        .STYLE7 {
            font-size: 14px;
            color: black;
        }

            .STYLE7 a {
                font-size: 14px;
                color: black;
                text-decoration: none;
            }
                .STYLE7 a:hover {
                    color:white;
                }
    </style>
</head>
<body style="background-color: #42B5D2">
    <%--#42B5D2 05a8f5--%>
    <form id="form1" runat="server">
        <div style="position: absolute; top: 0; left: 0; right: 0; width: 100%; height: 80px; /*background-image: url(../images/Admin/top_back.jpg)*/background-color:#42B5D2">
            <table style="position: absolute; top: 0px; right: 0px; left: 0px; width: 100%;">
                <tr>
                    <td width="417" style="padding-top: 0px">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Admin/91.png" />
                    </td>
                    <td>
                        <table style="width: 100%;">
                            <tr style="height: 45px">
                                <td></td>
                            </tr>
                            <tr style="height: 35px;">
                                <td style="font-size: 13px; font-weight: bold; color: #FFFFFF; width: 220px;">
                                    <%--<asp:Label ID="lble" runat="server" Font-Bold="True" Font-Size="16px" ForeColor="#CCCCCC"></asp:Label>--%>&nbsp;&nbsp;
                                </td>
                                <td>&nbsp;</td>
                                <td style="font-size: 13px; font-weight: bold; color: #FFFFFF; text-align: right; position: relative;"><%--登陆时间：<asp:Label ID="lblLoginTime" runat="server" Text="Label" Font-Size="12px" ForeColor="#CCCCCC"></asp:Label>--%>&nbsp;&nbsp;&nbsp;&nbsp;
                                <div style="height: 20px; line-height: 20px; position: absolute; top: 0; left: 0; right: 0;">
                                    <table align="center" border="0" cellspacing="0" cellpadding="0" style="width: 100%; height: 25px;">
                                        <tr style="width: 100%;">
                                            <td></td>
                                            <td width="21px" style="text-align: right">
                                                <img src="../images/Admin/HtmlHome.png" width="16" height="16" alt="" />
                                            </td>
                                            <td width="60px" class="STYLE7" style="text-align: left">
                                                <div align="center">
                                                    <a href="" target="_top" style="font-size: 14px;">首&nbsp;页</a>
                                                </div>
                                            </td>
                                            <td width="21px" class="STYLE7" style="text-align: right">
                                                <img src="../images/Admin/HtmlBackward.png" width="16" height="16" alt="" />
                                            </td>
                                            <td width="60px" class="STYLE7" style="text-align: left">
                                                <div align="center">
                                                    <a href="javascript:history.go(-1);" style="font-size: 14px;">后&nbsp;退</a>
                                                </div>
                                            </td>
                                            <td width="21px" class="STYLE7" style="text-align: right">
                                                <img src="../images/Admin/HtmlForward.png" width="16" height="16" alt="" />
                                            </td>
                                            <td width="60px" class="STYLE7" style="text-align: left;">
                                                <div align="center">
                                                    <a href="javascript:history.go(+1);" style="font-size: 14px; ">前&nbsp;进</a>
                                                </div>
                                            </td>
                                            <td width="21px" class="STYLE7" style="text-align: right">
                                                <img src="../images/Admin/Recurrence.png" width="16" height="16" alt="" />
                                            </td>
                                            <td width="60px" class="STYLE7" style="text-align: left;">
                                                <div align="center">
                                                    <a href="javascript:window.main.location.reload();" style="font-size: 14px;">刷&nbsp;新</a>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div id="all" style="position: fixed; top: 80px; left: 20px; right: 20px; height: 100%; background-color: White">
            <div runat="server" id="left" style="width: 15%; height: 100%; float: left">
                <div style="width: 100%; height: 30px; background-color: #FFFFFF">
                    <%--<asp:Image ID="Image3" runat="server" ImageUrl="../images/Admin/menu1.png" Width="100%" Height="100%" />--%>
                </div>
                <div align="center" style="width: 100%;">
                    <ul class="container">
                        <li class="menu">
                            <ul>
                                <li class="button"><a href="#" target="main" style="font-size: large; font-weight: bold; color: #FFFFFF; text-decoration: none; line-height: 30px;">病案查询</a></li>
                                <li class="dropdown">
                                    <ul>
                                        <li><a href="QueryPatientView.aspx" target="main">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;查询病案</a><hr />
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="menu">
                            <ul>
                                <li class="button"><a href="#" target="main" style="font-size: large; font-weight: bold; color: #FFFFFF; text-decoration: none; line-height: 30px;">病案管理</a></li>
                                <li class="dropdown">
                                    <ul>
                                        <li><a href="MyApplyView.aspx" target="main">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;我的申请</a><hr />
                                        </li>
                                        <li><a href="" target="main">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;归还病案</a><hr />
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="menu">
                            <ul>
                                <li class="button"><a href="#" target="main" style="font-size: large; font-weight: bold; color: #FFFFFF; text-decoration: none; line-height: 30px;">病案查阅</a></li>
                                <li class="dropdown">
                                    <ul>
                                        <li><a href="MyBorrowView.aspx" target="main">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;我的借阅</a><hr />
                                        </li>
                                        <li><a href="ReadBorrowView.aspx" target="main">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;查看病案</a><hr />
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="menu">
                            <ul>
                                <li class="button"><a href="#" target="main" style="font-size: large; font-weight: bold; color: #FFFFFF; text-decoration: none; line-height: 30px;">归还管理</a></li>
                                <li class="dropdown">
                                    <ul>
                                        <li><a href="" target="main">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;已归还</a><hr />
                                        </li>
                                        <li><a href="" target="main">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;待归还</a><hr />
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="menu">
                            <ul>
                                <li class="button"><a href="#" target="main" style="font-size: large; font-weight: bold; color: #FFFFFF; text-decoration: none; line-height: 30px;">个人中心</a></li>
                                <li class="dropdown">
                                    <ul>
                                        <li><a href="EditPasswordView.aspx" target="main">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;修改密码</a><hr />
                                        </li>
                                        <li><a href="../LoginView.aspx" target="_parent" onclick="return confirm('确定退出系统吗吗?')">
                                            <img alt="" src="../images/Admin/dropdown.png" border="none" />&nbsp;退出系统</a><hr />
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <div runat="server" style="width: 1%; height: 100%; background-color: #42B5D2; float: left">
            </div>
            <div runat="server" id="right" style="width: 84%; float: left;">
                <iframe width="100%" frameborder="0" src="QueryPatientView.aspx" name="main" id="main"></iframe>
            </div>
        </div>
        <div style="position: fixed; bottom: 0; height: 30px; text-align: center; color: Orange; font-weight: bold; width: 100%; background-color: #42B5D2; font-size: 15px; vertical-align: middle;"
            align="center">
            <table style="width: 100%; height: 30px">
                <tr>
                    <td><%--@病案数字化存储与管理系统&nbsp;&nbsp;九江市妇幼保健院--%>
                    </td>
                    <td style="width: 20%; text-align: right; color: #CCCCCC">
                        <img src="../images/Admin/8.png" height="20px" width="20px" />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="#FFFFFF"></asp:Label>
                        <%--<img src="../images/Admin/6.png" height="20px" width="20px" />--%>&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="#FFFFFF"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
